namespace ProductConfigurator.Shared.Modules.Management.Steps.Save;

public class SaveStepRequest
{
    public int? Id { get; set; }
    public ChoiceType ChoiceType { get; set; }
    public required string Name { get; set; }
    public required IEnumerable<Option> Options { get; set; }
    public required IEnumerable<Condition> Conditions { get; set; }
    
    public class Option
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public required string Name { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }

        public required IEnumerable<string> Tags { get; set; }
        public required IEnumerable<byte[]> Images { get; set; }
    }

    public class Condition
    {
        public ConditionType Type { get; set; }
        public required IEnumerable<string> Tags { get; set; }
    }
}
