
using OpenQA.Selenium;

namespace Framework.Pages
{
    public class EndRegistrationPage : AbstractPage
    {
        private static By NewPasswordInputLocator = By.Id("pass1-text");
        private static By ResetPasswordButtonLocator = By.Id("wp-submit");
        private static By LoginLinkLocator = By.XPath("//a[text()='Log in']");

        public EndRegistrationPage TypeNewPassword(string newPass)
        {
            browser.Type(NewPasswordInputLocator, newPass);
            return new EndRegistrationPage();
        }

        public EndRegistrationPage ResetPassword()
        {
            browser.Click(ResetPasswordButtonLocator);
            return new EndRegistrationPage();
        }

        public DashboardPage ClickLogIn()
        {
            browser.Click(LoginLinkLocator);
            return new DashboardPage();
        }

        public bool IsNewPasswordInputDisplayed()
        {
            return browser.IsElementDisplayed(NewPasswordInputLocator);
        }
    }
}
