using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer;
using Xunit;

namespace Landeeyo.Pizza.Test.Unit.AccountControl
{
    public class AccountControlSQLTest
    {
        private IAccountControl _accountControl;
        private IDataAccess _dataAccess;

        public AccountControlSQLTest()
        {
            _dataAccess = new SQLDataAccess(new UnitOfWork());
            _accountControl = new SimpleAccountControl(_dataAccess);            
        }

        [Fact]
        public void CreateAndAuthorizeUserTest()
        {
            #region Arrange

            string properLogin = "testLogin";
            string properPassword = "testPassword";
            var user = new User()
            {
                Login=properLogin,
                Password=properPassword,
                Firstname="John",
                Surname="Locke",
                Email="john@locke.com",
            };

            #endregion

            #region Act

            _accountControl.AddUser(user);
            _accountControl.Save();
            var isAuthorized = _accountControl.AuthorizeUser(properLogin, properPassword);
            var isNotAuthorized = _accountControl.AuthorizeUser("bufkjdfs", "affasddfsjsfs");

            #region Cleanup

            _dataAccess.RemoveUserByID(user.UserID);
            _dataAccess.Save();

            #endregion

            #endregion

            #region Assert

            Assert.True(user.UserID != 0);
            Assert.True(isAuthorized);
            Assert.False(isNotAuthorized);

            #endregion
        }

        [Fact]
        public void UpdateAndRemoveUserTest()
        {
            #region Arrange

            string login = "testLogin";
            string password = "testPassword";

            var user = new User()
            {
                Login = login,
                Password = password,
                Firstname = "John",
                Surname = "Locke",
                Email = "john@locke.com",
            };

            string newLogin = "updatedLogin";
            string newPassword = "updatedPassword";

            #endregion

            #region Act

            #region Prepare

            _accountControl.AddUser(user);
            _accountControl.Save();

            #endregion

            #region Act

            //Updating
            var updatedUser = _accountControl.GetUserByID(user.UserID);
            updatedUser.Login = newLogin;
            updatedUser.Password = newPassword;
            _accountControl.UpdateUser(updatedUser);
            _accountControl.Save();
            updatedUser = _accountControl.GetUserByID(updatedUser.UserID);
            //Removing
            _accountControl.RemoveUserByID(updatedUser.UserID);
            _accountControl.Save();
            var isRemoved = _accountControl.GetUserByID(updatedUser.UserID).DeactivationDate.HasValue;

            #endregion

            #region Cleanup

            _dataAccess.RemoveUserByID(updatedUser.UserID);
            _dataAccess.Save();

            #endregion

            #endregion

            #region Assert

            Assert.True(updatedUser.Login == newLogin && updatedUser.Password == newPassword);
            Assert.True(isRemoved);

            #endregion
        }
    }
}
