using Landeeyo.Pizza.AccountControl.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Landeeyo.Pizza.Test.Unit.AccountControl
{
    public class AccountControlMockedTest
    {
        private Mock<IAccountControl> _accountControl;

        public AccountControlMockedTest()
        {
            _accountControl = new Mock<IAccountControl>();
        }

        [Fact]
        public void AuthorizeUserMocked()
        {
            //arrange
            string login = "TestLogin";
            string password = "TestPassword";
            _accountControl.Setup(x => x.AuthorizeUser(login, password)).Returns(true);

            //act
            var result1 = _accountControl.Object.AuthorizeUser(login, password);
            var result2 = _accountControl.Object.AuthorizeUser(null, null);
            var result3 = _accountControl.Object.AuthorizeUser("test", "test");

            //assert
            Assert.True(result1);
            Assert.False(result2);
            Assert.False(result3);
        }
    }
}
