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
    public void GetStockPrice_Always_HasFiveItems()
    {
        var items = _stockRepository.GetStockPrice(1, 1);
        Assert.That(items.Count(), Is.EqualTo(5));
    }

    [Test]
    public void GetStockPrice_AllPrices_GreaterThanZero()
    {
        var items = _stockRepository.GetStockPrice(1,1);
        Assert.That(items.All(x => x.Price > 0), Is.EqualTo(true));
    }

    [Test]
    [TestCase(-1, 1)]
    [TestCase(1, -1)]
    [TestCase(-1, -1)]
    public void GetStockPrice_AllPrices_InvalidInput(int stockSourceId, int stockPriceId)
    {
        var items = _stockRepository.GetStockPrice(stockSourceId, stockPriceId);
        Assert.That(items, Is.EqualTo(null));
    }
}
