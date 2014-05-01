using Landeeyo.Pizza.Common.Models.PizzaManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.Common.Exceptions.PizzaManagement
{
    public class RestaurantCreationException : ApplicationException
    {
        public Restaurant GetRestaurant { get { return _restaurant; } }
        private Restaurant _restaurant;

        public RestaurantCreationException(Restaurant restaurant)
        {
            _restaurant = restaurant;
        }
    }
}
