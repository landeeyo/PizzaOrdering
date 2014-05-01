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

        public void AddPizza(Common.Models.PizzaManagement.Pizza pizza)
        {
            if (pizza != null)
            {
                _dataSource.AddPizza(pizza);
            }
            else
            {
                throw new PizzaCreationException(pizza);
            }
        }

        public void RemovePizzaByPizzaID(int pizzaID)
        {
            _dataSource.RemovePizzaByPizzaID(pizzaID);
        }

        public List<Common.Models.PizzaManagement.Pizza> GetPizzaListByRestaurantID(int restaurantID)
        {
            throw new NotImplementedException();
        }

        public void AddRestaurant(Common.Models.PizzaManagement.Restaurant restaurant)
        {
            if (restaurant != null)
            {
                _dataSource.AddRestaurant(restaurant);
            }
            else
            {
                throw new RestaurantCreationException(restaurant);
            }
        }

        public void RemoveRestaurantByRestaurantID(int restaurantID)
        {
            _dataSource.RemoveRestaurantByRestaurantID(restaurantID);
        }

        public Common.Models.PizzaManagement.Restaurant GetRestaurantByName(string restaurantName)
        {
            return _dataSource.GetRestaurantByName(restaurantName);
        }
    }
}
