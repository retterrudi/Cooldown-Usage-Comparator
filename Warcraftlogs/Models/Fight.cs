using System.Text.Json.Serialization;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class Fight
{
    [JsonPropertyName("difficulty")]
    public int? Difficulty { get; init; }
    
    [JsonPropertyName("encounterID")]
    public int? EncounterId { get; init; }
    
    [JsonPropertyName("endTime")]
    public int? EndTime { get; init; }
    
    [JsonPropertyName("friendlyPlayers")]
    public List<int>? FriendlyPlayers { get; init; }
    
    [JsonPropertyName("id")]
    public int? Id { get; init; }
    
    [JsonPropertyName("keystoneBonus")]
    public int? KeystoneBonus { get; init; }
    
    [JsonPropertyName("keystoneLevel")]
    public int? KeystoneLevel { get; init; }
    
    [JsonPropertyName("keystoneTime")]
    public int? KeystoneTime {get; init; }
    
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("startTime")] 
    public long? StartTime { get; init; }
}