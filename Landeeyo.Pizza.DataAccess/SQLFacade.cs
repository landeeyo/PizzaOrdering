using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer.EntityConfig;
using Landeeyo.Pizza.Common.Exceptions.AccountControl;

namespace Landeeyo.Pizza.DataAccessLayer
{
    public class SQLFacade : IDataAccess
    {
        public User GetUserByLogin(string login)
        {
            using (var context = new DatabaseContext())
            {
               return context.Users.Where(x => x.Login == login).SingleOrDefault();
            }
        }

        public int AddUser(User user)
        {
            using (var context = new DatabaseContext())
            {
                if (context.Users.Where(x => x.Login == user.Login).SingleOrDefault() != null)
                {
                    throw new UserExists();
                }
                context.Users.Add(user);
                context.SaveChanges();
                return user.UserID;
            }
        }
    }
}
