using Landeeyo.Pizza.Common.Models.AccountControl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pattern.Repositories;

namespace Landeeyo.Pizza.DataAccessLayer.Services
{
    public class UserService : IUserService
    {
        private IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public User Add(User user)
        {
            _repository.Insert(user);
            return user;
        }

        public User GetByID(int id)
        {
            return _repository.Find(id);
        }
    }
}
