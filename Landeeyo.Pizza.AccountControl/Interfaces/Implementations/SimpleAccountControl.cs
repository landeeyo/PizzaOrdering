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
            var user = _dataSource.GetUserByLogin(login);
            if (user != null)
            {
                return user.Password == password;
            }
            else
            {
                return false;
            }
        }

        public void CreateAccount(User user)
        {
            //Check if user already exists
            if (_dataSource.GetUserByLogin(user.Login) != null)
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
