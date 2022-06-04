using Microsoft.Extensions.Caching.Memory;
using StockPriceMonitor.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace StockPriceMonitor.Data
{
    public class StockRepository : IStockRepository
    {
        private readonly IMemoryCache _memoryCache;

        public StockRepository(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            StockPriceRandomizer.Init(2, 3);
        }

        public List<StockSource> GetStockSources()
        {
            return new List<StockSource>
            {
                new StockSource
                {
                    Id = 1,
                    Name = "Nikkei",
                    Stocks = new List<Stock>
                    {
                        new Stock
                        {
                            Id = 1,
                            Name = "Mercedes"
                        },
                        new Stock
                        {
                            Id = 2,
                            Name = "McDonalds"
                        },
                        new Stock
                        {
                            Id = 3,
                            Name = "Dialog"
                        }
                    }
                },
                new StockSource
                {
                    Id = 2,
                    Name = "HangSeng",
                    Stocks = new List<Stock>
                    {
                        new Stock
                        {
                            Id = 1,
                            Name = "Volkswagen",
                        },
                        new Stock
                        {
                            Id = 2,
                            Name = "Kamaz"
                        },
                        new Stock
                        {
                            Id = 3,
                            Name = "IKEA"
                        }
                    }
                }
            };
        }

        public IEnumerable<StockPrice> GetStockPrice(int stockSource, int stockId)
        {
            var cacheKey = $"{stockSource}-{stockId}";

            if (_memoryCache.TryGetValue(cacheKey, out IEnumerable<StockPrice> prices))
            {
                return prices;
            }

            prices = StockPriceRandomizer.GenerateStockPricesAsDouble(cacheKey).ToList();

            var cacheExpiryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddSeconds(5),
                Priority = CacheItemPriority.High,
                SlidingExpiration = TimeSpan.FromSeconds(2)
            };

            _memoryCache.Set(cacheKey, prices, cacheExpiryOptions);

            return prices;
        }
    }
}
