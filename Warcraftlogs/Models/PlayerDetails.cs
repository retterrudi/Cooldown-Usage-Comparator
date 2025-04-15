using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class PlayerDetails
{
    [JsonProperty(PropertyName = "name")]
    public string? Name { get; init; }
    
    [JsonProperty(PropertyName = "id")]
    public int Id { get; init; }
    
    [JsonProperty(PropertyName = "guid")]
    public long Guid { get; init; }
    
    /// <summary>
    /// For example paladin
    /// </summary>
    [JsonProperty(PropertyName = "type")]
    public string? Type { get; init; }
    
    [JsonProperty(PropertyName = "server")]
    public string? Server { get; init; }
    
    [JsonProperty(PropertyName = "region")]
    public string? Region { get; init; }
    
    [JsonProperty(PropertyName = "icon")]
    public string? Icon { get; init; }
    
    [JsonProperty(PropertyName = "specs")]
    public List<PlayerSpec>? Specs { get; init; }
}