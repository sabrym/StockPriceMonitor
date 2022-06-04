using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitor.Data
{
    public class StockPrice
    {
        public string TimeStamp { get; private set; }

        public double Price { get; private set; }

        internal DateTime DateTime { get; private set; }
        public StockPrice(DateTime time, double price)
        {
            TimeStamp = time.ToString("yyyy-dd-mm HH:mm:ss");
            Price = price;
            DateTime = time;
        }
       
    }
}
