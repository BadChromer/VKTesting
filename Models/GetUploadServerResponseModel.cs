using Newtonsoft.Json;

namespace VKAPI.Models
{
    public class GetUploadServerResponseModel
    {
        [JsonProperty("response")]
        public ServerResponse ServerResponse { get; set; }
    }

    public class ServerResponse
    {
        [JsonProperty("album_id")]
        public int AlbumId { get; set; }

        [JsonProperty("upload_url")]
        public Uri UploadServerUri { get; set; }

        [JsonProperty("user_id")]
        public int UserId { get; set; }
    }
}
