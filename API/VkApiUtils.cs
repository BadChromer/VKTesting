using RestSharp;
using VKAPI.Configurations;
using VKAPI.Models;
using VKAPI.TestingData;
using VKAPI.Utilities;

namespace VKAPI.API
{
    public static class VkApiUtils
    {
        public static RestClient restClient = new(ApiConfigData.ApiUrl);

        public static PostResponse CreatePost(string message)
        {
            var request = new RestRequest(ApiConfigData.WallPostEndpoint);
            request.AddParameter("message", message);
            return ApiHelper.Execute<PostResponseModel>(restClient, request, Method.Post, TestData.Interval, TestData.Timeout).PostResponse;
        }

        public static GetUploadServerResponseModel GetWallUploadServer()
        {
            var request = new RestRequest(ApiConfigData.PhotosGetWallUploadServerEndpoint);
            return ApiHelper.Execute<GetUploadServerResponseModel>(restClient, request, Method.Post, TestData.Interval, TestData.Timeout);
        }

        public static UploadFileResponseModel UploadFile(Uri uploadServer, string fileType)
        {
            var request = new RestRequest(uploadServer);
            request.AddFile(fileType, TestData.PathToUploadFile, TestData.ContentType);
            return ApiHelper.Execute<UploadFileResponseModel>(restClient, request, Method.Post, TestData.Interval, TestData.Timeout);
        }

        public static PhotoResponse SaveUploadWallPhoto(string photo, int server, string hash)
        {
            var request = new RestRequest(ApiConfigData.PhotosSaveWallPhotoEndpoint);
            request.AddParameter("server", server);
            request.AddParameter("photo", photo);
            request.AddParameter("hash", hash);
            return ApiHelper.Execute<SavePhotoResponseModel>(restClient, request, Method.Post, TestData.Interval, TestData.Timeout).PhotoResponse.FirstOrDefault();
        }

        public static PostResponseModel EditPost(string fileType, int postId, string message, int userId, int photoId)
        {
            var request = new RestRequest(ApiConfigData.WallEditEndpoint);
            request.AddParameter("post_id", postId);
            request.AddParameter("message", message);
            request.AddParameter("attachments", $"{fileType}{userId}_{photoId}");
            return ApiHelper.Execute<PostResponseModel>(restClient, request, Method.Post, TestData.Interval, TestData.Timeout);
        }

        public static CreateCommentResponseModel CreateComment(int userId, int postId, string message)
        {
            var request = new RestRequest(ApiConfigData.WallCreateCommentEndpoint);
            request.AddParameter("owner_id", userId);
            request.AddParameter("post_id", postId);
            request.AddParameter("message", message);
            return ApiHelper.Execute<CreateCommentResponseModel>(restClient, request, Method.Post, TestData.Interval, TestData.Timeout);
        }

        public static GetLikesResponseModel GetLikes(int userId, int postId)
        {
            var request = new RestRequest(ApiConfigData.WallGetLikesEndpoint);
            request.AddParameter("owner_id", userId);
            request.AddParameter("post_id", postId);
            return ApiHelper.Execute<GetLikesResponseModel>(restClient, request, Method.Get, TestData.Interval, TestData.Timeout);
        }

        public static Attachment GetPostAttachments(int userId, int postId)
        {
            var request = new RestRequest(ApiConfigData.WallGetById);
            request.AddParameter("posts", $"{userId}_{postId}");
            return ApiHelper.Execute<GetPostModel>(restClient, request, Method.Get, TestData.Interval, TestData.Timeout).GetPostResponse.FirstOrDefault().Attachments.FirstOrDefault();
        }

        public static DeletePostResponseModel DeletePost(int userId, int postId)
        {
            var request = new RestRequest(ApiConfigData.WallDeleteEndpoint);
            request.AddParameter("owner_id", userId);
            request.AddParameter("post_id", postId);
            return ApiHelper.Execute<DeletePostResponseModel>(restClient, request, Method.Post, TestData.Interval, TestData.Timeout);
        }
    }
}
