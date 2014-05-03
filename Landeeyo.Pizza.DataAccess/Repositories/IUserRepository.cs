using Landeeyo.Pizza.Common.Models.AccountControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.DataAccessLayer.Repositories
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetStudents();
        User GetByID(int studentId);
        void Insert(User user);
        void Delete(int userID);
        void Update(User user);
        void Save();
    }
}
