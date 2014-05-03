using Landeeyo.Pizza.Common.Models.PizzaManagement;
using Landeeyo.Pizza.DataAccessLayer.EntityConfig;
using Landeeyo.Pizza.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.DataAccessLayer
{
    public class UnitOfWork : IDisposable
    {
        private DatabaseContext context = new DatabaseContext();
        private GenericRepository<Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza> pizzaRepository;
        private GenericRepository<Restaurant> restaurantRepository;

        public GenericRepository<Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza> PizzaRepository
        {
            get
            {

                if (this.pizzaRepository == null)
                {
                    this.pizzaRepository = new GenericRepository<Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza>(context);
                }
                return pizzaRepository;
            }
        }

        public GenericRepository<Restaurant> RestaurantRepository
        {
            get
            {

                if (this.restaurantRepository == null)
                {
                    this.restaurantRepository = new GenericRepository<Restaurant>(context);
                }
                return restaurantRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
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
