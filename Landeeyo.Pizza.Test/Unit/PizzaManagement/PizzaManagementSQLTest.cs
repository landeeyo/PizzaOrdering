using Landeeyo.Pizza.Common.Models.PizzaManagement;
using Landeeyo.Pizza.DataAccessLayer;
using Landeeyo.Pizza.PizzaManagement.Interfaces;
using Landeeyo.Pizza.PizzaManagement.Interfaces.Implementations;
using Xunit;
using System.Linq;

namespace Landeeyo.Pizza.Test.Unit.PizzaManagement
{
    public class PizzaManagementSQLTest
    {
        private IPizzaManagement _pizzaManagement;
        private IDataAccess _dataAccess;

        public PizzaManagementSQLTest()
        {
            _dataAccess = new SQLDataAccess(new UnitOfWork());
            _pizzaManagement = new SimplePizzaManagement(_dataAccess);
        }

        [Fact]
        public void CRUDRestaurantTest()
        {
            #region Arrange

            Restaurant restaurant =
               new Restaurant()
               {
                   Name = "PizzaHut",
               };
            string newName = "Telepizza";

            #endregion

            #region Act

            _pizzaManagement.BeginTransaction();

            //Create & read
            _pizzaManagement.AddRestaurant(restaurant);
            _pizzaManagement.Save();
            int id = restaurant.RestaurantID;
            var read = _pizzaManagement.GetRestaurantByName(restaurant.Name);

            //Update
            restaurant.Name = newName;
            _pizzaManagement.UpdateRestaurant(restaurant);
            _pizzaManagement.Save();
            var read2 = _pizzaManagement.GetRestaurantByName(restaurant.Name);

            //Delete
            _pizzaManagement.RemoveRestaurantByRestaurantID(restaurant.RestaurantID);
            _pizzaManagement.Save();
            var read3 = _pizzaManagement.GetRestaurantByName(restaurant.Name);

            _pizzaManagement.Rollback();

            #endregion

            #region Assert

            Assert.True(id > 0);
            Assert.True(read != null && read.RestaurantID > 0 && read.CreateDate.HasValue);
            Assert.True(read2 != null && read2.RestaurantID > 0 && read2.Name == newName && read2.CreateDate.HasValue);
            Assert.True(read3 == null);

            #endregion
        }

        [Fact]
        public void CRUDPizzaTest()
        {
            #region Arrange

            Restaurant restaurant =
               new Restaurant()
               {
                   Name = "PizzaHut",
               };

            var pizza =
                new Common.Models.PizzaManagement.Pizza()
                {
                    Name = "Capriciosa",
                    Price = 19.99,
                };

            double newPrice = 25.5;

            #endregion

            #region Act

            _pizzaManagement.BeginTransaction();

            _pizzaManagement.AddRestaurant(restaurant);
            _pizzaManagement.Save();

            //Create and read
            pizza.RestaurantID = restaurant.RestaurantID;
            _pizzaManagement.AddPizza(pizza);
            _pizzaManagement.Save();

            int id = pizza.PizzaID;
            var getPizza1 = _pizzaManagement.GetPizzaByRestaurantNameAndPizzaName(restaurant.Name, pizza.Name);
            var getPizza2 = _pizzaManagement.GetPizzaListByRestaurantID(restaurant.RestaurantID).Where(x => x.Name == pizza.Name).SingleOrDefault();
            var shouldBeEqual1 = TestHelper.ArePropertiesEqual(pizza, getPizza1);
            var shouldBeEqual2 = TestHelper.ArePropertiesEqual(getPizza1, getPizza2);

            //Update 
            getPizza1.Price = newPrice;
            _pizzaManagement.UpdatePizza(getPizza1);
            _pizzaManagement.Save();
            var getpizza2 = _pizzaManagement.GetPizzaByRestaurantNameAndPizzaName(getPizza1.Name, restaurant.Name);

            //Delete
            _pizzaManagement.RemovePizzaByPizzaID(pizza.PizzaID);
            _pizzaManagement.Save();
            var shouldBeNull = _pizzaManagement.GetPizzaByRestaurantNameAndPizzaName(restaurant.Name, pizza.Name);

            _pizzaManagement.Rollback();

            #endregion

            #region Assert

            Assert.True(id > 0);
            Assert.True(getPizza1 != null && getPizza1.CreateDate.HasValue);
            Assert.True(getPizza2 != null);
            Assert.True(getPizza2.Price == newPrice);
            Assert.True(shouldBeEqual1);
            Assert.True(shouldBeEqual2);
            Assert.True(shouldBeNull == null);

            #endregion
        }
    }
}
