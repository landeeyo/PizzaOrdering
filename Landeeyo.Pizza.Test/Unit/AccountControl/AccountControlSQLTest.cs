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
            _accountControl = new SimpleAccountControl();
            _dataAccess = new SQLFacade(new UnitOfWork());
            _accountControl.SetDataSource = _dataAccess;
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

            #endregion

            #region Act

            #region Cleanup

            #endregion

            #endregion

            #region Assert

            #endregion
        }
    }
}
