using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBuddy.Helper
{
    public static class ObjectExtensionMethod
    {
        public static bool IsNull(this object input)
        {
            return input == null;
        }
        public static bool IsNotNull(this object input)
        {
            return !IsNull(input);
        }
    }
}
