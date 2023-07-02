using Newtonsoft.Json;

namespace VKAPI.Models
{
    public class DeletePostResponseModel
    {
        [JsonProperty("response")]
        public int DeletePostResponse { get; set; }
    }
}
