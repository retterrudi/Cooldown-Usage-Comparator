using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class FightEvent(long timestamp, int abilityId, string? abilityName, string? imageName)
{
    [JsonProperty(PropertyName = "timestamp")]
    public long Timestamp { get; set; } = timestamp;

    [JsonProperty(PropertyName = "abilityId")]
    public int AbilityId { get; set; } = abilityId;

    [JsonProperty(PropertyName = "abilityName")]
    public string? AbilityName { get; set; } = abilityName;

    [JsonProperty(PropertyName = "imageName")]
    public string? ImageName { get; set; } = imageName;
}