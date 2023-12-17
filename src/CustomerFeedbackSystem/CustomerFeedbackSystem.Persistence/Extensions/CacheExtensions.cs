using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CustomerFeedbackSystem.Infrastructure.Extensions
{
    public static class CacheExtensions 
    {
        public static async Task<T?> GetFromCacheAsync<T>(this IDistributedCache cache, string key)
        {
            var cachedData = await cache.GetStringAsync(key);

            return cachedData != null
                ? JsonSerializer.Deserialize<T>(cachedData)
                : default;
        }

        public static async Task SetInCacheAsync<T>(this IDistributedCache cache, string key, T value, TimeSpan? ttl = null)
        {
            var options = new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = ttl ?? TimeSpan.FromMinutes(5)
            };

            var serializedValue = JsonSerializer.Serialize(value);
            await cache.SetStringAsync(key, serializedValue, options);
        }

        public static async Task InvalidateCacheAsync(this IDistributedCache cache, string key)
        {
            await cache.RemoveAsync(key);
        }
    }
}
