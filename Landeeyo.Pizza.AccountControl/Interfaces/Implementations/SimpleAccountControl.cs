using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.Common.Exceptions.AccountControl;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer;
using System;

namespace Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations
{
    public class SimpleAccountControl : IAccountControl
    {
        IDataAccess _dataSource;

        public void Save()
        {
            _dataSource.Save();
        }

        public bool AuthorizeUser(string login, string password)
        {
            try
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
            catch (Exception ex)
            {
                throw new UserException(ex);
            }
        }

        public void AddUser(User user)
        {
            try
            {
                //Add user
                user.IsActive = true;
                _dataSource.AddUser(user);
            }
            catch (Exception ex)
            {
                throw new UserException(ex);
            }
        }

        public void RemoveUserByID(int userID)
        {
            try
            {
                User user = _dataSource.GetUserByID(userID);
                user.IsActive = false;
                _dataSource.UpdateUser(user);
            }
            catch (Exception ex)
            {
                throw new UserException(ex);
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                _dataSource.UpdateUser(user);
            }
            catch (Exception ex)
            {
                throw new UserException(ex);
            }
        }

        public User GetUserByID(int userID)
        {
            try
            {
                return _dataSource.GetUserByID(userID);
            }
            catch (Exception ex)
            {
                throw new UserException(ex);
            }
        }

        public DataAccessLayer.IDataAccess SetDataSource
        {
            set { _dataSource = value; }
        }
    }
}
