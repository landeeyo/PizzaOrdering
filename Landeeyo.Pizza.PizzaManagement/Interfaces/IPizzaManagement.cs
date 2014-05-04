using Landeeyo.Pizza.Common.Models.PizzaManagement;
using Landeeyo.Pizza.DataAccessLayer;
using System.Collections.Generic;

namespace Landeeyo.Pizza.PizzaManagement.Interfaces
{
    public interface IPizzaManagement
    {
        void AddPizza(Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza pizza);
        void RemovePizzaByPizzaID(int pizzaID);
        List<Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza> GetPizzaListByRestaurantID(int restaurantID);
        Common.Models.PizzaManagement.Pizza GetPizzaByRestaurantNameAndPizzaName(string restaurant, string pizza);
        void UpdatePizza(Common.Models.PizzaManagement.Pizza pizza);

        void AddRestaurant(Restaurant restaurant);
        void RemoveRestaurantByRestaurantID(int restaurantID);
        Restaurant GetRestaurantByName(string restaurantName);

        IDataAccess SetDataSource { set; }
        void Save();
    }
}
