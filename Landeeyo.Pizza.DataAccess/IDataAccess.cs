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
    /// <summary>
    /// This layer gives higher order layers bare access to abstract database without any validation or business logic included (rather pure CRUD).
    /// </summary>
    public interface IDataAccess
    {
        #region Global

        void Save();
        void BeginTransaction();
        void Rollback();
        void Commit();

        #endregion

        #region Account control

        User GetUserByLogin(string login);
        void AddUser(User user);
        void RemoveUserByID(int userID);
        void UpdateUser(User user);
        User GetUserByID(int userID);

        #endregion

        #region Pizza management

        void AddPizza(Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza pizza);
        void RemovePizzaByID(int pizzaID);
        void UpdatePizza(Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza pizza);
        Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza GetPizzaByID(int pizzaID);
        List<Common.Models.PizzaManagement.Pizza> GetPizzaListByRestaurantID(int restaurantID);
        Common.Models.PizzaManagement.Pizza GetPizzaByRestaurantNameAndPizzaName(string restaurant, string pizza);

        #endregion        

        #region Restaurant management

        void AddRestaurant(Restaurant restaurant);
        void RemoveRestaurantByID(int restaurantID);
        void UpdateRestaurant(Restaurant restaurant);
        Restaurant GetRestaurantByName(string name);

        #endregion
    }
}
