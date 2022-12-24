namespace System.Text.Json;

public static class JsonExtensions
{
    private const bool defaultCaseInsensitive = true;
    
    public static string Serialize<TModel>(this TModel model)
    {
        return JsonSerializer.Serialize(model, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = defaultCaseInsensitive,
        });
    }

    public static TModel? Deserialize<TModel>(this string? json)
    {
        if (json is null)
        {
            return default;
        }
        
        return JsonSerializer.Deserialize<TModel>(json, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = defaultCaseInsensitive,
        });
    }
}
