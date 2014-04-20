using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer;

namespace Landeeyo.Pizza.AccountControl.Interfaces
{
    /// <summary>
    /// Authorization interface - authorizatio
    /// </summary>
    public interface IAccountControl
    {
        /// <summary>
        /// Authorizes user
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>True if authorized, false if not</returns>
        bool AuthorizeUser(string login, string password);

        /// <summary>
        /// Creates account
        /// </summary>
        /// <returns>True if created successfully, false if not</returns>
        void CreateAccount(User user);

        /// <summary>
        /// Sets data source
        /// </summary>
        IDataAccess SetDataSource { set; }
    }
}
