using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorProblem
{
    public class AuthorAttribute : Attribute
    {
        public string Name { get; set; }

        public AuthorAttribute(string name)
        {
            Name = name;
        }
    }
}
