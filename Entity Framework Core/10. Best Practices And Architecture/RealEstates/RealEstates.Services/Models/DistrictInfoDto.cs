using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstates.Services.Models
{
    public class DistrictInfoDto//info za kwartalite
    {

        public string Name { get; set; } //da se vrushta imeto na kwartala

        public decimal AveragePricePerSquareMeter { get; set; }

        public int PropertiesCount { get; set; }//broq na apartamenti
    }   
}   
    

