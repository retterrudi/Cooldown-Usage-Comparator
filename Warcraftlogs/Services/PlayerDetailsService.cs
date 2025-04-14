using Cooldown_Usage_Comparator.Warcraftlogs.Models;
using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Services;

public class PlayerDetailsService
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
}