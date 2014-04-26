using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations;
using Landeeyo.Pizza.Common.Exceptions.AccountControl;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Landeeyo.Pizza.Test.Unit.AccountControl
{
    public class AccountControlSQLTest
    {
        private IAccountControl _accountControl;
        private IDataAccess _dataAccess;

        public AccountControlSQLTest()
        {
            _accountControl = new SimpleAccountControl();
            _dataAccess = new SQLFacade();
        }

        [Fact]
        public void CreateAndAuthorizeUser()
        {
            string properLogin = "TestLogin";
            string properPassword = "TestPassword";
            string improperLogin = "dfjkhsdfk";
            string improperPassword = "fdjhsdfkf";


            //arrange
            User properUser = new User()
            {
                Login = properLogin,
                Password = properPassword
            };

            _accountControl.SetDataSource = _dataAccess;

            //act
            var result1 = _accountControl.CreateAccount(properUser).HasValue;
            var result2 = _accountControl.AuthorizeUser(properLogin, properPassword);
            var result3 = _accountControl.AuthorizeUser(improperLogin, improperPassword);

            //assert
            Assert.True(result1);
            Assert.Throws<UserExistsException>(
                delegate
                {
                    _accountControl.CreateAccount(properUser);
                });
            Assert.True(result2);
            Assert.False(result3);
        }
    }
}
