using Landeeyo.Pizza.Common.Models.AccountControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.DataAccessLayer
{
    public interface IDataAccess
    {
        User GetUserByLogin(string login);
        int AddUser(User user);
    }
}
