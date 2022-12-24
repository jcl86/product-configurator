namespace ProductConfigurator.Domain;

public class Step
{
    public int Id { get; set; }
    public int OrderIndex { get; set; }
    public ChoiceType ChoiceType { get; set; }

    public const int NameMaxLength = 200;
    public string Name { get; set; }
}
