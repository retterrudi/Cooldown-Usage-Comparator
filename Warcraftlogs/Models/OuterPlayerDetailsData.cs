using System.Text.Json.Serialization;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class OuterPlayerDetailsData
{
    [JsonPropertyName("playerDetails")]
    public PlayerDetailsContainer? PlayerDetails { get; init; }
}