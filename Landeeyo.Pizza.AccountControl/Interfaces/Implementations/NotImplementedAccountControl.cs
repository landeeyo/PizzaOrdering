using Landeeyo.Pizza.AccountControl.Interfaces;
using System;

namespace Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations
{
    public class NotImplementedAccountControl : IAccountControl
    {
        public bool AuthorizeUser(string login, string password)
        {
            throw new NotImplementedException();
        }

        public int? CreateAccount(Common.Models.AccountControl.User user)
        {
            throw new NotImplementedException();
        }

        public DataAccessLayer.IDataAccess SetDataSource
        {
            set { throw new NotImplementedException(); }
        }
    }
}
