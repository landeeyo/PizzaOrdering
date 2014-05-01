﻿using Landeeyo.Pizza.Common.Models.PizzaManagement;
using System.Collections.Generic;

namespace Landeeyo.Pizza.PizzaManagement.Interfaces
{
    public interface IPizzaManagement
    {
        int? AddPizza(Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza pizza);
        List<Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza> GetPizzaListByRestaurantID(int restaurantID);

        int? AddRestaurant(Restaurant restaurant);
        Restaurant GetRestaurantByName(string restaurantName);
    }
}
