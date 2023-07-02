using Newtonsoft.Json;

namespace VKAPI.Models
{
    public class UploadFileResponseModel
    {
        [JsonProperty("server")]
        public int Server { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }
    }
}
