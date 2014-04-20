using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations;
using Xunit;

namespace Landeeyo.Pizza.Test.Unit.AccountControl
{
    public class AccountControlNotImplementedTest
    {
        private IAccountControl _accountControl;

        public AccountControlNotImplementedTest()
        {
            _accountControl = new NotImplementedAccountControl();
        }

        [Fact]
        public void AuthorizeUser()
        {
            Assert.Throws<System.NotImplementedException>(
                delegate
                {
                    _accountControl.AuthorizeUser(string.Empty, string.Empty);
                });
        }
    }
}
