using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer;

namespace Landeeyo.Pizza.AccountControl.Interfaces
{
    /// <summary>
    /// Authorization interface - authorizatio
    /// </summary>
    public interface IAccountControl
    {
        bool AuthorizeUser(string login, string password);
        void AddUser(User user);

        IDataAccess SetDataSource { set; }
    }
}
