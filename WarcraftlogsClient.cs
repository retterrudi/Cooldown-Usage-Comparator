using System.Net.Http.Headers;
using System.Text;
using static Cooldown_Usage_Comparator.utils.GeneralUtils;

namespace Cooldown_Usage_Comparator;

public class WarcraftlogsClient
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationHeaderValue _authHeader;
    private const string ApiUri = "";

    // ReSharper disable once ConvertToPrimaryConstructor
    public WarcraftlogsClient(string authToken)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://www.warcraftlogs.com/api/v2/client")
        };
        _authHeader = new AuthenticationHeaderValue("Bearer", authToken);
    }

    public async Task GetPlayerDetails(string fightCode, int fightId)
    {
        try
        {
            const string query = @"
                query ReportData($code: String!, $fightId: Int!) {
                    reportData {
                        report (code: $code) {
                            playerDetails (fightIDs: [$fightId])
                        }
                    }
                }";

            var body = new
            {
                query,
                variables = new
                {
                    code = fightCode,
                    // ReSharper disable once RedundantAnonymousTypePropertyName
                    fightId = fightId
                }
            };
            
            var content = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(body), 
                Encoding.UTF8, 
                "application/json");
            
            var request = new HttpRequestMessage(HttpMethod.Post, ApiUri)
            {
                Headers = { Authorization = _authHeader },
                Content = content
            };

            var apiResponse = await _httpClient.SendAsync(request);
            apiResponse.EnsureSuccessStatusCode();
            PrettyPrintJson(apiResponse.Content.ReadAsStringAsync().Result);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            // TODO
        }
    }
}