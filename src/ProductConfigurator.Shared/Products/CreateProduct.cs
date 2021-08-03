using System.ComponentModel.DataAnnotations;

namespace ProductConfigurator.Shared
{
    public class CreateProduct
    {
        [Required]
        [StringLength(Product.NameMaxLength, ErrorMessage = "Product name max length is {0} characters")]
        public string Name { get; set; }

        public byte[] Image { get; set; }
    }
}
