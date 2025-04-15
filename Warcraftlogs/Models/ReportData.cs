using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class ReportData
{
    [JsonProperty(PropertyName = "report")]
    public Report? Report { get; init; }
}