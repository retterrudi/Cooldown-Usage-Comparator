using Cooldown_Usage_Comparator.Data;
using Cooldown_Usage_Comparator.Models;
using Cooldown_Usage_Comparator.Utils;
using Cooldown_Usage_Comparator.Warcraftlogs;
using Newtonsoft.Json;

var config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/fights", (string reportCode) =>
{
    // Return all (relevant) fights
});

app.MapGet("/players", (string reportCode, int fightId) =>
{
    // Return all players of a given fight
});

app.MapGet("/timeline", 
    (
        string reportCode, 
        int fightId, 
        int playerId) =>
    {
        // Return a timeline
    }
);

app.Run();

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
var testPlayerDetails = await warcraftLogsClient.PlayerDetails("NbJGzkjLPtThAc4W", 1);
var testFights = await warcraftLogsClient.Fights("NbJGzkjLPtThAc4W");

Console.WriteLine(testFights[0]);

var encounterStartTime = testFights[0].StartTime;

var testEvents = await warcraftLogsClient.Events("NbJGzkjLPtThAc4W", 1, 46);

var spellRepo = new SpellRepository();

GeneralUtils.PrintTimeline(testEvents, encounterStartTime ?? 1, spellRepo);

var uniqueTypes = testEvents
    .Select(e => e.Type)
    .Distinct()
    .ToList();

foreach (var type in uniqueTypes)
{
    Console.WriteLine(type);
}

return 0;