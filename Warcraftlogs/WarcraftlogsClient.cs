using System.Net.Http.Headers;
using System.Text;
using Cooldown_Usage_Comparator.Warcraftlogs.Models;
using Cooldown_Usage_Comparator.Warcraftlogs.Services;
// ReSharper disable UseRawString

namespace Cooldown_Usage_Comparator.Warcraftlogs;

public class WarcraftlogsClient
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationHeaderValue _authHeader;
    private readonly EventsService _eventsService;
    private readonly FightsService _fightsService;
    private readonly PlayerDetailsService _playerDetailsService;
    private const string ApiUri = "";

    // ReSharper disable once ConvertToPrimaryConstructor
    public WarcraftlogsClient(string authToken)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri("https://www.warcraftlogs.com/api/v2/client")
        };
        _authHeader = new AuthenticationHeaderValue("Bearer", authToken);
        _eventsService = new EventsService();
        _fightsService = new FightsService();
        _playerDetailsService = new PlayerDetailsService();
    }

    public async Task<List<Event>> Events(
        string reportCode,
        int fightId, 
        int? sourceId)
    {
        try
        {
            const string query = @"
                query Events($code: String!, $fightId: Int!, $sourceId: Int, $startTime: Float) {
                  reportData {
                    report(code: $code) {
                      events (fightIDs: [$fightId], sourceID: $sourceId, startTime: $startTime) {
                        data
                      }
                    }
                  }
                }";

            var body = new
            {
                query,
                variables = new
                {
                    code = reportCode,
                    // ReSharper disable once RedundantAnonymousTypePropertyName
                    sourceId = sourceId,
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
            
            return _eventsService.ExtractEvents(await apiResponse.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;

            // TODO
        }
    }
    
    public async Task<List<Fight>> Fights(string reportCode)
    {
        try
        {
            const string query = @"
                query Fights(
                  $code: String!, 
                  $killType: KillType!
                ) {
                  reportData {
                    report(code: $code) {
                      fights(killType: $killType) {
                        difficulty
                        encounterID
                        endTime
                        friendlyPlayers
                        id
                        keystoneBonus
                        keystoneLevel
                        keystoneTime
                        name
                        startTime
                      }
                    }
                  }
                }";

            var body = new
            {
                query,
                variables = new
                {
                    code = reportCode,
                    killType = "Encounters"
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

            return _fightsService.ExtractFights(await apiResponse.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;

            // TODO
        }
    }
    
    public async Task<List<PlayerDetails>> PlayerDetails(string reportCode, int fightId)
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
                    code = reportCode,
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

            return _playerDetailsService.ExtractPlayerDetails(await apiResponse.Content.ReadAsStringAsync());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
            // TODO
        }
    }
}