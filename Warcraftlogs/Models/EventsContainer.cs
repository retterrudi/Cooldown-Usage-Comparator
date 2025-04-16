using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

public class EventsContainer
{
    [JsonProperty(PropertyName = "data")]
    public List<Event>? Events { get; init; }
    
    [JsonProperty(PropertyName = "nextPageTimestamp")]
    public double? NextPageTimestamp { get; init; }
}