using System.ComponentModel.DataAnnotations;

namespace ParkingSystem.Data.Models
{
    public class Car
    {
        [Required]

        public string CarMake { get; set; }

        [Required]

        public string PlateNumber { get; set; }

        [Required]

        public string Year { get; set; }
        [Required]
        public string Price { get; set; }
    }
}
