using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer.EntityConfig;
using Landeeyo.Pizza.Common.Exceptions.AccountControl;
using Landeeyo.Pizza.Common.Exceptions.PizzaManagement;

namespace Landeeyo.Pizza.DataAccessLayer
{
    public class SQLFacade : IDataAccess
    {
        #region Account control layer

        public User GetUserByLogin(string login)
        {
            using (var context = new DatabaseContext())
            {
                return context.Users.Where(x => x.Login == login).SingleOrDefault();
            }
        }

        public void AddUser(User user)
        {
            using (var context = new DatabaseContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        #endregion

        #region Pizza management layer

        public void AddPizza(Common.Models.PizzaManagement.Pizza pizza)
        {
            using (var context = new DatabaseContext())
            {
                pizza.Restaurant = context.Restaurants.Where(x => x.RestaurantID == pizza.RestaurantID).SingleOrDefault();
                context.Pizzas.Add(pizza);
                context.SaveChanges();
            }
        }

        public void RemovePizzaByPizzaID(int pizzaID)
        {
            using (var context = new DatabaseContext())
            {
                context.Pizzas.Remove(context.Pizzas.Where(x => x.PizzaID == pizzaID).SingleOrDefault());
                context.SaveChanges();
            }
        }

        public List<Common.Models.PizzaManagement.Pizza> GetPizzaListByRestaurantID(int restaurantID)
        {
            using (var context = new DatabaseContext())
            {
                return context.Pizzas.Where(x => x.RestaurantID == restaurantID).ToList();
            }
        }

        public void AddRestaurant(Common.Models.PizzaManagement.Restaurant restaurant)
        {
            using (var context = new DatabaseContext())
            {
                context.Restaurants.Add(restaurant);
                context.SaveChanges();
            }
        }

        public void RemoveRestaurantByRestaurantID(int restaurantID)
        {
            using (var context = new DatabaseContext())
            {
                context.Restaurants.Remove(context.Restaurants.Where(x => x.RestaurantID == restaurantID).SingleOrDefault());
                context.SaveChanges();
            }
        }

        public Common.Models.PizzaManagement.Restaurant GetRestaurantByName(string restaurantName)
        {
            using (var context = new DatabaseContext())
            {
                return context.Restaurants.Where(x => x.Name == restaurantName).SingleOrDefault();
            }
        }

        #endregion
    }
}
