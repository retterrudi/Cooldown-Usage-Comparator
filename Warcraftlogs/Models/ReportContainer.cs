using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class ReportContainer
{
    [JsonProperty(PropertyName = "reportData")]
    public ReportData? ReportData { get; init; }
}