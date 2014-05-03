using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations;
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
        }

        [Fact]
        public void UpdateAndRemoveUserTest()
        {
        }
    }
}
