using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class OuterPlayerDetails
{
    [JsonProperty(PropertyName = "data")]
    public OuterPlayerDetailsData? PlayerDetailsData {get; init; }
}