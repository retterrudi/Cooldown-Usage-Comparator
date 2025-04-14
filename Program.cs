using System.Net.Http.Headers;
using System.Text;
using Cooldown_Usage_Comparator;
using Cooldown_Usage_Comparator.Pages;
using Cooldown_Usage_Comparator.Pages.models;
using Newtonsoft.Json;
using static Cooldown_Usage_Comparator.utils.GeneralUtils;

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
await warcraftLogsClient.GetPlayerDetails("NbJGzkjLPtThAc4W", 1);