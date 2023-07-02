using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace VKAPI.Configurations
{
    public static class ConfigData
    {
        public static ISettingsFile ConfigDataFile => new JsonSettingsFile("configuration.json");

        public static string BaseUrl => ConfigDataFile.GetValue<string>("baseUrl");
    }
}
