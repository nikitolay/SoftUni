using EgnValidator.Enumerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgnValidator.Interfaces
{
    public interface IGenerator
    {
        string[] Generate(DateTime birthDate, string city, Gender gender);
    }
}
