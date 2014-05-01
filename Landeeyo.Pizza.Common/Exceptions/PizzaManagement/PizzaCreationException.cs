using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.Common.Exceptions.PizzaManagement
{
    public class PizzaCreationException : ApplicationException
    {
        public Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza GetPizza { get { return _pizza; } }
        private Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza _pizza;

        public PizzaCreationException(Landeeyo.Pizza.Common.Models.PizzaManagement.Pizza pizza)
        {
            _pizza = pizza;
        }
    }
}
