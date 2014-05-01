﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Landeeyo.Pizza.Test
{
    public static class TestHelper
    {
        public static bool ArePropertiesEqual(object a, object b)
        {
            if (a.GetType() != b.GetType())
            {
                return false;
            }

            var classType = a.GetType();
            var properties = a.GetType().GetProperties();
            foreach (var property in properties)
            {
                var firstValue = classType.GetProperty(property.Name).GetValue(a, null);
                var secondValue = classType.GetProperty(property.Name).GetValue(b, null);
                if (!Object.Equals(firstValue, secondValue))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
