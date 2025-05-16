using Microsoft.Extensions.Caching.Memory;

namespace FitnessCheck.Services;

public class GenderMemoryCache
{
    public MemoryCache Cache { get; } = new MemoryCache(new MemoryCacheOptions { SizeLimit = 500 });
}
