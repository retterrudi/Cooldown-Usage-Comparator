using System.Runtime.Serialization;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Models;

[DataContract]
public class PlayerDetails
{
    [DataMember(Name = "name")]
    public string? Name { get; init; }
    
    [DataMember(Name = "id")]
    public int Id { get; init; }
    
    [DataMember(Name = "guid")]
    public long Guid { get; init; }
    
    /// <summary>
    /// For example paladin
    /// </summary>
    [DataMember(Name = "type")]
    public string? Type { get; init; }
    
    [DataMember(Name = "server")]
    public string? Server { get; init; }
    
    [DataMember(Name = "region")]
    public string? Region { get; init; }
    
    [DataMember(Name = "icon")]
    public string? Icon { get; init; }
    
    [DataMember(Name = "specs")]
    public List<PlayerSpec>? Specs { get; init; }
}