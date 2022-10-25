using PetStore.Common;
using System.ComponentModel.DataAnnotations;

namespace PetStore.Models
{
    public class ProductType
    {
        public ProductType()
        {
            this.Products = new HashSet<Product>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ProductTypeValidationConstants.NAME_MAX_LENGTH)]

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
