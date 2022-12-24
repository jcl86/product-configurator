using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductConfigurator.Shared;

public class CreateOption
{
    //[Required]
    //[StringLength(Option.MaxLengthName, ErrorMessage = "Product name max length is {0} characters")]
    public string Name { get; set; }

    public decimal Price { get; set; }

    //[Required]
    //[StringLength(Option.MaxLengthDescription, ErrorMessage = "Product name max length is {0} characters")]
    public string Description { get; set; }

    public IEnumerable<string> Tags { get; set; }
    public IEnumerable<byte[]> ImageCollection { get; set; }
}
