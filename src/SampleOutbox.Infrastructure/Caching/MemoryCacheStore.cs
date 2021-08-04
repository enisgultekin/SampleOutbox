using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace SampleOutbox.Infrastructure.Caching
{
    public class MemoryCacheStore : ICacheStore
    {
        private readonly IMemoryCache _memoryCache;
        private readonly Dictionary<string, TimeSpan> _cachingConfiguration;

        public MemoryCacheStore(IMemoryCache memoryCache,Dictionary<string,TimeSpan> cachingConfiguration)
        {
            _memoryCache = memoryCache;
            _cachingConfiguration = cachingConfiguration;
        }
        
        
        public void Add<TItem>(TItem item, ICacheKey<TItem> key, TimeSpan? expirationTime = null)
        {
            var cachedObjectName = item.GetType().Name;
            TimeSpan timeSpan = _cachingConfiguration[cachedObjectName];
            if (expirationTime.HasValue)
            {
                timeSpan = expirationTime.Value;
            }

            _memoryCache.Set(key.CacheKey, item, timeSpan);
        }

        public void Add<TItem>(TItem item, ICacheKey<TItem> key, DateTime? absoluteExpiration = null)
        {
            DateTimeOffset offset = DateTimeOffset.MaxValue;
            if (absoluteExpiration.HasValue)
            {
                offset = absoluteExpiration.Value;
            }

            _memoryCache.Set(key.CacheKey, item, offset);
        }

        public TItem? Get<TItem>(ICacheKey<TItem> key) where TItem : class
        {
            return _memoryCache.TryGetValue(key.CacheKey, out TItem item) ? item : null;
        }

        public void Remove<TItem>(ICacheKey<TItem> key)
        {
            _memoryCache.Remove(key.CacheKey);
        }
    }
}