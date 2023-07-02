using VKAPI.Extensions;
using VKAPI.Forms.Pages;

namespace VKAPI.Steps
{
    public class FeedPageSteps : BaseSteps
    {
        private readonly FeedPage feedPage;

        public FeedPageSteps() => feedPage = new();

        public void FeedPageIsPresent()
        {
            LogAssertion();
            feedPage.AssertIsFormPresent();
        }

        public void ClickMyProfileLinkButton()
        {
            LogStep();
            feedPage.ClickMyProfileLinkButton();
        }
    }
}
