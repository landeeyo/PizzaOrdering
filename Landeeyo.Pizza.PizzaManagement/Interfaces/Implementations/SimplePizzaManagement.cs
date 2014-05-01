using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.PizzaManagement.Interfaces.Implementations
{
    public class SimplePizzaManagement : IPizzaManagement
    {
        public int AddPizza(Common.Models.PizzaManagement.Pizza pizza)
        {
            throw new NotImplementedException();
        }

        public List<Common.Models.PizzaManagement.Pizza> GetPizzaListByRestaurantID(int restaurantID)
        {
            throw new NotImplementedException();
        }

        public bool RemovePizzaByPizzaID(int pizzaID)
        {
            throw new NotImplementedException();
        }

        public int AddRestaurant(Common.Models.PizzaManagement.Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public Common.Models.PizzaManagement.Restaurant GetRestaurantByName(string restaurantName)
        {
            throw new NotImplementedException();
        }

        public bool RemoveRestaurantByRestaurantID(int restaurantID)
        {
            throw new NotImplementedException();
        }

        public DataAccessLayer.IDataAccess SetDataSource
        {
            set { throw new NotImplementedException(); }
        }
    }
}
