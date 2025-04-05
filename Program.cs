using System.Net.Http.Headers;
using System.Text;
using Cooldown_Usage_Comparator.Pages;
using Cooldown_Usage_Comparator.Pages.models;
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

var _httpClient = new HttpClient();

var apiUrl = "https://www.warcraftlogs.com/api/v2/client";
var authHeader = new AuthenticationHeaderValue("Bearer", tokenResponse.accessToken);

var body = "{\"query\": \"query ReportData($code: String!, $fightID: Int!) { reportData { report(code: $code) { playerDetails(fightIDs: [$fightID]) } } }\",\"variables\": { \"code\": \"NbJGzkjLPtThAc4W\", \"fightID\": 1 } }";
var content = new StringContent(body, Encoding.UTF8, "application/json");

var request = new HttpRequestMessage(HttpMethod.Post, apiUrl)
{
    Headers = { Authorization = authHeader},
    Content = content
};

Console.WriteLine(await request.Content.ReadAsStringAsync());

var apiResponse = await _httpClient.SendAsync(request);
apiResponse.EnsureSuccessStatusCode();
// Console.WriteLine(await apiResponse.Content.ReadAsStringAsync());
PrettyPrintJson(await apiResponse.Content.ReadAsStringAsync());

void PrettyPrintJson(string json)
{
    var prettyJson = JsonConvert.SerializeObject(JsonConvert.DeserializeObject(json), Formatting.Indented);
    Console.WriteLine(prettyJson);
}
