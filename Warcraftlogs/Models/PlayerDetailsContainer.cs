using System.Text.Json.Serialization;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class PlayerDetailsContainer
{
    [JsonPropertyName("dps")]
    public List<PlayerDetails>? Dps { get; init; }
}