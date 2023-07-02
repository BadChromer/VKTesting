using Newtonsoft.Json;

namespace VKAPI.Models
{
    public class PostResponseModel
    {
        [JsonProperty("response")]
        public PostResponse PostResponse { get; set; }
    }

    public class PostResponse
    {
        [JsonProperty("post_id")]
        public int PostId { get; set; }
    }
}
