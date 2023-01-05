using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlRoot("parts")]
    public class ImportPartsIdDto
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }
    }
}