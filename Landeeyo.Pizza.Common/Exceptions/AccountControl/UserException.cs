using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.Common.Exceptions.AccountControl
{
    public class UserException : PizzaRootException
    {
        public UserException(Exception ex) : base(ex) { }
    }
}
