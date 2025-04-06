using System.Net.Http.Headers;
using System.Text;
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

var _httpClient = new HttpClient
{
    BaseAddress = new Uri("https://www.warcraftlogs.com")
};

var apiUrl = "/api/v2/client";
var authHeader = new AuthenticationHeaderValue("Bearer", tokenResponse.accessToken);

var body = "{\"query\": \"query ReportData($code: String!, $fightID: Int!) { reportData { report(code: $code) { playerDetails(fightIDs: [$fightID]) } } }\",\"variables\": { \"code\": \"NbJGzkjLPtThAc4W\", \"fightID\": 1 } }";
var content = new StringContent(body, Encoding.UTF8, "application/json");

var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
{
    Headers = { Authorization = authHeader},
    Content = content
};

var apiResponse = await _httpClient.SendAsync(request);
apiResponse.EnsureSuccessStatusCode();
PrettyPrintJson(await apiResponse.Content.ReadAsStringAsync());

