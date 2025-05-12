using Cooldown_Usage_Comparator.Data;
using Cooldown_Usage_Comparator.Models;
using Cooldown_Usage_Comparator.Warcraftlogs;
using Newtonsoft.Json;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

const string tokenUrl = "https://www.warcraftlogs.com/oauth/token";
var oAuthClient = new OAuthTokenClient(
    config["warcraftlogs:client-id"] ?? throw new InvalidOperationException(), 
    config["warcraftlogs:client-secret"] ?? throw new InvalidOperationException(), 
    tokenUrl);

var response = oAuthClient.GetTokenAsync();
var tokenResponse = JsonConvert.DeserializeObject<AuthTokenResponse>(await response);

if (tokenResponse?.AccessToken is null)
{
    Console.WriteLine($"Token response contained 'null'");
    return -1;
}

var warcraftLogsClient = new WarcraftlogsClient(tokenResponse.AccessToken);

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/fights", async (string reportCode) =>
{
    var fights = await warcraftLogsClient.Fights(reportCode);
    var content = JsonConvert.SerializeObject(fights);
    return Results.Content(content);
});

app.MapGet(
    "/players", 
    async (
        string reportCode, 
        int fightId) =>
{
    var playerDetails = await warcraftLogsClient.PlayerDetails(reportCode, fightId);
    var content = JsonConvert.SerializeObject(playerDetails);
    return Results.Content(content);
});

app.MapGet("/timeline", 
    async (
        string reportCode, 
        int fightId, 
        int playerId, 
        string gameClassAsString) =>
    {
        // TODO: Create meaningful timeline (filter for player...)
        var gameClass = gameClassAsString switch
        {
            "DeathKnight" => GameClass.DeathKnight,
            "DemonHunter" => GameClass.DemonHunter,
            "Druid" => GameClass.Druid,
            "Evoker" => GameClass.Evoker,
            "Hunter" => GameClass.Hunter,
            "Mage" => GameClass.Mage,
            "Monk" => GameClass.Monk,
            "Paladin" => GameClass.Paladin,
            "Priest" => GameClass.Priest,
            "Rogue" => GameClass.Rogue,
            "Shaman" => GameClass.Shaman,
            "Warlock" => GameClass.Warlock,
            "Warrior" => GameClass.Warrior,
            _ => throw new ArgumentException($"Invalid game class name: {gameClassAsString}"),
        }; 
        var spellRepo = new SpellRepositoryProvider().BuildRepositoryForClass(gameClass);
        
        
        var events = await warcraftLogsClient.Events(reportCode, fightId, playerId);
        // Filter for known spells
        // No understanding for a class yet
        var filteredEvents = events.Where(e => 
            e.AbilityGameId is not null 
            && spellRepo.ContainsKey((AbilityGameId)e.AbilityGameId))
            .ToList();
        // Add filter for class 
        // TODO: Modify SpellRepository to enable filtering for a GameClass
        var content = JsonConvert.SerializeObject(filteredEvents);
        return Results.Content(content);
    }
);

app.Run();

return 0;