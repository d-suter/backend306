using System.Net.Http.Headers;
using FitnessCheck.Data;
using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace FitnessCheck.Services;
public class GoogleCloudFunctionsGenderService(IOptions<GoogleCloudFunctionOptions> googleCloudFunctionOptions, GenderMemoryCache _memoryCache) : IGenderService
{
    private readonly GoogleCloudFunctionOptions _googleCloudFunctionOptions = googleCloudFunctionOptions.Value;
    private readonly MemoryCacheEntryOptions _cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(15))
                                                                                               .SetSize(1);

    public async Task<char> GetGenderAsync(string username)
    {
        if (_memoryCache.Cache.TryGetValue(username, out char cachedGender))
        {
            return cachedGender;
        }

        GoogleCredential credential = await GoogleCredential.GetApplicationDefaultAsync();
        OidcTokenOptions tokenOptions = OidcTokenOptions.FromTargetAudience(_googleCloudFunctionOptions.GetGenderUrl);

        // TODO: cache token / accessToken
        OidcToken token = await credential.GetOidcTokenAsync(tokenOptions);
        string accessToken = await token.GetAccessTokenAsync();

        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var requestUrl = $"{_googleCloudFunctionOptions.GetGenderUrl}?username={username}";
        HttpResponseMessage response = await client.GetAsync(requestUrl);

        if (response.IsSuccessStatusCode)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            var gender = responseBody[0];
            _memoryCache.Cache.Set(username, gender, _cacheEntryOptions);
            return gender;
        }

        throw new Exception($"Could not determine gender for user '{username}'.");
    }
}