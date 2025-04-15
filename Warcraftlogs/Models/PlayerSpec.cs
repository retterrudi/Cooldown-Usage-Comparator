using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class PlayerSpec
{
    [JsonProperty(PropertyName = "spec")]
    public string? Spec { get; init; }
    
    [JsonProperty(PropertyName = "count")]
    public int Count { get; init; }
}