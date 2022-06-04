using System;
using System.Collections.Generic;

namespace StockPriceMonitor.Data
{
    public class Stock
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<StockPrice> StockPrices { get; set; }
    }
}
