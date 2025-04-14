using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Pages.models;

public class AuthTokenResponse
{
    [JsonProperty(PropertyName = "token_type")]
    public string tokenType { get; set; }
    
    [JsonProperty(PropertyName = "expires_in")]
    public long expiresIn { get; set; }
    
    [JsonProperty(PropertyName = "access_token")]
    public string accessToken { get; set; }
}