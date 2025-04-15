using Cooldown_Usage_Comparator.Warcraftlogs.Models;
using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Services;

public class FightsService
{
    public List<Fight> ExtractFights(string jsonString)
    {
        try
        {
            var data = JsonConvert.DeserializeObject<RootContainer>(jsonString);

            return data?.ReportContainer?.ReportData?.Report?.Fights ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}