using Newtonsoft.Json;

namespace BusinessLib.Models
{
    public class RequestResult
    {
        [JsonProperty("Content")]
        public List<Order> Content { get; set; }

    }
}
