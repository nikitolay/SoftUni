using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _6._Equality_Logic
{
    internal class PersonEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals([AllowNull] Person x, [AllowNull] Person y)
        {
            return x.CompareTo(y) == 0;
        }

        public int GetHashCode([DisallowNull] Person obj)
        {
            return $"{obj.Name} {obj.Age}".GetHashCode();
        }
    }
}
