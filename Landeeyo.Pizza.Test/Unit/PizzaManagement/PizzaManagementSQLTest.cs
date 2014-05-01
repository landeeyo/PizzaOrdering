using Landeeyo.Pizza.Common.Models.PizzaManagement;
using Landeeyo.Pizza.DataAccessLayer;
using Landeeyo.Pizza.PizzaManagement.Interfaces;
using Landeeyo.Pizza.PizzaManagement.Interfaces.Implementations;
using Xunit;

namespace Landeeyo.Pizza.Test.Unit.PizzaManagement
{
    public class PizzaManagementSQLTest
    {
        private IPizzaManagement _pizzaManagement;
        private IDataAccess _dataAccess;

        public PizzaManagementSQLTest()
        {
        }

        [Fact]
        public void CreateGetAndRemoveRestaurantTest()
        {
            //arrange
            _pizzaManagement = new SimplePizzaManagement();
            _pizzaManagement.SetDataSource = new SQLFacade();

            Restaurant restaurant =
               new Restaurant()
               {
                   Name = "PizzaHut",
               };

            //act
            int restaurantID = _pizzaManagement.AddRestaurant(restaurant);
            Restaurant restaurant2 = _pizzaManagement.GetRestaurantByName(restaurant.Name);
            bool result = _pizzaManagement.RemoveRestaurantByRestaurantID(restaurantID);

            //assert
            Assert.True(restaurantID > 0);
            Assert.True(result);
            Assert.Equal(restaurant, restaurant2);
        }

        [Fact]
        public void CreateAndRemovePizzaTest()
        {
            //arrange
            _pizzaManagement = new SimplePizzaManagement();
            _pizzaManagement.SetDataSource = new SQLFacade();

            Restaurant restaurant =
               new Restaurant()
               {
                   Name = "PizzaHut",
               };

            int restaurantID = _pizzaManagement.AddRestaurant(restaurant);

            Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza pizza =
               new Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza()
               {
                   Name = "Capriciosa",
                   Price = 21,
                   RestaurantID = restaurantID
               };

            //act
            int pizzaID = _pizzaManagement.AddPizza(pizza);
            bool result = _pizzaManagement.RemovePizzaByPizzaID(pizzaID);

            //assert
            Assert.True(pizzaID > 0);
            Assert.True(result);
        }

    }
}
