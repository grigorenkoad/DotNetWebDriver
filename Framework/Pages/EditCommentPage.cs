using OpenQA.Selenium;
using Framework.Utils;
using Framework.Pages;

namespace Framework.Pages
{
    class EditCommentPage : DashboardPage
    {
        private static By UserNameLocator = By.Name("newcomment_author");
        private static By UserEmailLocator = By.Name("newcomment_email");
        private static By UserUrlLocator = By.Name("newcomment_url");
        private static By UserCommentLocator = By.Name("content");
        private static By UpdateButtonLocator = By.Id("publish");

        public void EditComment()
        {
            browser.Type(UserNameLocator, StringUtils.GetRandomString(5));
            browser.Type(UserEmailLocator, $"{StringUtils.GetRandomString(5)}@{StringUtils.GetRandomString(5)}.{StringUtils.GetRandomString(2)}");
            browser.Type(UserUrlLocator, $"{StringUtils.GetRandomString(5)}.{StringUtils.GetRandomString(2)}");
            browser.Type(UserCommentLocator, StringUtils.GetRandomString(5));
            browser.Click(UpdateButtonLocator);
        }

    }
}
