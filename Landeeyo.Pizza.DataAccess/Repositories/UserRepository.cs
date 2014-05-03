using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.DataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository, IDisposable
    {
        private DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetStudents()
        {
            return _context.Users.ToList();
        }

        public User GetByID(int studentId)
        {
            return _context.Users.Find(studentId);
        }

        public void Insert(User user)
        {
            _context.Users.Add(user);
        }

        public void Delete(int userID)
        {
            User user = _context.Users.Find(userID);
            _context.Users.Remove(user);
        }

        public void Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
