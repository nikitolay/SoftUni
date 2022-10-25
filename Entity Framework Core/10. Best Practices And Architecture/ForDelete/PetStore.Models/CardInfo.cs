

using PetStore.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetStore.Models
{
    public class CardInfo
    {
        public CardInfo()
        {
            this.Id=Guid.NewGuid().ToString();
            this.ProductSales = new HashSet<ProductSale>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(CardInfoValidationConstants.CARD_NUMBER_MAX_LENGTH)]

        public string Number { get; set; }


        [Required]
        [MaxLength(CardInfoValidationConstants.CARD_HOLDER_MAX_LENGTH)]

        public string HolderName { get; set; }

        [Required]
        [MaxLength(CardInfoValidationConstants.EXPIRATION_DATE_MAX_LENGTH)]

        public string ExpirationDate { get; set; }


        [Required]
        [MaxLength(CardInfoValidationConstants.CVC_MAX_LENGTH)]

        public string CVC { get; set; }


        [Required]

        [ForeignKey(nameof(Client))]

        public string ClientId { get; set; }

        public virtual Client Client { get; set; }


        public virtual ICollection<ProductSale> ProductSales { get; set; }
    }
}
