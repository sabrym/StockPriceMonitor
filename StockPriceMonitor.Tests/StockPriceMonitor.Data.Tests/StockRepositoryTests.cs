using Microsoft.Extensions.Caching.Memory;
using Moq;
using StockPriceMonitor.Data.Utilities;

namespace StockPriceMonitor.Data.Tests;

public class StockRepositoryTests
{
    private StockRepository _stockRepository;
    private CacheManager _memoryCache;

    [SetUp]
    public void Setup()
    {

        _memoryCache = new Mock<CacheManager>(Mock.Of<IMemoryCache>()).Object;
        _stockRepository = new StockRepository(_memoryCache);
    }

    [Test]
    public void GetStockSources_Always_HasItems()
    {
        var items = _stockRepository.GetStockSources();
        Assert.That(items.Any(), Is.EqualTo(true));
    }

    [Test]
    public void GetStockPrice_Always_GreaterThanZero()
    {
        var items = _stockRepository.GetStockPrice(1,1);
        Assert.That(items.Any(x => x.Price > 0), Is.EqualTo(true));
    }
}
