using Landeeyo.Pizza.Common.Exceptions.PizzaManagement;
using Landeeyo.Pizza.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.PizzaManagement.Interfaces.Implementations
{
    public class SimplePizzaManagement : IPizzaManagement
    {
        IDataAccess _dataSource;

        public DataAccessLayer.IDataAccess SetDataSource
        {
            set { _dataSource = value; }
        }

        public void Save()
        {
            _dataSource.Save();
        }

        #region Transactions

        public void BeginTransaction()
        {
            _dataSource.BeginTransaction();
        }

        public void Commit()
        {
            _dataSource.Commit();
        }

        public void Rollback()
        {
            _dataSource.Rollback();
        }

        #endregion

        #region Pizza

        public void AddPizza(Common.Models.PizzaManagement.Pizza pizza)
        {
            try
            {
                pizza.CreateDate = DateTime.Now;
                _dataSource.AddPizza(pizza);
            }
            catch (Exception ex)
            {
                throw new PizzaException(ex);
            }
        }

        public void RemovePizzaByPizzaID(int pizzaID)
        {
            try
            {
                _dataSource.RemovePizzaByID(pizzaID);
            }
            catch (Exception ex)
            {
                throw new PizzaException(ex);
            }
        }

        public List<Common.Models.PizzaManagement.Pizza> GetPizzaListByRestaurantID(int restaurantID)
        {
            try
            {
                return _dataSource.GetPizzaListByRestaurantID(restaurantID);
            }
            catch (Exception ex)
            {
                throw new PizzaException(ex);
            }
        }

        public Common.Models.PizzaManagement.Pizza GetPizzaByRestaurantNameAndPizzaName(string restaurant, string pizza)
        {
            try
            {
                return _dataSource.GetPizzaByRestaurantNameAndPizzaName(restaurant, pizza);
            }
            catch (Exception ex)
            {
                throw new PizzaException(ex);
            }
        }

        public void UpdatePizza(Common.Models.PizzaManagement.Pizza pizza)
        {
            _dataSource.UpdatePizza(pizza);
        }

        #endregion

        #region Restaurant

        public void AddRestaurant(Common.Models.PizzaManagement.Restaurant restaurant)
        {
            try
            {
                restaurant.CreateDate = DateTime.Now;
                _dataSource.AddRestaurant(restaurant);
            }
            catch (Exception ex)
            {
                throw new RestaurantException(ex);
            }
        }

        public void RemoveRestaurantByRestaurantID(int restaurantID)
        {
            try
            {
                _dataSource.RemoveRestaurantByID(restaurantID);
            }
            catch (Exception ex)
            {
                throw new RestaurantException(ex);
            }
        }

        public Common.Models.PizzaManagement.Restaurant GetRestaurantByName(string restaurantName)
        {
            try
            {
                return _dataSource.GetRestaurantByName(restaurantName);
            }
            catch (Exception ex)
            {
                throw new RestaurantException(ex);
            }
        }

        public void UpdateRestaurant(Common.Models.PizzaManagement.Restaurant restaurant)
        {
            try
            {
                _dataSource.UpdateRestaurant(restaurant);
            }
            catch (Exception ex)
            {
                throw new RestaurantException(ex);
            }
        }

        #endregion
    }
}
