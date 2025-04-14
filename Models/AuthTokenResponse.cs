using Newtonsoft.Json;

namespace Cooldown_Usage_Comparator.Models;

public class AuthTokenResponse
{
    [JsonProperty(PropertyName = "token_type")]
    public string? TokenType { get; set; }
    
    [JsonProperty(PropertyName = "expires_in")]
    public long ExpiresIn { get; set; }
    
    [JsonProperty(PropertyName = "access_token")]
    public string? AccessToken { get; set; }
}