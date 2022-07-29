using BusinessLib.Managers.Interfaces;
using BusinessLib.Models;
using System.Net.Http.Json;
using System.Text;

namespace BusinessLib.Managers
{
    public class OrderManager : IOrderManager
    {
        static string apikey = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        static string url = "https://api-dev.channelengine.net/api/v2";
        public async Task<List<Order>> GetInProgressOrdersAsync()
        {
            var address = $"{url}/orders?apikey={apikey}&statuses=IN_PROGRESS";

            var client = new HttpClient();
            var result = await client.GetFromJsonAsync<RequestResult<Order>>(address);
            
            if (result == null) return new List<Order>();

            return result.Content;
        }

        public async Task<List<ProductViewModel>> GetTop5ProductsAsync(List<Order> orders = null)
        {
            if(orders == null) orders = await GetInProgressOrdersAsync();
            var products = FilterTop5Products(orders);

            var address = $"{url}/products?apikey={apikey}";

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
                var resultProduct = result.Content.Where(r => r.MerchantProductNo == p.MerchantProductNo).ToList();

                if(resultProduct != null) p.ProductName = resultProduct.FirstOrDefault().Name;
            }

            return products;
        }

        public async Task SetStock(string merchantProductNo)
        {
            var address = $"{url}/products/{merchantProductNo}?apikey={apikey}";
            var request = "[{\"op\": \"replace\",\"value\": \"25\",\"path\": \"Stock\"}]";
            var content = new StringContent(request, Encoding.UTF8, "application/json-patch+json");

            var httpClient = new HttpClient();
            var response = await httpClient.PatchAsync(address, content);

            try
            {
                response.EnsureSuccessStatusCode();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Seperate method for filtering top 5 products, useful for unit testing
        /// </summary>
        /// <param name="orders"></param>
        /// <returns></returns>
        public List<ProductViewModel> FilterTop5Products(List<Order> orders)
        {
            return orders
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
        }
    }

}