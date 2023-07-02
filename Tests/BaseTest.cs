using Aquality.Selenium.Browsers;
using VKAPI.Configurations;

namespace VKAPI.Tests
{
    public abstract class BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            AqualityServices.Browser.GoTo(ConfigData.BaseUrl);
            AqualityServices.Browser.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            AqualityServices.Browser.Quit();
        }
    }
}
