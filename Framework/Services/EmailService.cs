using Framework.Pages;

namespace Framework.Services
{
    static class EmailService
    {
        public static string CreateEmailAndRegister()
        {
            TempEmailPage tempEmailPage = new TempEmailPage().Open();
            string email = tempEmailPage.GetEmailName();
            tempEmailPage.SelectEmail().OpenWordpressLetter().FollowRegistrationLink();
            return email;
        }
    }
}
