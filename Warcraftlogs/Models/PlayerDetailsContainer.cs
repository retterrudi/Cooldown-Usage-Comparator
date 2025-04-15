using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class PlayerDetailsContainer
{
    [JsonProperty(PropertyName = "dps")]
    public List<PlayerDetails>? Dps { get; init; }
}