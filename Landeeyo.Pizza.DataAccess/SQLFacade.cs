﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer.EntityConfig;
using Landeeyo.Pizza.Common.Exceptions.AccountControl;
using Landeeyo.Pizza.Common.Exceptions.PizzaManagement;

namespace Landeeyo.Pizza.DataAccessLayer
{
    public class SQLFacade : IDataAccess
    {
        public User GetUserByLogin(string login)
        {
            using (var context = new DatabaseContext())
            {
                return context.Users.Where(x => x.Login == login).SingleOrDefault();
            }
        }

        public int AddUser(User user)
        {
            using (var context = new DatabaseContext())
            {
                if (context.Users.Where(x => x.Login == user.Login).SingleOrDefault() != null)
                {
                    throw new UserExistsException();
                }
                context.Users.Add(user);
                context.SaveChanges();
                return user.UserID;
            }
        }

        public void AddPizza(Common.Models.PizzaManagement.Pizza pizza)
        {
            using (var context = new DatabaseContext())
            {
                var exists = from p in context.Pizzas
                             where p.Name == pizza.Name && p.RestaurantID == pizza.RestaurantID
                             select p;
                var elem = exists.FirstOrDefault();
                if (elem != null)
                {
                    throw new PizzaCreationException(pizza);
                }
                context.Pizzas.Add(pizza);
                context.SaveChanges();
            }
        }


        public void RemovePizzaByPizzaID(int pizzaID)
        {
            using (var context = new DatabaseContext())
            {
                var exists = from p in context.Pizzas
                             where p.PizzaID == pizzaID
                             select p;
                var elem = exists.FirstOrDefault();
                if (elem != null)
                {
                    context.Pizzas.Remove(elem);
                    context.SaveChanges();
                }
                else
                {
                    throw new PizzaRemovalException(pizzaID);
                }
            }
        }

        public List<Common.Models.PizzaManagement.Pizza> GetPizzaListByRestaurantID(int restaurantID)
        {
            throw new NotImplementedException();
        }

        public void AddRestaurant(Common.Models.PizzaManagement.Restaurant restaurant)
        {
            try
            {
            }
            catch (Exception ex)
            {
            }
        }

        public void RemoveRestaurantByRestaurantID(int restaurantID)
        {
            throw new NotImplementedException();
        }

        public Common.Models.PizzaManagement.Restaurant GetRestaurantByName(string restaurantName)
        {
            throw new NotImplementedException();
        }
    }
}
