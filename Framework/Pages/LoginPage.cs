using OpenQA.Selenium;

namespace Framework.Pages
{
    public class LoginPage : AbstractPage
    {
        public static By UserNameInputLicator = By.Id("user_login");
        public static By PasswordInputLocator = By.Id("user_pass");
        public static By RememberMeLocator = By.Id("rememberme");
        public static By LoginButtonLocator = By.Id("wp-submit");

        public static By LoginErrorMessageLocator = By.Id("login_error");
        public static By RegisterLinkLocator = By.Id("//a[text()='Register']");

        public DashboardPage Login()
        {
            browser.Click(LoginButtonLocator);
            return new DashboardPage();
        }

        public RegistrationPage OpenRegistrationPage()
        {
            browser.Click(RegisterLinkLocator);
            return new RegistrationPage();
        }

        public LoginPage FillUserNameInput(string name)
        {
            browser.Type(UserNameInputLicator, name);
            return new LoginPage();
        }

        public LoginPage FillPasswordInput(string pass)
        {
            browser.Type(PasswordInputLocator, pass);
            return new LoginPage();
        }

        public bool IsErrorMessageDisplayed()
        {
            return browser.IsElementDisplayed(LoginErrorMessageLocator);
        }
    }
}
