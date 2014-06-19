using Landeeyo.Pizza.Common.Models.PizzaManagement;
using Landeeyo.Pizza.DataAccessLayer;
using System.Collections.Generic;

namespace Landeeyo.Pizza.PizzaManagement.Interfaces
{
    /// <summary>
    /// This layer is responsible for data validation (for example not allow to duplicate restaurants name)
    /// and filling unobvious fields (create date). It provides higher layers robust access to business data.
    /// </summary>
    public interface IPizzaManagement
    {
        void AddPizza(Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza pizza);
        void RemovePizzaByPizzaID(int pizzaID);
        List<Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza> GetPizzaListByRestaurantID(int restaurantID);
        Common.Models.PizzaManagement.Pizza GetPizzaByRestaurantNameAndPizzaName(string restaurant, string pizza);
        void UpdatePizza(Common.Models.PizzaManagement.Pizza pizza);

        void AddRestaurant(Restaurant restaurant);
        void RemoveRestaurantByRestaurantID(int restaurantID);
        void UpdateRestaurant(Restaurant restaurant);
        Restaurant GetRestaurantByName(string restaurantName);

        void Save();

        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
