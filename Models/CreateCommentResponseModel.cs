using Newtonsoft.Json;

namespace VKAPI.Models
{
    public class CreateCommentResponseModel
    {
        [JsonProperty("response")]
        public CommentResponse CommentResponse { get; set; }
    }

    public class CommentResponse
    {
        [JsonProperty("comment_id")]
        public int CommentId { get; set; }

        [JsonProperty("parents_stack")]
        public object[] ParentsStack { get; set; }
    }
}
