using System.Text.Json.Serialization;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class PlayerSpec
{
    [JsonPropertyName("spec")]
    public string? Spec { get; init; }
    
    [JsonPropertyName("count")]
    public int Count { get; init; }
}