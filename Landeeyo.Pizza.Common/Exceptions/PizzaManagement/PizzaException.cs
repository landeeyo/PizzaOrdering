using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.Common.Exceptions.PizzaManagement
{
    public class PizzaException : PizzaRootException
    {
        public PizzaException(Exception ex) : base(ex) { }
    }
}
