using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.Common.Exceptions.AccountControl;
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

        public int AddUser(User user)
        {
            if (user != null && user.Login != null && user.Password != null)
            {
                if (user.Login == "TestLogin" && user.Password.Length > 0)
                {
                    return 1;
                }
            }
            throw new UserCreationException();
        }

        public DataAccessLayer.IDataAccess SetDataSource
        {
            set { throw new System.NotImplementedException(); }
        }
    }
}
