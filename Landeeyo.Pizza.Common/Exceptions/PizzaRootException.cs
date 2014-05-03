using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.Common.Exceptions
{
    public class PizzaRootException : ApplicationException
    {
        public Exception Exception { get; set; }
        public PizzaRootException(Exception ex)
        {
            this.Exception = ex;
        }
        public PizzaRootException() { }
    }
}
