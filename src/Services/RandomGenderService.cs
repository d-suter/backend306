using Microsoft.Extensions.Caching.Memory;

namespace FitnessCheck.Services
{
    /// <summary>
    /// A placeholder service that randomly provides a gender for a given user ID.
    /// </summary>
    public class RandomGenderService : IGenderService
    {
        private readonly Random _random = new();
        private readonly GenderMemoryCache _memoryCache;
        private readonly MemoryCacheEntryOptions _cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromDays(15))
                                                                                                   .SetSize(1);


        public RandomGenderService(GenderMemoryCache memoryCache)
        {
            _random = new Random();
            _memoryCache = memoryCache;
        }

        /// <summary>
        /// Asynchronously gets a random gender ('m' or 'f')
        /// </summary>
        /// <param name="userId">Placeholder for when the user database will be implemented</param>
        /// <returns>A Task that represents the asynchronous operation, containing the user's gender as a char ('m' or 'f').</returns>
        public Task<char> GetGenderAsync(string username)
        {
            bool hasValue = _memoryCache.Cache.TryGetValue($"gender_{username}", out char cachedGender);
            if (hasValue)
            {
                return Task.FromResult(cachedGender);
            }

            char[] genders = ['m', 'f'];

            // Randomly select and return either 'm' or 'f'
            int index = _random.Next(genders.Length);
            char gender = genders[index];

            _memoryCache.Cache.Set($"gender_{username}", gender, _cacheEntryOptions);

            return Task.FromResult(gender);
        }
    }
}