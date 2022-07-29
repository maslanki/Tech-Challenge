using BusinessLib.Managers.Interfaces;
using BusinessLib.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApi.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IOrderManager orderManager;
        public IList<Order> orders { get; set; }
        public IList<ProductViewModel> products { get; set; }
       
        public IndexModel(ILogger<IndexModel> logger, IOrderManager orderManager)
        {
            _logger = logger;
            this.orderManager = orderManager;
        }

        public async Task OnGetAsync()
        {
            orders = await orderManager.GetInProgressOrdersAsync();
            products = await orderManager.GetTop5ProductsAsync();
        }

        public async Task OnPostAsync()
        {
            var merchantProductNo = Request.Form["merchantProductNo"].FirstOrDefault();
            try
            {
                await orderManager.SetStock(merchantProductNo);
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
        }
    }
}