using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace VKAPI.Forms
{
    public class AuthForm : Form
    {
        private ITextBox PasswordInput => ElementFactory.GetTextBox(By.XPath("//input[@name='password']"), "Password Input");

        private IButton ContinueButton => ElementFactory.GetButton(By.XPath("//button[@type='submit']"), "Continue Button");

        public AuthForm() : base(By.ClassName("vkc__AuthRoot__contentIn"), "Auth Form")
        {

        }

        public void SetPassword(string password) => PasswordInput.ClearAndType(password);

        public void ClickContinueButton() => ContinueButton.Click();
    }
}
