using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.Common.Models.PizzaManagement;
using Landeeyo.Pizza.DataAccessLayer.EntityConfig;
using Landeeyo.Pizza.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Landeeyo.Pizza.DataAccessLayer
{
    public class SQLFacade : IDataAccess
    {
        private IUserRepository _userRepository;
        private UnitOfWork _unitOfWork;

        public SQLFacade()
        {
            _userRepository = new UserRepository(new DatabaseContext());
            _unitOfWork = new UnitOfWork();
        }

        #region Account control layer

        public User GetUserByLogin(string login)
        {
            throw new NotImplementedException();
        }

        public void AddUser(User user)
        {
            _userRepository.Insert(user);
        }

        public void RemoveUserByID(int userID)
        {
            _userRepository.Delete(userID);
        }

        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }

        public User GetUserByID(int userID)
        {
            return _userRepository.GetByID(userID);
        }

        #endregion

        //#region Pizza management layer

        //public void AddPizza(Common.Models.PizzaManagement.Pizza pizza)
        //{
        //    using (var context = new DatabaseContext())
        //    {
        //        pizza.Restaurant = context.Restaurants.Where(x => x.RestaurantID == pizza.RestaurantID).SingleOrDefault();
        //        context.Pizzas.Add(pizza);
        //        context.SaveChanges();
        //    }
        //}

        //public void RemovePizzaByPizzaID(int pizzaID)
        //{
        //    using (var context = new DatabaseContext())
        //    {
        //        context.Pizzas.Remove(context.Pizzas.Where(x => x.PizzaID == pizzaID).SingleOrDefault());
        //        context.SaveChanges();
        //    }
        //}

        //public List<Common.Models.PizzaManagement.Pizza> GetPizzaListByRestaurantID(int restaurantID)
        //{
        //    using (var context = new DatabaseContext())
        //    {
        //        return context.Pizzas.Where(x => x.RestaurantID == restaurantID).ToList();
        //    }
        //}

        //public void AddRestaurant(Common.Models.PizzaManagement.Restaurant restaurant)
        //{
        //    using (var context = new DatabaseContext())
        //    {
        //        context.Restaurants.Add(restaurant);
        //        context.SaveChanges();
        //    }
        //}

        //public void RemoveRestaurantByRestaurantID(int restaurantID)
        //{
        //    using (var context = new DatabaseContext())
        //    {
        //        context.Restaurants.Remove(context.Restaurants.Where(x => x.RestaurantID == restaurantID).SingleOrDefault());
        //        context.SaveChanges();
        //    }
        //}

        //public Common.Models.PizzaManagement.Restaurant GetRestaurantByName(string restaurantName)
        //{
        //    using (var context = new DatabaseContext())
        //    {
        //        return context.Restaurants.Where(x => x.Name == restaurantName).SingleOrDefault();
        //    }
        //}

        //#endregion


        #region Restaurant management layer

        public void AddRestaurant(Restaurant restaurant)
        {
            _unitOfWork.RestaurantRepository.Insert(restaurant);
        }

        public Restaurant GetRestaurantByName(string name)
        {
            return _unitOfWork.RestaurantRepository.Get(x => x.Name == name).SingleOrDefault();
        }

        #endregion

        public void Save()
        {
            _unitOfWork.Save();
        }
    }
}
