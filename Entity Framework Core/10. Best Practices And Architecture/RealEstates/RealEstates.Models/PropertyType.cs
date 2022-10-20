using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Models
{
    public class PropertyType//vid imot (mnogostaen,mezonet,tristane etc.) ppc moje i da ne e klas a enumeration s dopustimi stoinosti (mnogostaen,mezonet,tristane etc.)
    {
        public PropertyType()
        {
            this.Properties=new HashSet<Property>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Property> Properties { get; set; }
    }
}
