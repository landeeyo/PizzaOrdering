using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer.EntityConfig;

namespace Landeeyo.Pizza.DataAccessLayer
{
    public class SQLFacade : IDataAccess
    {
        public User GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public int? AddUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
