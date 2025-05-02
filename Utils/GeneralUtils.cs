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

    public static void PrintTimeline(
        List<Event> events, 
        long startTime, 
        SpellRepository spellRepository)
    {
        foreach (var item in events.Where(e => e.Type == "cast"))
        {
            if (spellRepository.Spells.ContainsKey((AbilityGameId)(item.AbilityGameId ?? -1)))
            {
                Console.WriteLine(
                    $"[{TimeSpan.FromMilliseconds((item.Timestamp - startTime) ?? 0)}] " +
                    $"[{item.Type}] " +
                    $"[{spellRepository.Spells[(AbilityGameId)(item.AbilityGameId ?? -1)]}]");
            }
        }
    }

    public static void PrintTimelineOfAbilityIds(
        List<Event> events,
        long startTime,
        int timeSpanInSeconds,
        SpellRepository spellRepository)
    {
        var i = 0;
        while (i < events.Count && events[i].Timestamp - startTime <= 60_000 * timeSpanInSeconds)
        {
            var abilityGameId = (events[i]?.AbilityGameId ?? -1);
            if (Enum.IsDefined(typeof(AbilityGameId), abilityGameId))
            {
                if (!spellRepository.Spells.ContainsKey((AbilityGameId)abilityGameId))
                {
                }
            }
            else
            {
                Console.WriteLine(
                    $"{TimeSpan.FromMilliseconds((events[i].Timestamp - startTime) ?? 0)} " +
                    $"{events[i].Type} " +
                    $"Id: {events[i].AbilityGameId}");
            }

            ++i;
        }
        Console.WriteLine($"i: {i}");
    }
}
