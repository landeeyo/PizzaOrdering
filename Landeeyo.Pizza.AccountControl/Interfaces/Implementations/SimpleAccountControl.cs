using Landeeyo.Pizza.AccountControl.Interfaces;
using System;

namespace Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations
{
    public class SimpleAccountControl : IAccountControl
    {
        public bool AuthorizeUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public void CreateAccount(Common.Models.AccountControl.User user)
        {
            throw new NotImplementedException();
        }

        public DataAccessLayer.IDataAccess SetDataSource
        {
            set { throw new NotImplementedException(); }
        }
    }
}
