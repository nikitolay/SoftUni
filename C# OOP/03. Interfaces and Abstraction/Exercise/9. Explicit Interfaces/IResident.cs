using System;
using System.Collections.Generic;
using System.Text;

namespace _9._Explicit_Interfaces
{
    public interface IResident
    {
        string Name { get; }
        string Country { get; }
        string GetName();

    }
}
