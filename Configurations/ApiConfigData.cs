using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace VKAPI.Configurations
{
    public class ApiConfigData
    {
        public static ISettingsFile ApiConfigDataFile => new JsonSettingsFile("apiConfiguration.json");

        public static string WallPostEndpoint => ApiConfigDataFile.GetValue<string>("wallPostEndpoint");

        public static string WallEditEndpoint => ApiConfigDataFile.GetValue<string>("wallEditEndpoint");

        public static string WallDeleteEndpoint => ApiConfigDataFile.GetValue<string>("wallDeleteEndpoint");

        public static string WallCreateCommentEndpoint => ApiConfigDataFile.GetValue<string>("wallCreateCommentEndpoint");

        public static string WallGetLikesEndpoint => ApiConfigDataFile.GetValue<string>("wallGetLikesEndpoint");

        public static string WallGetById => ApiConfigDataFile.GetValue<string>("wallGetById");

        public static string PhotosGetWallUploadServerEndpoint => ApiConfigDataFile.GetValue<string>("photosGetWallUploadServerEndpoint");

        public static string PhotosSaveWallPhotoEndpoint => ApiConfigDataFile.GetValue<string>("photosSaveWallPhotoEndpoint");

        public static string ApiUrl => ApiConfigDataFile.GetValue<string>("apiUrl");

        public static string ApiVersion => ApiConfigDataFile.GetValue<string>("apiVersion");
    }
}
