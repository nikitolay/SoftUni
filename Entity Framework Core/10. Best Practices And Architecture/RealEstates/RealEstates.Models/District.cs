using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Models
{
    public class District//kvartal
    {
        public District()
        {
            this.Properties = new HashSet<Property>();
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Property> Properties { get; set; }//polezno za zaqwki(da vzemem na kwartala vsichkite mu imoti )


    }
}
