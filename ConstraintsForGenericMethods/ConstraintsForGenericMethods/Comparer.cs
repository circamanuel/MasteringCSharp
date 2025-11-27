using System;
using System.Collections.Generic;
using System.Text;

namespace ConstraintsForGenericMethods
{
    internal class Comparer
    {

        public static bool AreEquals<T>(T first, T second) where T : class
        {
            return first == second; 
        }
    }
}
