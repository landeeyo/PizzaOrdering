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
    public class AccountControlTest
    {
        private Mock<IAccountControl> _accountControl;

        public AccountControlTest()
        {
            _accountControl = new Mock<IAccountControl>();
        }

        [Fact]
        public void AuthorizeUser()
        {
            string login = "TestLogin";
            string password = "TestPassword";

            _accountControl.Setup(x => x.AuthorizeUser(login, password)).Returns(true);
            _accountControl.Setup(x => x.AuthorizeUser(null, null)).Returns(false);

            Assert.True(_accountControl.Object.AuthorizeUser(login, password));
            Assert.False(_accountControl.Object.AuthorizeUser(null, null));
        }
    }
}
