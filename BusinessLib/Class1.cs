namespace BusinessLib
{
    
    public class Class1
    {
        static string apikey = "541b989ef78ccb1bad630ea5b85c6ebff9ca3322";
        static string address = $"https://api-dev.channelengine.net/api/v2/orders/new?apikey=541b989ef78ccb1bad630ea5b85c6ebff9ca3322";



        public async Task<string> Get()
        {
            return await GetExternalResponse();

        }
        
        private async Task<string> GetExternalResponse()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(address);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    }
}