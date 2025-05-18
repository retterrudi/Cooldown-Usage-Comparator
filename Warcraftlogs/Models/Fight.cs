using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

// ReSharper disable once ClassNeverInstantiated.Global
public class Fight
{
    [JsonProperty(PropertyName = "difficulty")]
    public int? Difficulty { get; init; }
    
    [JsonProperty(PropertyName = "encounterID")]
    public int? EncounterId { get; init; }
    
    [JsonProperty(PropertyName = "endTime")]
    public int? EndTime { get; init; }
    
    [JsonProperty(PropertyName = "friendlyPlayers")]
    public List<int>? FriendlyPlayers { get; init; }
    
    [JsonProperty(PropertyName = "id")]
    public int? Id { get; init; }
    
    [JsonProperty(PropertyName = "keystoneBonus")]
    public int? KeystoneBonus { get; init; }
    
    [JsonProperty(PropertyName = "keystoneLevel")]
    public int? KeystoneLevel { get; init; }
    
    [JsonProperty(PropertyName = "keystoneTime")]
    public int? KeystoneTime {get; init; }
    
    [JsonProperty(PropertyName = "name")]
    public string? Name { get; init; }

    [JsonProperty(PropertyName = "startTime")] 
    public long? StartTime { get; init; }

    public override string ToString() =>
        $"Encounter name: {Name}\nStart time: {StartTime}\nEnd time: {EndTime}";
}