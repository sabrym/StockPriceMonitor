using Microsoft.Extensions.Caching.Memory;
using StockPriceMonitor.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockPriceMonitor.Data
{
    public class StockRepository : IStockRepository
    {
        private readonly CacheManager _cacheManager;

        public StockRepository(CacheManager cacheManager)
        {
            _cacheManager = cacheManager;
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

        public IEnumerable<StockPrice> GetStockPrice(int stockSource, int stockId, bool useCache = false)
        {
            var cacheKey = $"{stockSource}-{stockId}";

            var prices = useCache ? _cacheManager.GetValueOrDefault(cacheKey) : Enumerable.Empty<StockPrice>();
            if (prices != null && prices.Any())
            {
                return prices;
            }

            prices = StockPriceRandomizer.GenerateStockPricesAsDouble(cacheKey).ToList();

            if (useCache)
            {
                _cacheManager.AddToCache(cacheKey, prices);
            }

            return prices;
        }
    }
}
