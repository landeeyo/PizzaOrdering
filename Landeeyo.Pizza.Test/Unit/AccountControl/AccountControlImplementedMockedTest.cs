using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Moq;
using Xunit;

namespace Landeeyo.Pizza.Test.Unit.AccountControl
{
    public class AccountControlImplementedMockedTest
    {
        private IAccountControl _accountControl;

        public AccountControlImplementedMockedTest()
        {
            _accountControl = new MockedAccountControl();
        }

        [Fact]
        public void AuthorizeUserImplementedMocked()
        {
            //arrange
            string properLogin = "TestLogin";
            string properPassword = "TestPassword";
            string improperLogin = "fhsfudfsjfd";
            string improperPassword = "fdjfjkhdsfk";

            //act
            var result1 = _accountControl.AuthorizeUser(properLogin, properPassword);
            var result2 = _accountControl.AuthorizeUser(improperLogin, improperPassword);

            //assert
            Assert.True(result1);
            Assert.False(result2);
        }

        [Fact]
        public void CreateUserImplementedMocked()
        {
            //arrange
            User properUser = new User() { Login = "TestLogin", Password = "TestPassword" };
            User improperUser = new Mock<User>().SetupAllProperties().Object; 

            //act
            _accountControl.CreateAccount(improperUser);
            var result1 = improperUser.IsAuthorized;
            _accountControl.CreateAccount(properUser);
            var result2 = properUser.IsAuthorized;

            //assert
            Assert.False(result1);
            Assert.True(result2);
        }
    }
}
