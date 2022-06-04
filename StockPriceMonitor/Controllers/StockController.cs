using Microsoft.AspNetCore.Mvc;
using StockPriceMonitor.Data;

namespace StockPriceMonitor.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly ILogger<StocksController> _logger;
        private readonly IStockRepository _stockRepository;
        public StocksController(ILogger<StocksController> logger, IStockRepository stockRepository)
        {
            _logger = logger;
            _stockRepository = stockRepository;
        }

        [HttpGet]
        public IEnumerable<StockSource> Get()
        {

            return _stockRepository.GetStockSources();
        }

        [HttpGet("get-prices/{source}/{stockid}")]
        public IEnumerable<StockPrice> GetPrices(int source, int stockId)
        {

            return _stockRepository.GetStockPrice(source, stockId);
        }
    }
}