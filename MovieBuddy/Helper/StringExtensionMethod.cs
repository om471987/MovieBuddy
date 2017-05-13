using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieBuddy.Helper
{
    public static class StringExtensionMethod
    {
        public static bool IsNullOrEmpty(this string input)
        {
            return input.IsNull() || input.Trim().Count() == 0;
        }
        public static bool IsNotNullOrEmpty(this string input)
        {
            return !IsNullOrEmpty(input);
        }
        
    }
}
