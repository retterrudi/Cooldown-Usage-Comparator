using Cooldown_Usage_Comparator.Data;
using Cooldown_Usage_Comparator.Models;
using Cooldown_Usage_Comparator.Warcraftlogs;
using Cooldown_Usage_Comparator.Warcraftlogs.Models;
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

builder.Logging.ClearProviders();
builder.Logging.AddConsole(options => options.LogToStandardErrorThreshold = LogLevel.Information);
builder.Logging.AddDebug();
builder.Logging.SetMinimumLevel(LogLevel.Trace);

var CorsConfig = "_localFrontend";

builder.Services.AddCors(options =>
{
    options.AddPolicy(
        name: CorsConfig,
        policy =>
        {
            policy.WithOrigins("http://localhost:3000")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

app.UseRouting();
app.UseCors(CorsConfig);

app.MapGet("/fights", async (string reportCode) =>
{
    var fights = await warcraftLogsClient.Fights(reportCode);
    var content = JsonConvert.SerializeObject(fights);
    app.Logger.LogInformation("Let's see if this works {ReportCode}", reportCode);
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
        
        var filteredEvents = events.Where(e => 
            e.AbilityGameId is not null 
            && spellRepo.ContainsKey((AbilityGameId)e.AbilityGameId))
            .Select(ev =>
            {
                if (ev.Timestamp is not null
                    && ev.AbilityGameId is not null 
                    && spellRepo.ContainsKey((AbilityGameId)ev.AbilityGameId))
                {
                    return new FightEvent(
                        ev.Timestamp.Value, 
                        ev.AbilityGameId.Value, 
                        spellRepo[(AbilityGameId)ev.AbilityGameId].Name, 
                        spellRepo[(AbilityGameId)ev.AbilityGameId].Icon);
                }

                return null;
            })
            .Where(item => item is not null)
            .ToList();
        
        var content = JsonConvert.SerializeObject(filteredEvents);
        return Results.Content(content);
    }
);


app.Run();

return 0;