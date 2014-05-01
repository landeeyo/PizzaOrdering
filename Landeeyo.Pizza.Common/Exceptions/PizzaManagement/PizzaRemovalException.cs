using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.Common.Exceptions.PizzaManagement
{
    public class PizzaRemovalException : ApplicationException
    {
        public int GetPizzaID { get { return _pizzaID; } }
        int _pizzaID;

        public PizzaRemovalException(int pizzaID)
        {
            _pizzaID = pizzaID;
        }
    }
}
