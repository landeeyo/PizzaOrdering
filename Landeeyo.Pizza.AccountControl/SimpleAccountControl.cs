using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.Common.Exceptions.AccountControl;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer;
using System;

namespace Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations
{
    public class SimpleAccountControl : IAccountControl
    {
        #region Initialization

        IDataAccess _dataSource;

        public SimpleAccountControl(IDataAccess dataSource)
        {
            _dataSource = dataSource;
        } 

        #endregion

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
                    return user.Password == password && !user.DeactivationDate.HasValue;
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
                user.CreateDate = DateTime.Now;
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
                user.DeactivationDate = DateTime.Now;
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

        
    }
}
