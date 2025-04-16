using Cooldown_Usage_Comparator;
using Cooldown_Usage_Comparator.Models;
using Cooldown_Usage_Comparator.Pages;
using Cooldown_Usage_Comparator.Warcraftlogs;
using Newtonsoft.Json;

var _config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var tokenUrl = "https://www.warcraftlogs.com/oauth/token";
var oAuthClient = new OAuthTokenClient(
    _config["warcraftlogs:client-id"], 
    _config["warcraftlogs:client-secret"], 
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

var testEvents = await warcraftLogsClient.Events("NbJGzkjLPtThAc4W", 1, 46);

return 0;