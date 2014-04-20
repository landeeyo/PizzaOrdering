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
        /// <summary>
        /// Gets user by login
        /// </summary>
        /// <param name="login">Login</param>
        /// <returns>User object</returns>
        User GetUserByLogin(string login);

        /// <summary>
        /// Adds user
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>If user exists null, if user added id, else exception</returns>
        int? AddUser(User user);
    }
}
