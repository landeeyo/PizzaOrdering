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
            _pizzaManagement = new SimplePizzaManagement();
            _dataAccess = new SQLFacade(new UnitOfWork());
            _pizzaManagement.SetDataSource = _dataAccess;
        }

        [Fact]
        public void CRUTRestaurantTransactTest()
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

            _pizzaManagement.AddRestaurant(restaurant);
            _pizzaManagement.Save();
            int id = restaurant.RestaurantID;
            var readed = _pizzaManagement.GetRestaurantByName(restaurant.Name);
            restaurant.Name = newName;
            _pizzaManagement.UpdateRestaurant(restaurant);
            _pizzaManagement.Save();
            var readed2 = _pizzaManagement.GetRestaurantByName(restaurant.Name);

            _pizzaManagement.Rollback();

            #endregion

            #region Assert

            Assert.True(id > 0);
            Assert.True(readed != null && readed.RestaurantID > 0);
            Assert.True(readed2 != null && readed2.RestaurantID > 0 && readed2.Name == newName);

            #endregion
        }

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

            try
            {
                #region Act

                //Create and read
                _pizzaManagement.AddRestaurant(restaurant);
                _pizzaManagement.Save();
                var getRestaurant = _pizzaManagement.GetRestaurantByName(restaurant.Name);

                //Update 
                getRestaurant.Name = newName;
                _pizzaManagement.UpdateRestaurant(getRestaurant);
                _pizzaManagement.Save();
                var getRestaurant2 = _pizzaManagement.GetRestaurantByName(newName);

                //Delete
                _pizzaManagement.RemoveRestaurantByRestaurantID(getRestaurant2.RestaurantID);
                _pizzaManagement.Save();
                var getRestaurant3 = _pizzaManagement.GetRestaurantByName(getRestaurant2.Name);

                #endregion

                #region Assert

                Assert.True(getRestaurant != null);
                Assert.True(getRestaurant.RestaurantID > 0);
                Assert.True(getRestaurant.Name == restaurant.Name);
                Assert.True(getRestaurant2.Name == newName);
                Assert.True(getRestaurant3 == null);

                #endregion

            }
            catch
            {
                #region Cleanup

                _dataAccess.RemoveRestaurantByID(_dataAccess.GetRestaurantByName(newName).RestaurantID);
                _dataAccess.Save();

                #endregion
            }
        }


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

            try
            {
                #region Act

                #region Prepare

                _pizzaManagement.AddRestaurant(restaurant);
                _pizzaManagement.Save();

                #endregion

                #region Act

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

                #endregion

                #endregion

                #region Assert

                Assert.True(id > 0);
                Assert.True(getPizza1 != null);
                Assert.True(getPizza2 != null);
                Assert.True(getPizza2.Price == newPrice);
                Assert.True(shouldBeEqual1);
                Assert.True(shouldBeEqual2);
                Assert.True(shouldBeNull == null);

                #endregion
            }
            catch
            {
                #region Cleanup

                _dataAccess.RemovePizzaByID(pizza.PizzaID);
                _dataAccess.RemoveRestaurantByID(restaurant.RestaurantID);
                _dataAccess.Save();

                #endregion
            }

        }
    }
}
