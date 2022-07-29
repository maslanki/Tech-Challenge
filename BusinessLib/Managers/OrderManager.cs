using BusinessLib.Managers.Interfaces;
using BusinessLib.Models;
using System.Net.Http.Json;

namespace BusinessLib.Managers
{
    public class OrderManager : IOrderManager
    {
        static string apikey = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        static string address = $"https://api-dev.channelengine.net/api/v2/orders?apikey={apikey}&statuses=IN_PROGRESS";

        public async Task<List<Order>> GetInProgressOrdersAsync()
        {
            var client = new HttpClient();
            var result = await client.GetFromJsonAsync<RequestResult>(address);
            
            if (result == null) return new List<Order>();

            return result.Content;
        }

        public async Task<List<Product>> GetTop5Products(List<Order> orders = null)
        {
            if(orders == null) orders = await GetInProgressOrdersAsync();

            //I assume GTIN is an ID of the product (?)
            //what about description? same GTIN gives different descriptions

            var products = orders
                .SelectMany(o => o.Lines)
                .GroupBy(l => l.Gtin)
                .Select(g => new Product
                {
                    Gtin = g.Key,
                    ProductName = g.FirstOrDefault().Description,
                    TotalQuantity = g.Sum(c => c.Quantity)
                })
                .OrderByDescending(g => g.TotalQuantity);

            return products.Take(5).ToList();
        }
    }

}