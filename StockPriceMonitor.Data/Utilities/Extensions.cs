using System;

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
