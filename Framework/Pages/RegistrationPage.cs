using OpenQA.Selenium;

namespace Framework.Pages
{
    public class RegistrationPage : AbstractPage
    {
        public static By UserNameInputLocator = By.Id("user_login");
        public static By EmailInputLocator = By.Id("user_email");
        public static By RegisterButtonLocator = By.Id("wp-submit");
        public static By LoginLinkLocator = By.XPath("//a[@title='Are you lost?']");
       
        public LoginPage OpenLoginPage()
        {
            browser.Click(LoginLinkLocator);
            return new LoginPage();
        }

        public RegistrationPage FillUserNameInput(string name)
        {
            browser.Type(UserNameInputLocator,name);
            return new RegistrationPage();
        }

        public RegistrationPage FillEmailInput(string email)
        {
            browser.Type(EmailInputLocator,email);
            return new RegistrationPage();
        }

        public LoginPage Register()
        {
            browser.Click(RegisterButtonLocator);
            return new LoginPage();
        }
    }
}
