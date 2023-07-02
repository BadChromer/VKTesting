using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKAPI.Forms.Pages
{
    public class ProfilePage : Form
    {

        private ILabel PostContainer(int userId, int postId) => ElementFactory.GetLabel(By.XPath($"//div[@id='post{userId}_{postId}']"), "Post Container");

        private ILabel PostAuthorName(int userId, int postId) => PostContainer(userId, postId).FindChildElement<ILabel>(By.XPath("//a[@class='author']"), "Post Author Name");

        private ILabel PostText(int userId, int postId) => PostContainer(userId, postId).FindChildElement<ILabel>(By.XPath("//div[contains(@class,'wall_post_text')]"), "Post Text");

        private ILabel PostReplies(int userId, int postId) => PostContainer(userId, postId).FindChildElement<ILabel>(By.ClassName("replies"), "Post Replies");

        private ILabel ReplyAuthorName(int userId, int postId) => PostReplies(userId, postId).FindChildElement<ILabel>(By.XPath("//a[@class='author']"), "Reply Author");

        private IButton LikeButton(int userId, int postId) => PostContainer(userId, postId).FindChildElement<IButton>(By.XPath("//div[contains(@class,'PostButtonReactions__icon')]"), "Like Button");

        private IButton ShowNextCommentButton(int userId, int postId) => PostContainer(userId, postId).FindChildElement<IButton>(By.ClassName("js-replies_next_label"), "Show Next Comment Button");

        public ProfilePage() : base(By.ClassName("ProfileHeader__in"), "Profile Page")
        {

        }

        public bool IsPostContainerDisplayed(int userId, int postId)
        {
            return PostContainer(userId, postId).State.WaitForDisplayed();
        }

        public bool WaitUntilPostContainerIsNotDisplayed(int userId, int postId)
        {
            return PostContainer(userId, postId).State.WaitForNotDisplayed();
        }

        public void ClickShowNextCommentButton(int userId, int postId) => ShowNextCommentButton(userId, postId).Click();

        public string GetPostAuthorName(int userId, int postId) => PostAuthorName(userId, postId).Text;

        public string GetPostText(int userId, int postId) => PostText(userId, postId).Text;

        public string GetReplyAuthorName(int userId, int postId) => ReplyAuthorName(userId, postId).Text;

        public void ClickLikeButton(int userId, int postId) => LikeButton(userId, postId).ClickAndWait();
    }
}
