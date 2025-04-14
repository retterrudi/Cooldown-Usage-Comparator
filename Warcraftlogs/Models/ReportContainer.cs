using System.Text.Json.Serialization;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class ReportContainer
{
    [JsonPropertyName("reportData")]
    public ReportData? ReportData { get; init; }
}