using System;
using Landeeyo.Pizza.Common.Models.PizzaManagement;
using Landeeyo.Pizza.Common.Models.AccountControl;

namespace Landeeyo.Pizza.DataAccessLayer
{
    public interface IUnitOfWork
    {
        void Dispose();
        void Save();
        void BeginTransaction();
        void Rollback();
        void Commit();

        GenericRepository<Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza> PizzaRepository { get; }
        GenericRepository<Restaurant> RestaurantRepository { get; }
        GenericRepository<User> UserRepository { get; }
    }
}
