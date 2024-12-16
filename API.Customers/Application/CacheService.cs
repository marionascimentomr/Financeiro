using API.Customers.Application.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace API.Customers.Application
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _cache;

        public CacheService(IMemoryCache memoryCache)
        {
            _cache = memoryCache;
        }

        public void Set<T>(string key, T value, TimeSpan expiration)
        {
            _cache.Set(key, value, expiration);
        }

        public T? Get<T>(string key)
        {
            _cache.TryGetValue(key, out T value);
            return value;
        }
    }
}
