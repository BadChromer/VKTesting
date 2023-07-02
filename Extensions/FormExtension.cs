using Aquality.Selenium.Forms;

namespace VKAPI.Extensions
{
    public static class FormExtension
    {
        public static void AssertIsFormPresent(this Form form) => Assert.That(form.State.WaitForDisplayed(), Is.True, $"{form.Name} should be presented");
    }
}
