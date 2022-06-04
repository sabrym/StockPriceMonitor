using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitor.Data
{
    public interface IStockRepository
    {
        List<StockSource> GetStockSources();
        IEnumerable<StockPrice> GetStockPrice(int stockSource, int stockId);
    }
}
