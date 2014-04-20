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
        public void AuthorizeUser()
        {
            string login = "TestLogin";
            string password = "TestPassword";

            _accountControl.Setup(x => x.AuthorizeUser(login, password)).Returns(true);

            Assert.True(_accountControl.Object.AuthorizeUser(login, password));
            Assert.False(_accountControl.Object.AuthorizeUser(null, null));
            Assert.False(_accountControl.Object.AuthorizeUser("test", "test"));
        }
    }
}
