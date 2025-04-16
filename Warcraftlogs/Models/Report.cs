using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class Report
{
    [JsonProperty(PropertyName = "playerDetails")]
    public OuterPlayerDetails? PlayerDetails { get; init; }
    
    [JsonProperty(PropertyName = "fights")]
    public List<Fight>? Fights {get; init; }
    
    [JsonProperty(PropertyName = "events")]
    public EventsContainer? Events {get; init; }
}