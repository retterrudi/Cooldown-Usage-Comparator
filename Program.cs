using System.Net.Http.Headers;
using System.Text;
using Cooldown_Usage_Comparator.Pages;

var _config = new ConfigurationBuilder()
    .AddUserSecrets<Program>()
    .Build();

var _httpClient = new HttpClient();

var url = "https://www.warcraftlogs.com/oauth/token";
var credentials = $"{_config["warcraftlogs:client-id"]}:{_config["warcraftlogs:client-secret"]}";


var oAuthClient = new OAuthTokenClient(
    _config["warcraftlogs:client-id"], 
    _config["warcraftlogs:client-secret"], 
    url);

var response = oAuthClient.GetTokenAsync();
var content = response.Result;

Console.WriteLine(content);