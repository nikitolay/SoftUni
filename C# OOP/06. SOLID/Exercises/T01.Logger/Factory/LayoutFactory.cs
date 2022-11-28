using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T01.Logger.Layouts;
using T01.Logger.Layouts.Interfaces;

namespace T01.Logger.Factory
{
    public class LayoutFactory
    {
        public ILayout Create(string type)
        {
            ILayout layout = null;
            if (type==nameof(SimpleLayout))
            {
                layout= new SimpleLayout();
            }
            else if (type == nameof(XmlLayout))
            {
                layout = new XmlLayout();
            }
            else
            {
                throw new ArgumentException("Invalid type");
            }
            return layout;
        }
    }
}
