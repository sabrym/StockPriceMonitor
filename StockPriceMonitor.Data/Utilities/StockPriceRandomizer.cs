using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace StockPriceMonitor.Data.Utilities
{
    internal static class StockPriceRandomizer
    {
        static Dictionary<string, List<int>> keyValuePairs;
        public static void Init(int sourceSize, int stockSize)
        {
            keyValuePairs = new Dictionary<string, List<int>>();
            for (int i = 1; i < sourceSize + 1; i++)
            {
                for (int j = 1; j < stockSize + 1; j++)
                {
                    var priceRandomizer = new Random().Next(500) + 2;

                    keyValuePairs.Add($"{i}-{j}", new List<int> { priceRandomizer - 1, priceRandomizer });
                }
            }
        }

        public static IEnumerable<StockPrice> GenerateStockPricesAsDouble(string key, int length = 5)
        {
            var priceVariant = keyValuePairs.GetValueOrDefault(key);
            var priceRandomizer = new Random();
            var sleepRandomizer = new Random();
            var prices = new List<StockPrice>();

            for (int i = 0; i < length; i++)
            {
                var randomSleep = sleepRandomizer.Next(5);

                prices.Add(new StockPrice(DateTime.Now.AddSeconds(randomSleep), Math.Round(priceRandomizer.NextDouble(priceVariant.First(), priceVariant.Last()), 2)));
            }

            return prices.OrderByDescending(x => x.DateTime);
        }
    }
}
