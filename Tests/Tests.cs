using Aquality.Selenium.Browsers;
using VKAPI.API;
using VKAPI.Steps;
using VKAPI.TestingData;
using VKAPI.Utilities;

namespace VKAPI.Tests
{
    public class Tests : BaseTest
    {
        private readonly LogInSteps logInSteps = new();
        private readonly FeedPageSteps feedPageSteps = new();
        private readonly ProfilePageSteps profilePageSteps = new();

        [Test]
        public void CheckPostManipulations()
        {
            string firstRandomString = RandomGenerator.GenerateRandomString(TestData.StringLength);
            string secondRandomString = RandomGenerator.GenerateRandomString(TestData.StringLength);
            AqualityServices.Logger.Info("Step 1 - Go to the homepage webpage");
            logInSteps.LogInFormIsPresent();
            AqualityServices.Logger.Info("Step 2 - Authorize");
            logInSteps.LogIn(CredentialsData.Email, CredentialsData.Password);
            feedPageSteps.FeedPageIsPresent();
            AqualityServices.Logger.Info("Step 3 - Go to My profile");
            feedPageSteps.ClickMyProfileLinkButton();
            profilePageSteps.ProfilePageIsPresent();
            AqualityServices.Logger.Info("Step 4 - Create post on the wall with randomly generated text using API-request and save id of the post from the API-response");
            var responseCreate = VkApiUtils.CreatePost(firstRandomString);
            profilePageSteps.CheckIfPostContainerDisplayed(TestData.UserId, responseCreate.PostId);
            AqualityServices.Logger.Info("Step 5 - Check that post with the sent text from the correct user appeared on the wall without refreshing the page");
            profilePageSteps.CheckIfPostAuthorNameIsCorrect(responseCreate.PostId);
            profilePageSteps.CheckIfPostTextIsCorrect(firstRandomString, responseCreate.PostId);
            AqualityServices.Logger.Info("Step 6 - Edit the added post using API-request - change text and add (upload) a picture");
            var responseUploadPhoto = VkApiUtils.UploadFile(VkApiUtils.GetWallUploadServer().ServerResponse.UploadServerUri, TestData.FileType);
            var responseSavePhoto = VkApiUtils.SaveUploadWallPhoto(responseUploadPhoto.Photo, responseUploadPhoto.Server, responseUploadPhoto.Hash);
            VkApiUtils.EditPost(TestData.FileType, responseCreate.PostId, secondRandomString, responseSavePhoto.OwnerId, responseSavePhoto.Id);
            AqualityServices.Logger.Info("Step 7 - Check that text was updated and the picture was uploaded (make sure that pictures are the same) without refreshing the page");
            profilePageSteps.WaitUntilTextUpdated(firstRandomString, TestData.UserId, responseCreate.PostId);
            profilePageSteps.CheckIfPostTextIsCorrect(secondRandomString, responseCreate.PostId);
            var responseGetPostAttachments = VkApiUtils.GetPostAttachments(TestData.UserId, responseCreate.PostId);
            ApiHelper.DownloadFile(responseGetPostAttachments.Photo.Sizes.First(size => size.Width == TestData.ImageWidth).Url, TestData.PathToDownloadFile);
            profilePageSteps.CheckIfImagesAreSame();
            AqualityServices.Logger.Info("Step 8 - Add a comment to the post with the randomly generated text using API-request");
            VkApiUtils.CreateComment(TestData.UserId, responseCreate.PostId, RandomGenerator.GenerateRandomString(TestData.StringLength));
            AqualityServices.Logger.Info("Step 9 - Check that comment from the correct user was added to the post without refreshing the page");
            profilePageSteps.ClickShowNextCommentButton(TestData.UserId, responseCreate.PostId);
            profilePageSteps.CheckIfReplyAuthorNameIsCorrect(responseCreate.PostId);
            AqualityServices.Logger.Info("Step 10 - Like the post using UI");
            profilePageSteps.ClickLikeButton(TestData.UserId, responseCreate.PostId);
            AqualityServices.Logger.Info("Step 11 - Check that the post received like from the correct user using API-request");
            var responseLikes = VkApiUtils.GetLikes(TestData.UserId, responseCreate.PostId);
            profilePageSteps.CheckIfLikeFromCorrectUser(responseLikes.LikesResponse.Users.FirstOrDefault().Uid);
            AqualityServices.Logger.Info("Step 12 - Delete the post using API-request");
            VkApiUtils.DeletePost(TestData.UserId, responseCreate.PostId);
            AqualityServices.Logger.Info("Step 13 - Check that the post was deleted without refreshing the page");
            profilePageSteps.CheckIfPostContainerIsNotDisplayed(TestData.UserId, responseCreate.PostId);
        }
    }
}
