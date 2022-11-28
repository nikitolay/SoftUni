using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T01.Logger.Layouts.Interfaces;

namespace T01.Logger.Layouts
{
    public class XmlLayout : ILayout
    {
        public string Format => @"
<log>
    <date>{0}</date>
    <level>{1}</level>
    <message>{2}</message>
</log>";
    }
}
