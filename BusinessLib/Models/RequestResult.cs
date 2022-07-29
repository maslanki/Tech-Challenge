using Newtonsoft.Json;

namespace BusinessLib.Models
{
    public class RequestResult<T>
    {
        [JsonProperty("Content")]
        public List<T> Content { get; set; }

    }
}
