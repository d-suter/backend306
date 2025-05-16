using System.Net.Http.Headers;
using FitnessCheck.Data;
using FitnessCheck.Data.Entities;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace FitnessCheck.Services;
public class GoogleCloudFunctionsCohortService(FitnessCheckDbContext _dbContext, IOptions<GoogleCloudFunctionOptions> googleCloudFunctionOptions, CohortMemoryCache _memoryCache) : ICohortService
{
    private readonly GoogleCloudFunctionOptions _googleCloudFunctionOptions = googleCloudFunctionOptions.Value;
    private readonly MemoryCacheEntryOptions _cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(15))
                                                                                               .SetSize(1);

    public async Task<Cohort?> GetCohortAsync(string username)
    {
        if (_memoryCache.Cache.TryGetValue(username, out Cohort? cachedCohort) && cachedCohort is not null)
        {
            _dbContext.Attach(cachedCohort);
            return cachedCohort;
        }

        GoogleCredential credential = await GoogleCredential.GetApplicationDefaultAsync();
        OidcTokenOptions tokenOptions = OidcTokenOptions.FromTargetAudience(_googleCloudFunctionOptions.GetCohortUrl);

        // TODO: cache token / accessToken
        OidcToken token = await credential.GetOidcTokenAsync(tokenOptions);
        string accessToken = await token.GetAccessTokenAsync();

        var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        var requestUrl = $"{_googleCloudFunctionOptions.GetCohortUrl}?username={username}";
        HttpResponseMessage response = await client.GetAsync(requestUrl);

        Cohort? cohort = response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<Cohort>()
            : GetDummyCohort();

        if (cohort is not null)
        {
            cohort = await CheckForDuplicateAsync(cohort);
            _memoryCache.Cache.Set(username, cohort, _cacheEntryOptions);
            return cohort;
        }

        return null;
    }

    private async Task<Cohort> CheckForDuplicateAsync(Cohort cohort)
    {
        var existingCohort = await _dbContext.Cohorts.Where(dbCohort => dbCohort.ClassNameVocationalEducation == cohort.ClassNameVocationalEducation
                                                                        && dbCohort.ClassNameBaccalaureate == cohort.ClassNameBaccalaureate
                                                                        && dbCohort.FirstSchoolYear == cohort.FirstSchoolYear).FirstOrDefaultAsync();

        if (existingCohort is not null)
        {
            return existingCohort;
        }

        _dbContext.Cohorts.Add(cohort);
        await _dbContext.SaveChangesAsync();

        return cohort;
    }

    private static Cohort GetDummyCohort()
    {
        return new Cohort
        {
            Profession = "unknown",
            Baccalaureate = false,
            SchoolYear = 0,
            FirstSchoolYear = (uint)DateTime.Now.Year,
            ClassNameVocationalEducation = "unknown",
            ClassNameBaccalaureate = null,
        };
    }
}