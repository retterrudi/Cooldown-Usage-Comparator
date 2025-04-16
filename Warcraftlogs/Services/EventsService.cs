using Cooldown_Usage_Comparator.Warcraftlogs.Models;
using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Warcraftlogs.Services;

public class EventsService
{
    public List<Event> ExtractEvents(string jsonString)
    {
        try
        {
            var data = JsonConvert.DeserializeObject<RootContainer>(jsonString);

            return data?.ReportContainer?.ReportData?.Report?.Events?.Events ?? [];
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}