using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.Common.Models.PizzaManagement;
using Landeeyo.Pizza.DataAccessLayer.EntityConfig;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Landeeyo.Pizza.DataAccessLayer
{
    public class SQLFacade : IDataAccess
    {
        private IUnitOfWork _unitOfWork;

        public SQLFacade(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Save()
        {
            _unitOfWork.Save();
        }

        #region Account control

        public User GetUserByLogin(string login)
        {
            return _unitOfWork.UserRepository.Get(x => x.Login == login).SingleOrDefault();
        }

        public void AddUser(User user)
        {
            _unitOfWork.UserRepository.Insert(user);
        }

        public void RemoveUserByID(int userID)
        {
            _unitOfWork.UserRepository.Delete(userID);
        }

        public void UpdateUser(User user)
        {
            _unitOfWork.UserRepository.Update(user);
        }

        public User GetUserByID(int userID)
        {
            return _unitOfWork.UserRepository.GetByID(userID);
        }

        #endregion

        #region Pizza management

        public void AddPizza(Common.Models.PizzaManagement.Pizza pizza)
        {
            _unitOfWork.PizzaRepository.Insert(pizza);
        }

        public void RemovePizzaByID(int pizzaID)
        {
            _unitOfWork.PizzaRepository.Delete(pizzaID);
        }

        public void UpdatePizza(Common.Models.PizzaManagement.Pizza pizza)
        {
            _unitOfWork.PizzaRepository.Update(pizza);
        }

        public Common.Models.PizzaManagement.Pizza GetPizzaByID(int pizzaID)
        {
            return _unitOfWork.PizzaRepository.GetByID(pizzaID);
        }

        #endregion

        #region Restaurant management

        public void AddRestaurant(Restaurant restaurant)
        {
            _unitOfWork.RestaurantRepository.Insert(restaurant);
        }

        public Restaurant GetRestaurantByName(string name)
        {
            return _unitOfWork.RestaurantRepository.Get(x => x.Name == name).SingleOrDefault();
        }

        public void RemoveRestaurantByID(int restaurantID)
        {
            _unitOfWork.RestaurantRepository.Delete(restaurantID);
        }

        public void UpdateRestaurantByID(Restaurant restaurant)
        {
            _unitOfWork.RestaurantRepository.Update(restaurant);
        }

        #endregion
    }
}
