using System.Xml.Serialization;

namespace CarDealer.DTOs.Import
{
    [XmlRoot("parts")]
    public class ImportPartsModel
    {
        [XmlElement("partId")]
        public ImportPartsIdDto[] PartsId { get; set; }
    }
}