using System.Text.Json.Serialization;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class OuterPlayerDetails
{
    [JsonPropertyName("data")]
    public OuterPlayerDetailsData? PlayerDetailsData {get; init; }
}