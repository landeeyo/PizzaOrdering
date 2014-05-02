using Landeeyo.Pizza.Common.Models.AccountControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.DataAccessLayer.Services
{
    public interface IUserService
    {
        User Add(User user);
        User GetByID(int id);
    }
}
