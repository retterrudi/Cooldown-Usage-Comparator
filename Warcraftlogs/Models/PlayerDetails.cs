using System.Text.Json.Serialization;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class PlayerDetails
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }
    
    [JsonPropertyName("id")]
    public int Id { get; init; }
    
    [JsonPropertyName("guid")]
    public long Guid { get; init; }
    
    /// <summary>
    /// For example paladin
    /// </summary>
    [JsonPropertyName("type")]
    public string? Type { get; init; }
    
    [JsonPropertyName("server")]
    public string? Server { get; init; }
    
    [JsonPropertyName("region")]
    public string? Region { get; init; }
    
    [JsonPropertyName("icon")]
    public string? Icon { get; init; }
    
    [JsonPropertyName("specs")]
    public List<PlayerSpec>? Specs { get; init; }
}