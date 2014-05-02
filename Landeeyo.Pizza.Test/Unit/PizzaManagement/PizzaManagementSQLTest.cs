using Landeeyo.Pizza.Common.Models.PizzaManagement;
using Landeeyo.Pizza.DataAccessLayer;
using Landeeyo.Pizza.PizzaManagement.Interfaces;
using Landeeyo.Pizza.PizzaManagement.Interfaces.Implementations;
using Ninject;
using System;
using Xunit;

namespace Landeeyo.Pizza.Test.Unit.PizzaManagement
{
    public class PizzaManagementSQLTest
    {
        private IPizzaManagement _pizzaManagement;
        IKernel _ninjectKernel;

        public PizzaManagementSQLTest()
        {
            _ninjectKernel = new StandardKernel();
            _ninjectKernel.Bind<IPizzaManagement>().To<SimplePizzaManagement>();
            _ninjectKernel.Bind<IDataAccess>().To<SQLFacade>();
        }

        [Fact]
        public void CreateGetAndRemoveRestaurantTest()
        {
            //arrange
            _pizzaManagement = _ninjectKernel.Get<IPizzaManagement>();
            _pizzaManagement.SetDataSource = _ninjectKernel.Get<IDataAccess>();

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
            Assert.True(TestHelper.ArePropertiesEqual(restaurant, restaurant2));
        }

        [Fact]
        public void CreateAndRemovePizzaTest()
        {
            //arrange
            _pizzaManagement = _ninjectKernel.Get<IPizzaManagement>();
            _pizzaManagement.SetDataSource = _ninjectKernel.Get<IDataAccess>();

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
                   RestaurantID = restaurant.RestaurantID,
               };

            //act
            _pizzaManagement.AddPizza(pizza);
            _pizzaManagement.RemovePizzaByPizzaID(pizza.PizzaID);
            _pizzaManagement.RemoveRestaurantByRestaurantID(restaurant.RestaurantID);

            //assert
            Assert.True(pizza.PizzaID > 0);
        }
    }
}
