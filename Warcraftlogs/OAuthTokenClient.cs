using System.Net;
using System.Net.Http.Headers;
using System.Text;

namespace Cooldown_Usage_Comparator.Warcraftlogs;

public class OAuthTokenClient
{
    private readonly HttpClient _httpClient;
    private readonly string _clientId;
    private readonly string _clientSecret;
    private readonly string _tokenEndpoint;

    // ReSharper disable once ConvertToPrimaryConstructor
    public OAuthTokenClient(
        string clientId, 
        string clientSecret, 
        string tokenEndpoint)
    {
        _clientId = clientId;
        _clientSecret = clientSecret;
        _tokenEndpoint = tokenEndpoint;

        _httpClient = new HttpClient(new HttpClientHandler
        {
            AllowAutoRedirect = false,
            AutomaticDecompression = DecompressionMethods.All
        });
    }

    public async Task<string> GetTokenAsync()
    {
        var values = new List<KeyValuePair<string, string>>
        {
            new KeyValuePair<string, string>("grant_type", "client_credentials")
        };
        var content = new FormUrlEncodedContent(values);

        var credentials = $"{_clientId}:{_clientSecret}";
        var base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(credentials));
        var authHeader = new AuthenticationHeaderValue("Basic", base64Credentials);

        var request = new HttpRequestMessage(HttpMethod.Post, _tokenEndpoint)
        {
            Content = content
        };
        request.Headers.Authorization = authHeader;

        var response = await _httpClient.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.Unauthorized)
        {
            var retryRequest = new HttpRequestMessage(HttpMethod.Post, _tokenEndpoint)
            {
                Content = content,
                Headers = { Authorization = authHeader }
            };

            response = await _httpClient.SendAsync(retryRequest);
        }

        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }
}