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
            _pizzaManagement = new SimplePizzaManagement();
            _dataAccess = new SQLFacade(new UnitOfWork());
            _pizzaManagement.SetDataSource = _dataAccess;
        }

        [Fact]
        public void CreateGetAndRemoveRestaurantTest()
        {
            #region Arrange

            Restaurant restaurant =
               new Restaurant()
               {
                   Name = "PizzaHut",
               };

            #endregion

            #region Act

            _pizzaManagement.AddRestaurant(restaurant);
            _pizzaManagement.Save();
            var result = _pizzaManagement.GetRestaurantByName(restaurant.Name);

            #region Cleanup

            _dataAccess.RemoveRestaurantByID(result.RestaurantID);
            _dataAccess.Save();

            #endregion

            #endregion

            #region Assert

            Assert.True(result != null);
            Assert.True(result.Name == restaurant.Name);

            #endregion           
        }
    }
}
