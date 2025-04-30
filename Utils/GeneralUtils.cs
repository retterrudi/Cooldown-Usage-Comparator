using System.Text.Json;
using Cooldown_Usage_Comparator.Data;
using Cooldown_Usage_Comparator.Warcraftlogs.Models;

namespace Cooldown_Usage_Comparator.Utils;

public static class GeneralUtils
{
    public static void PrettyPrintJson(string json)
    {
        var prettyJson = JsonSerializer.Serialize(
            JsonSerializer.Deserialize<JsonDocument>(json),
            new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(prettyJson);
    }

    public static void PrintTimeline(List<Event> events, long startTime, SpellRepository spellRepository)
    {
        foreach (var item in events)
        {
            if (spellRepository.Spells.ContainsKey((AbilityGameId)(item.AbilityGameId ?? -1)))
            {
                Console.WriteLine($"[{TimeSpan.FromMilliseconds((item.Timestamp - startTime) ?? 0)}] [{item.Type}] [{spellRepository.Spells[(AbilityGameId)(item.AbilityGameId ?? -1)]}]");
            }
        }
    }
}
