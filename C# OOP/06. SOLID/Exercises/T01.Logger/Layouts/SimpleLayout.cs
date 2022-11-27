using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T01.Logger.Layouts.Interfaces;

namespace T01.Logger.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
