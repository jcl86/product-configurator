namespace ProductConfigurator.Shared.Modules.Management.Steps.Save;

public class SaveStepResponse
{
    public int Id { get; set; }
    public ChoiceType ChoiceType { get; set; }
    public required string Name { get; set; }
}