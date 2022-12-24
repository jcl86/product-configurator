using System.ComponentModel.DataAnnotations;

namespace ProductConfigurator.Domain;

public class UpdateProduct
{
    //[Required]
    //[StringLength(250, ErrorMessage = "Product name max length is {0} characters")]
    public string Name { get; set; }
    public byte[] Image { get; set; }
}
