using System;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace StockPriceMonitor.Data.Utilities
{
	public class CacheManager
	{
		private readonly IMemoryCache _memoryCache;

		public CacheManager(IMemoryCache memoryCache)
		{
			_memoryCache = memoryCache;
		}

        public void AddToCache(string cacheKey, IEnumerable<StockPrice> prices)
        {
            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(5),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(2)
            };

            _memoryCache.Set(cacheKey, prices, cacheExpiryOptions);
        }

        public IEnumerable<StockPrice> GetValueOrDefault(string cacheKey)
        {
            _memoryCache.TryGetValue(cacheKey, out IEnumerable<StockPrice> prices);

            return prices;
        }
    }
}

