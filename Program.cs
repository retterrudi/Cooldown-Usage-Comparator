using Cooldown_Usage_Comparator.Pages;
using Cooldown_Usage_Comparator.Pages.models;
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

if (tokenResponse?.accessToken is null)
{
    Console.WriteLine($"Token response contained 'null'");
    return;
}

var warcraftLogsClient = new WarcraftlogsClient(tokenResponse.accessToken);
var test = await warcraftLogsClient.GetPlayerDetails("NbJGzkjLPtThAc4W", 1);