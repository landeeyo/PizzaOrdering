using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations;
using Landeeyo.Pizza.Common.Exceptions.AccountControl;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer;
using Landeeyo.Pizza.DataAccessLayer.EntityConfig;
using Ninject;
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

        private IAccountControl _pizzaManagement;
        IKernel _ninjectKernel;

        public AccountControlSQLTest()
        {
            _ninjectKernel = new StandardKernel();
            _ninjectKernel.Bind<IAccountControl>().To<SimpleAccountControl>();
            _ninjectKernel.Bind<IDataAccess>().To<SQLFacade>();
        }

        [Fact]
        public void CreateAndAuthorizeUserTest()
        {
            #region Arrange

            _accountControl = _ninjectKernel.Get<IAccountControl>();
            _dataAccess = _ninjectKernel.Get<IDataAccess>();
            _accountControl.SetDataSource = _dataAccess;

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

            #endregion

            #region Act
                        
            _accountControl.AddUser(properUser);
            var result1 = properUser.UserID;
            var result2 = _accountControl.AuthorizeUser(properLogin, properPassword);
            var result3 = _accountControl.AuthorizeUser(improperLogin, improperPassword);
            Assert.Throws<UserException>(
               delegate
               {
                   _accountControl.AddUser(properUser);
               });

            //Cleanup
            //_dataAccess.RemoveUserByID(properUser.UserID);
            //_accountControl.Rollback();

            #endregion

            #region Assert

            Assert.True(result1 > 0);
            Assert.True(result2);
            Assert.False(result3);

            #endregion
        }

        [Fact]
        public void UpdateAndRemoveUserTest()
        {
            #region Arrange
            _accountControl = _ninjectKernel.Get<IAccountControl>();
            _dataAccess = _ninjectKernel.Get<IDataAccess>();
            _accountControl.SetDataSource = _dataAccess;

            string testLogin = "TestLogin";
            string testPassword = "TestPassword";
            User testUser = new User()
            {
                Login = testLogin,
                Password = testPassword,
                Email = "test@test.com",
                Firstname = "John",
                Surname = "Locke"
            };

            #endregion

            #region Act

            _accountControl.AddUser(testUser);
            var restult1 = _accountControl.GetUserByID(testUser.UserID) != null;
            _accountControl.RemoveUserByID(testUser.UserID);
            var restult2 = _accountControl.GetUserByID(testUser.UserID) != null;

            //Cleanup
            //_dataAccess.RemoveUserByID(testUser.UserID);
            //_accountControl.Rollback();

            #endregion

            #region Assert

            Assert.True(restult1);
            Assert.False(restult2);

            #endregion
        }
    }
}
