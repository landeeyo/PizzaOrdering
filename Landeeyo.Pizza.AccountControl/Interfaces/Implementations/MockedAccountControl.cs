using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.Common.Models.AccountControl;

namespace Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations
{
    public class MockedAccountControl : IAccountControl
    {
        public bool AuthorizeUser(string login, string password)
        {
            if (login == "TestLogin" && password == "TestPassword")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void CreateAccount(User user)
        {
            if (user != null && user.Login != null && user.Password != null)
            {
                if (user.Login == "TestLogin" && user.Password.Length > 0)
                {
                    user.IsAuthorized = true;
                    return;
                }
            }
            else
            {
                user.IsAuthorized = false;
                return;
            }
        }

        public DataAccessLayer.IDataAccess SetDataSource
        {
            set { throw new System.NotImplementedException(); }
        }
    }
}
