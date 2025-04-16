using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class Event
{
    [JsonProperty(PropertyName = "timestamp")]
    public long? Timestamp { get; init; }
    
    [JsonProperty(PropertyName = "sourceID")]
    public int? SourceId { get; init; }
    
    [JsonProperty(PropertyName = "abilityGameID")]
    public int? AbilityGameId { get; init; }
    
    [JsonProperty(PropertyName = "type")]
    public string? Type { get; init; }

    public override string ToString() =>
        $"Timestamp: {Timestamp}\tAbilityGameId: {AbilityGameId}\tType: {Type}";
}