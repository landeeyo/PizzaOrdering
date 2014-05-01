using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations;
using Landeeyo.Pizza.Common.Exceptions.AccountControl;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer;
using Landeeyo.Pizza.DataAccessLayer.EntityConfig;
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

        public AccountControlSQLTest()
        {
            _accountControl = new SimpleAccountControl();
            _accountControl.SetDataSource = new SQLFacade();
        }

        [Fact]
        public void CreateAndAuthorizeUser()
        {
            //arrange

            string properLogin = "TestLogin";
            string properPassword = "TestPassword";
            string improperLogin = "dfjkhsdfk";
            string improperPassword = "fdjhsdfkf";

            User properUser = new User()
            {
                Login = properLogin,
                Password = properPassword,
                Email = "test@test.com",
                Firstname = "John",
                Surname = "Locke"
            };



            //act
            var result1 = _accountControl.AddUser(properUser);
            var result2 = _accountControl.AuthorizeUser(properLogin, properPassword);
            var result3 = _accountControl.AuthorizeUser(improperLogin, improperPassword);
            Assert.Throws<UserExistsException>(
               delegate
               {
                   _accountControl.AddUser(properUser);
               });

            //cleanup
            using (var context = new DatabaseContext())
            {
                var user = context.Users.Where(x => x.Login == properUser.Login).SingleOrDefault();
                context.Users.Remove(user);
                context.SaveChanges();
            }

            //assert
            Assert.True(result1 > 0);
            Assert.True(result2);
            Assert.False(result3);
        }
    }
}
