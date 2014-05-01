using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.Common.Exceptions.PizzaManagement
{
    public class RestaurantException : PizzaRootException
    {
        public RestaurantException(Exception ex) : base(ex) { }
    }
}
