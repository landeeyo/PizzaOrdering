using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations;
using Landeeyo.Pizza.Common.Exceptions.AccountControl;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Landeeyo.Pizza.Test.Unit.AccountControl
{
    public class AccountControlMockedDALTest
    {
        private IAccountControl _accountControl;
        private Mock<IDataAccess> _dataAccessMock;

        public AccountControlMockedDALTest()
        {
            _accountControl = new SimpleAccountControl();
            _dataAccessMock = new Mock<IDataAccess>();
        }

        [Fact]
        public void AuthorizeUser()
        {
            //arrange
            string properLogin = "TestLogin";
            string properPassword = "TestPassword";
            string improperLogin = "dfjkhsdfk";
            string improperPassword = "fdjhsdfkf";

            _dataAccessMock
                .Setup(x => x.GetUserByLogin(properLogin))
                .Returns(
                    new User()
                    {
                        Login = properLogin,
                        Password = properPassword
                    });
            _accountControl.SetDataSource = _dataAccessMock.Object;

            //act
            var result1 = _accountControl.AuthorizeUser(properLogin, properPassword);
            var result2 = _accountControl.AuthorizeUser(improperLogin, improperPassword);

            //assert
            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        public void CreateUser()
        {
            //arrange
            string storedLogin = "TestLogin";
            string storedPassword = "TestPassword";

            User properUser = new User()
            {
                Login = "TestUser01",
                Password = "TestPassword01"
            };
            User improperUser = new User()
            {
                Login = storedLogin,
                Password = storedPassword
            };

            _dataAccessMock
                .Setup(x => x.GetUserByLogin(storedLogin))
                .Returns(
                    new User
                    {
                        Login = storedLogin,
                        Password = storedPassword
                    });
            _dataAccessMock
                .Setup(x => x.AddUser(properUser))
                .Returns(2);

            _accountControl.SetDataSource = _dataAccessMock.Object;

            //act
            var result1 = _accountControl.AddUser(properUser).HasValue;

            //assert
            Assert.True(result1);
            Assert.Throws<UserExistsException>(
                delegate
                {
                    _accountControl.AddUser(improperUser);
                });
        }
    }
}
