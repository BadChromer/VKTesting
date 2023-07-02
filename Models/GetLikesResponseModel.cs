using Newtonsoft.Json;

namespace VKAPI.Models
{
    public class GetLikesResponseModel
    {
        [JsonProperty("response")]
        public LikesResponse LikesResponse { get; set; }
    }

    public class LikesResponse
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("users")]
        public User[] Users { get; set; }
    }

    public class User
    {
        [JsonProperty("uid")]
        public int Uid { get; set; }

        [JsonProperty("copied")]
        public int Copied { get; set; }
    }
}
