using Landeeyo.Pizza.Common.Models.PizzaManagement;
using Landeeyo.Pizza.DataAccessLayer;
using System.Collections.Generic;

namespace Landeeyo.Pizza.PizzaManagement.Interfaces
{
    public interface IPizzaManagement
    {
        int AddPizza(Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza pizza);
        bool RemovePizzaByPizzaID(int pizzaID);
        List<Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza> GetPizzaListByRestaurantID(int restaurantID);

        int AddRestaurant(Restaurant restaurant);
        bool RemoveRestaurantByRestaurantID(int restaurantID);
        Restaurant GetRestaurantByName(string restaurantName);

        IDataAccess SetDataSource { set; }
    }
}
