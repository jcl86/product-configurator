using System.ComponentModel.DataAnnotations;

namespace ProductConfigurator.Domain;

public class UpdateStep
{
    public ChoiceType ChoiceType { get; set; }

    [Required]
    [StringLength(Step.NameMaxLength, ErrorMessage = "Step name max length is {0} characters")]
    public string Name { get; set; }
}
