using System.Text.Json.Serialization;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class ReportData
{
    [JsonPropertyName("report")]
    public Report? Report { get; init; }
}