using System.Runtime.Serialization;
using Cooldown_Usage_Comparator.Warcraftlogs.Models;
using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Services;

public interface IPlayerDetailsService
{
    public List<PlayerDetails> ExtractPlayerDetails(string jsonString);
}

public class PlayerDetailsService : IPlayerDetailsService
{
    public List<PlayerDetails> ExtractPlayerDetails(string jsonString)
    {
        try
        {
            var data = JsonConvert.DeserializeObject<RootContainer>(jsonString);

            return data?.ReportContainer?.ReportData?.Report?.PlayerDetails?.PlayerDetailsData?.PlayerDetails?.Dps ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    [DataContract]
    private class RootContainer
    {
        [DataMember(Name = "data")]
        public ReportContainer? ReportContainer { get; init; }
    }
    
    [DataContract]
    private class ReportContainer
    {
        [DataMember(Name = "reportData")]
        public ReportData? ReportData { get; init; }
    }

    [DataContract]
    private class ReportData
    {
        [DataMember(Name = "report")]
        public Report? Report { get; init; }
    }

    [DataContract]
    private class Report
    {
        [DataMember(Name = "playerDetails")]
        public OuterPlayerDetails? PlayerDetails { get; init; }
    }

    [DataContract]
    private class OuterPlayerDetails
    {
        [DataMember(Name = "data")]
        public OuterPlayerDetailsData? PlayerDetailsData {get; init; }
    }

    [DataContract]
    private class OuterPlayerDetailsData
    {
        [DataMember(Name = "playerDetails")]
        public PlayerDetailsContainer? PlayerDetails { get; init; }
    }

    [DataContract]
    private class PlayerDetailsContainer
    {
        [DataMember(Name = "dps")]
        public List<PlayerDetails>? Dps { get; init; }
    }
}

