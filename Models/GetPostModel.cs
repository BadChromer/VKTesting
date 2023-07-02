using Newtonsoft.Json;

namespace VKAPI.Models
{
    public class GetPostModel
    {
        [JsonProperty("response")]
        public GetPostResponse[] GetPostResponse { get; set; }
    }

    public class GetPostResponse
    {
        [JsonProperty("can_edit")]
        public long CanEdit { get; set; }

        [JsonProperty("can_delete")]
        public long CanDelete { get; set; }

        [JsonProperty("can_pin")]
        public long CanPin { get; set; }

        [JsonProperty("donut")]
        public Donut Donut { get; set; }

        [JsonProperty("comments")]
        public Comments Comments { get; set; }

        [JsonProperty("short_text_rate")]
        public double ShortTextRate { get; set; }

        [JsonProperty("hash")]
        public string Hash { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("attachments")]
        public Attachment[] Attachments { get; set; }

        [JsonProperty("can_archive")]
        public bool CanArchive { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("edited")]
        public long Edited { get; set; }

        [JsonProperty("from_id")]
        public long FromId { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }

        [JsonProperty("is_favorite")]
        public bool IsFavorite { get; set; }

        [JsonProperty("likes")]
        public Likes Likes { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("post_source")]
        public PostSource PostSource { get; set; }

        [JsonProperty("post_type")]
        public string PostType { get; set; }

        [JsonProperty("reposts")]
        public Reposts Reposts { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("views")]
        public Views Views { get; set; }
    }

    public class Attachment
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("photo")]
        public Photo Photo { get; set; }
    }

    public class Photo
    {
        [JsonProperty("album_id")]
        public long AlbumId { get; set; }

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("owner_id")]
        public long OwnerId { get; set; }

        [JsonProperty("access_key")]
        public string AccessKey { get; set; }

        [JsonProperty("sizes")]
        public Size[] Sizes { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("has_tags")]
        public bool HasTags { get; set; }
    }

    public class PhotoSize
    {
        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }
    }

    public class Comments
    {
        [JsonProperty("can_post")]
        public long CanPost { get; set; }

        [JsonProperty("can_close")]
        public long CanClose { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("groups_can_post")]
        public bool GroupsCanPost { get; set; }
    }

    public class Donut
    {
        [JsonProperty("is_donut")]
        public bool IsDonut { get; set; }
    }

    public class Likes
    {
        [JsonProperty("can_like")]
        public long CanLike { get; set; }

        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("user_likes")]
        public long UserLikes { get; set; }

        [JsonProperty("can_publish")]
        public long CanPublish { get; set; }

        [JsonProperty("repost_disabled")]
        public bool RepostDisabled { get; set; }
    }

    public class PostSource
    {
        [JsonProperty("type")]
        public string Type { get; set; }
    }

    public class Reposts
    {
        [JsonProperty("count")]
        public long Count { get; set; }

        [JsonProperty("wall_count")]
        public long WallCount { get; set; }

        [JsonProperty("mail_count")]
        public long MailCount { get; set; }

        [JsonProperty("user_reposted")]
        public long UserReposted { get; set; }
    }

    public class Views
    {
        [JsonProperty("count")]
        public long Count { get; set; }
    }
}
