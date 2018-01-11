using Framework.BO;
using Framework.Pages;

namespace Framework.Services
{
    public class LoginService
    {
        public static Account Login(Account account)
        {
            new MainPage().OpenLoginPage().FillUserNameInput(account.Name).FillPasswordInput(account.Password).Login();
            return account;
        }

        public static bool IsErrorMessageDisplayed()
        {
            return new MainPage().OpenLoginPage().IsErrorMessageDisplayed();
        }

        public static bool IsDashboardDisplayed()
        {
            return new DashboardPage().IsDashboardLocatorDisplayed();
        }
    }
}
