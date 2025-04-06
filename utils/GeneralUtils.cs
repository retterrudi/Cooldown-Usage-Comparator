using System.Text.Json;

namespace Cooldown_Usage_Comparator.utils;

public static class GeneralUtils
{
    public static void PrettyPrintJson(string json)
    {
        var prettyJson = JsonSerializer.Serialize(
            JsonSerializer.Deserialize<JsonDocument>(json),
            new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(prettyJson);
    }
}