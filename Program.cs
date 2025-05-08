using Cooldown_Usage_Comparator.Data;
using Cooldown_Usage_Comparator.Models;
using Cooldown_Usage_Comparator.Utils;
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
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/fights", async (string reportCode) =>
{
    var fights = await warcraftLogsClient.Fights(reportCode);
    var content = JsonConvert.SerializeObject(fights);
    return Results.Content(content);
});

app.MapGet("/players", async (string reportCode, int fightId) =>
{
    var playerDetails = await warcraftLogsClient.PlayerDetails(reportCode, fightId);
    var content = JsonConvert.SerializeObject(playerDetails);
    return Results.Content(content);
});

app.MapGet("/timeline", 
    async (
        string reportCode, 
        int fightId, 
        int playerId) =>
    {
        // TODO: Create meaningful timeline (filter for player...)
        var events = await warcraftLogsClient.Events(reportCode, fightId, playerId);
        var content = JsonConvert.SerializeObject(events);
        return Results.Content(content);
    }
);

app.Run();

return 0;

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