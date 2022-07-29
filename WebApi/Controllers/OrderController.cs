using BusinessLib.Managers.Interfaces;
using BusinessLib.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> logger;
        private readonly IOrderManager orderManager;
        public OrderController(ILogger<OrderController> logger, IOrderManager orderManager)
        {
            this.logger = logger;
            this.orderManager = orderManager;
        }

        [HttpGet, Route("InProgress")]
        public async Task<List<Order>> GetInProgressOrdersAsync()
        {
            return await orderManager.GetInProgressOrdersAsync();
        }

        [HttpGet, Route("Top5Products")]
        public async Task<List<ProductViewModel>> GetTop5ProductsAsync()
        {
            return await orderManager.GetTop5ProductsAsync();
        }

        [HttpPatch, Route("Set25Stock")]
        public async Task Set25StockAsync([FromQuery] string merchantProductNo)
        {
            try
            {
                await orderManager.SetStock(merchantProductNo);
            }
            catch(Exception e)
            {
                logger.LogError(new EventId(), e.Message);
            }
        }
    }
}
