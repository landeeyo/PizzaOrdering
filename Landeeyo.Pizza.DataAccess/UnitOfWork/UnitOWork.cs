using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.Common.Models.PizzaManagement;
using Landeeyo.Pizza.DataAccessLayer.EntityConfig;
using System;
using System.Data;
using System.Data.Entity;

namespace Landeeyo.Pizza.DataAccessLayer
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        private DatabaseContext _context = new DatabaseContext();
        private DbContextTransaction _transaction;
        
        #region Repositories

        private GenericRepository<User> _userRepository;
        private GenericRepository<Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza> _pizzaRepository;
        private GenericRepository<Restaurant> _restaurantRepository;

        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                {
                    this._userRepository = new GenericRepository<User>(_context);
                }
                return _userRepository;
            }
        }

        public GenericRepository<Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza> PizzaRepository
        {
            get
            {

                if (this._pizzaRepository == null)
                {
                    this._pizzaRepository = new GenericRepository<Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza>(_context);
                }
                return _pizzaRepository;
            }
        }

        public GenericRepository<Restaurant> RestaurantRepository
        {
            get
            {

                if (this._restaurantRepository == null)
                {
                    this._restaurantRepository = new GenericRepository<Restaurant>(_context);
                }
                return _restaurantRepository;
            }
        }

        #endregion

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


        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
        }

        public void Rollback()
        {
            _transaction.Rollback();
        }

        public void Commit()
        {
            _transaction.Commit();
        }
    }
}
