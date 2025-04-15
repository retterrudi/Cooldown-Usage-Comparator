using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class OuterPlayerDetailsData
{
    [JsonProperty(PropertyName = "playerDetails")]
    public PlayerDetailsContainer? PlayerDetails { get; init; }
}