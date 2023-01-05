using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlType("Car")]
    public class CarInputModel
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("travelledDistance")]
        public long TravelledDistance { get; set; }

        [XmlElement("parts")]
        public ImportPartsModel Parts { get; set; }
    }
}
