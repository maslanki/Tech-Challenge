using BusinessLib.Managers.Interfaces;
using BusinessLib.Models;
using System.Net.Http.Json;
using System.Text;

namespace BusinessLib.Managers
{
    public class OrderManager : IOrderManager
    {
        static string apikey = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";

        public async Task<List<Order>> GetInProgressOrdersAsync()
        {
            var address = $"https://api-dev.channelengine.net/api/v2/orders?apikey={apikey}&statuses=IN_PROGRESS";

            var client = new HttpClient();
            var result = await client.GetFromJsonAsync<RequestResult<Order>>(address);
            
            if (result == null) return new List<Order>();

            return result.Content;
        }

        public async Task<List<ProductViewModel>> GetTop5ProductsAsync(List<Order> orders = null)
        {
            if(orders == null) orders = await GetInProgressOrdersAsync();

            var products = orders
                .SelectMany(o => o.Lines)
                .GroupBy(l => l.MerchantProductNo)
                .Select(g => new ProductViewModel
                {
                    MerchantProductNo = g.Key,
                    Gtin = g.FirstOrDefault().Gtin,
                    TotalQuantity = g.Sum(c => c.Quantity)
                })
                .OrderByDescending(g => g.TotalQuantity)
                .Take(5)
                .ToList();

            var address = $"https://api-dev.channelengine.net/api/v2/products?apikey={apikey}";

            var builder = new StringBuilder(address);
            foreach(var p in products)
            {
                builder.Append("&merchantProductNoList=");
                builder.Append(p.MerchantProductNo);
            }

            var client = new HttpClient();
            var result = await client.GetFromJsonAsync<RequestResult<Product>>(builder.ToString());
            
            foreach(var p in products)
            {
                p.ProductName = result.Content.FirstOrDefault(r => r.MerchantProductNo == p.MerchantProductNo).Name;
            }

            return products;
        }
    }

}