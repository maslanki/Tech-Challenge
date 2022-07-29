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
        public async Task<List<Product>> GetTop5ProductsAsync()
        {
            return await orderManager.GetTop5ProductsAsync();
        }
    }
}
