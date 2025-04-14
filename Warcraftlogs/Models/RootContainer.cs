using System.Text.Json.Serialization;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class RootContainer
{
    [JsonPropertyName("data")]
    public ReportContainer? ReportContainer { get; init; }
}