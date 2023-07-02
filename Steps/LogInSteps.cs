using VKAPI.Extensions;
using VKAPI.Forms;

namespace VKAPI.Steps
{
    public class LogInSteps : BaseSteps
    {
        private readonly LogInForm loginForm;
        private readonly AuthForm authForm;

        public LogInSteps()
        {
            loginForm = new();
            authForm = new();
        }

        public void LogInFormIsPresent()
        {
            LogAssertion();
            loginForm.AssertIsFormPresent();
        }

        public void AuthFormIsPresent()
        {
            LogAssertion();
            authForm.AssertIsFormPresent();
        }

        public void SetEmail(string email)
        {
            LogStep();
            loginForm.SetEmail(email);
        }

        public void ClickSignInButton()
        {
            LogStep();
            loginForm.ClickSignInButton();
        }

        public void SetPassword(string password)
        {
            LogStep();
            authForm.SetPassword(password);
        }

        public void ClickContinueButton()
        {
            LogStep();
            authForm.ClickContinueButton();
        }

        public void LogIn(string email, string password)
        {
            SetEmail(email);
            ClickSignInButton();
            SetPassword(password);
            ClickContinueButton();
        }
    }
}
