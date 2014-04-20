using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.Common.Exceptions.AccountControl;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer;
using System;
using System.Linq;

namespace Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations
{
    public class SimpleAccountControl : IAccountControl
    {
        IDataAccess _dataSource;

        public bool AuthorizeUser(string login, string password)
        {
            var queryResult = from user in _dataSource.GetUsers
                              where user.Login == login
                                     && user.Password == password
                              select user;
            if (queryResult.SingleOrDefault() != null)
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
            var queryResult = from u in _dataSource.GetUsers
                              where u.Login == user.Login
                              select u;
            if (queryResult.SingleOrDefault() != null)
            {
                throw new UserExistsException();
            }
            else
            {
                //Add user
                user.UserID = _dataSource.AddUser(user);
            }
        }

        public DataAccessLayer.IDataAccess SetDataSource
        {
            set { _dataSource = value; }
        }
    }
}
