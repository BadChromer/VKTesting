using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKAPI.Forms
{
    public class LogInForm : Form
    {
        private ITextBox EmailInput => ElementFactory.GetTextBox(By.XPath("//input[@id='index_email']"), "Email Input");

        private IButton SignInButton => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "Sign In Button");

        public LogInForm() : base(By.Id("index_login"), "LoginForm")
        {

        }

        public void SetEmail(string email) => EmailInput.ClearAndType(email);

        public void ClickSignInButton() => SignInButton.Click();
    }
}
