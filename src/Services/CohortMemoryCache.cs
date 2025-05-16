using Microsoft.Extensions.Caching.Memory;

namespace FitnessCheck.Services;

public class CohortMemoryCache
{
    public MemoryCache Cache { get; } = new MemoryCache(new MemoryCacheOptions { SizeLimit = 500 });
}