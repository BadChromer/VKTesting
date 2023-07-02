using Aquality.Selenium.Browsers;
using VKAPI.Extensions;
using VKAPI.Forms.Pages;
using VKAPI.TestingData;
using VKAPI.Utilities;

namespace VKAPI.Steps
{
    public class ProfilePageSteps : BaseSteps
    {
        private readonly ProfilePage profilePage;

        public ProfilePageSteps() => profilePage = new();

        public void ClickShowNextCommentButton(int userId, int postId)
        {
            LogStep();
            profilePage.ClickShowNextCommentButton(userId, postId);
        }

        public string GetPostAuthorName(int userId, int postId)
        {
            LogStep();
            return profilePage.GetPostAuthorName(userId, postId);
        }

        public string GetPostText(int userId, int postId)
        {
            LogStep();
            return profilePage.GetPostText(userId, postId);
        }

        public bool WaitUntilTextUpdated(string randomString, int userId, int postId)
        {
            return AqualityServices.ConditionalWait.WaitFor(() => GetPostText(userId, postId) != randomString);
        }

        public string GetReplyAuthorName(int userId, int postId)
        {
            LogStep();
            return profilePage.GetReplyAuthorName(userId, postId);
        }

        public void ClickLikeButton(int userId, int postId)
        {
            LogStep();
            profilePage.ClickLikeButton(userId, postId);
        }

        public void CheckIfReplyAuthorNameIsCorrect(int postId)
        {
            LogAssertion();
            StringAssert.Contains(TestData.UserName, GetReplyAuthorName(TestData.UserId, postId), "Reply author name is not correct");
        }

        public void CheckIfPostAuthorNameIsCorrect(int postId)
        {
            LogAssertion();
            StringAssert.Contains(TestData.UserName, GetPostAuthorName(TestData.UserId, postId), "Post author name is not correct");
        }

        public void CheckIfPostTextIsCorrect(string randomString, int postId)
        {
            LogAssertion();
            StringAssert.Contains(randomString, GetPostText(TestData.UserId, postId), "Post text is not correct");
        }

        public void CheckIfLikeFromCorrectUser(int userId)
        {
            LogAssertion();
            Assert.That(TestData.UserId, Is.EqualTo(userId), "Like is not from correct user");
        }

        public void ProfilePageIsPresent()
        {
            LogAssertion();
            profilePage.AssertIsFormPresent();
        }

        public void CheckIfPostContainerDisplayed(int userId, int postId)
        {
            LogAssertion();
            Assert.That(profilePage.IsPostContainerDisplayed(userId, postId), Is.True, "Post container should be displayed");
        }

        public void CheckIfPostContainerIsNotDisplayed(int userId, int postId)
        {
            LogAssertion();
            Assert.That(profilePage.WaitUntilPostContainerIsNotDisplayed(userId, postId), Is.True, "Post container should not be displayed");
        }

        public void CheckIfImagesAreSame()
        {
            LogAssertion();
            Assert.That(CustomImageComparator.AreImagesEqual(TestData.PathToUploadFile, TestData.PathToDownloadFile), Is.True, "Messages are not equal");
        }
    }
}
