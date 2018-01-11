using Framework.BO;
using Framework.Pages;

namespace Framework.Services
{
    public class RegistrationService
    {
        public static Account RegisterNewUser(Account account)
        {
            account.Email = EmailService.CreateEmailAndRegister();
            new RegistrationPage().FillUserNameInput(account.Name).FillEmailInput(account.Email).Register();
            return account;
        }

        public static Account EndRegisterNewUser(Account account)
        {
            new EndRegistrationPage().TypeNewPassword(account.Password).ClickLogIn();
            return account;
        }

        public static bool IsNewPasswordDisplayed()
        {
            return new EndRegistrationPage().IsNewPasswordInputDisplayed();
        }
    }
}
