using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class RootContainer
{
    [JsonProperty(PropertyName = "data")]
    public ReportContainer? ReportContainer { get; init; }
}