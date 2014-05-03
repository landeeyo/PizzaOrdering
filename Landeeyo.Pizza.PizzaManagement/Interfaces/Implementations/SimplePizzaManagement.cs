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

        public void Save()
        {
            _dataSource.Save();
        }

        public DataAccessLayer.IDataAccess SetDataSource
        {
            set { _dataSource = value; }
        }

        public void AddPizza(Common.Models.PizzaManagement.Pizza pizza)
        {
            try
            {
                //_dataSource.AddPizza(pizza);
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
                //_dataSource.RemovePizzaByPizzaID(pizzaID);
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
                //return _dataSource.GetPizzaListByRestaurantID(restaurantID);
                return null;
            }
            catch (Exception ex)
            {
                throw new PizzaException(ex);
            }
        }

        public void AddRestaurant(Common.Models.PizzaManagement.Restaurant restaurant)
        {
            try
            {
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
                //_dataSource.RemoveRestaurantByRestaurantID(restaurantID);
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
    }
}
