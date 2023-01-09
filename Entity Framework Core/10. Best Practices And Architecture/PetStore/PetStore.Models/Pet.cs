using PetStore.Common;
using PetStore.Models.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class Pet
    {
        public Pet()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(PetValidationConstants.NAME_MAX_LENGTH)]
        public string Name { get; set; }

        public int Age { get; set; }

        [MaxLength(PetValidationConstants.DESCRIPTION_MAX_LENGTH)]
        public string Description { get; set; }

        public Gender Gender { get; set; }

        public decimal Price { get; set; }

        public bool isSold{ get; set; }

        [ForeignKey(nameof(PetType))]

        public int PetTypeId { get; set; }

        public virtual PetType PetType { get; set; }
        

        [ForeignKey(nameof(Breed))]
        public int BreedId { get; set; }

        public virtual Breed Breed { get; set; }

        [Required]
        [ForeignKey(nameof(Store))]
        public string StoreId { get; set; }
        public virtual Store Store { get; set; }


      
        [ForeignKey(nameof(Reservation))]
        public string ReservationId { get; set; }
        public virtual PetReservation Reservation { get; set; }
    }
}