using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.Common.Models.PizzaManagement;
using Landeeyo.Pizza.DataAccessLayer.EntityConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.DataAccessLayer
{
    public interface IDataAccess
    {
        #region Global

        void Save();

        #endregion

        #region Account control layer

        User GetUserByLogin(string login);
        void AddUser(User user);
        void RemoveUserByID(int userID);
        void UpdateUser(User user);
        User GetUserByID(int userID);

        #endregion

        #region Pizza management layer

        //void AddPizza(Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza pizza);
        //void RemovePizzaByPizzaID(int pizzaID);
        //List<Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza> GetPizzaListByRestaurantID(int restaurantID);

        //void AddRestaurant(Restaurant restaurant);
        //void RemoveRestaurantByRestaurantID(int restaurantID);
        //Restaurant GetRestaurantByName(string restaurantName);

        #endregion        

        #region Restaurant management layer

        void AddRestaurant(Restaurant restaurant);
        Restaurant GetRestaurantByName(string name);

        #endregion
    }
}
