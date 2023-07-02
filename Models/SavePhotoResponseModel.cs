using Newtonsoft.Json;

namespace VKAPI.Models
{
    public class SavePhotoResponseModel
    {
        [JsonProperty("response")]
        public PhotoResponse[] PhotoResponse { get; set; }
    }

    public class PhotoResponse
    {
        [JsonProperty("album_id")]
        public int AlbumId { get; set; }

        [JsonProperty("date")]
        public int Date { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("owner_id")]
        public int OwnerId { get; set; }

        [JsonProperty("access_key")]
        public string AccessKey { get; set; }

        [JsonProperty("sizes")]
        public Size[] Sizes { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("has_tags")]
        public string HasTags { get; set; }
    }

    public class Size
    {
        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }
}
