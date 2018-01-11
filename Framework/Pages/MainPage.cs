using Framework.WebdriverAddons;
using OpenQA.Selenium;

namespace Framework.Pages
{
    public class MainPage : UpperMenuScreen
    {
        /// <summary>
        /// Web app was on some CMS. Application is something like news feed, where you can post some news and comment them
        /// </summary>
        static string url = "http://5.101.99.64/"; // It was temporary web app for learning

        public static By RegisterLinkLocator = By.XPath("//a[text()='Register']");
        public static By LoginLinkLocator = By.XPath("//a[text()='Log in']");
        public static By LogoutLinkLocator = By.XPath("//a[text()='Log out']");
        public static By AdminLinkLocator = By.XPath("//a[text()='Site Admin']");

        public static MainPage Open()
        {
            Browser.Get().GoTo(url);
            return new MainPage();
        }

        public RegistrationPage OpenRegisterPage()
        {
            browser.Click(RegisterLinkLocator);
            return new RegistrationPage();
        }

        public LoginPage OpenLoginPage()
        {
            browser.Click(LoginLinkLocator);
            return new LoginPage();
        }

        public DashboardPage OpenDashboardPage()
        {
            browser.Click(AdminLinkLocator);
            return new DashboardPage();
        }
    }
}
