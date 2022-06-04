using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockPriceMonitor.Data.Utilities
{
    public static class Extensions
    {
        public static double NextDouble(this Random randomizer, double minValue, double maxValue)
        {
            var generatedBaseValue = randomizer.NextDouble();
            return generatedBaseValue * (maxValue - minValue) + minValue;
        }
    }
}
