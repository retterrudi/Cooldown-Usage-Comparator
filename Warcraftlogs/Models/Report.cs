using System.Text.Json.Serialization;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class Report
{
    [JsonPropertyName("playerDetails")]
    public OuterPlayerDetails? PlayerDetails { get; init; }
}