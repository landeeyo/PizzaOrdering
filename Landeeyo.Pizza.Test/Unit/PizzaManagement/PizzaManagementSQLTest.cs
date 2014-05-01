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
            _pizzaManagement.AddRestaurant(restaurant);
            Restaurant restaurant2 = _pizzaManagement.GetRestaurantByName(restaurant.Name);
            _pizzaManagement.RemoveRestaurantByRestaurantID(restaurant.RestaurantID);

            //assert
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

            _pizzaManagement.AddRestaurant(restaurant);

            Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza pizza =
               new Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza()
               {
                   Name = "Capriciosa",
                   Price = 21,
                   RestaurantID = restaurant.RestaurantID
               };

            //act
            _pizzaManagement.AddPizza(pizza);
            _pizzaManagement.RemovePizzaByPizzaID(pizza.PizzaID);

            //assert
            Assert.True(pizza.PizzaID > 0);
        }

    }
}
