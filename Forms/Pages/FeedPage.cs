using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKAPI.Forms.Pages
{
    public class FeedPage : Form
    {
        private ILink MyProfileLinkButton => ElementFactory.GetLink(By.XPath("//li[@id='l_pr']"), "My Profile Link Button");

        public FeedPage() : base(By.Id("main_feed"), "Feed Page")
        {

        }

        public void ClickMyProfileLinkButton() => MyProfileLinkButton.Click();
    }
}
