using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace VKAPI.TestingData
{
    public class CredentialsData
    {
        public static ISettingsFile CredentialsDataFile => new JsonSettingsFile("credentials.json");

        public static string Email => CredentialsDataFile.GetValue<string>("email");

        public static string Password => CredentialsDataFile.GetValue<string>("password");

        public static string AccessToken => CredentialsDataFile.GetValue<string>("accessToken");
    }
}
