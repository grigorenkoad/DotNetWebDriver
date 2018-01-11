using OpenQA.Selenium;

namespace Framework.Pages
{
    public class OpenedPostPage : MainPage

    {
        private static By PostHeaderLocator = By.ClassName("entry-title");
        private static By PostBodyLocator = By.XPath("//div[@class='entry-content']/p");
        private static By PostDateLocator = By.XPath("//time[@class='entry-date published updated']");
        private static By PostAuthorLocator = By.XPath("//span[@class='author vcard']/a");

        public string GetPostHeader()
        {
            return browser.Read(PostHeaderLocator);
        }

        public string GetPostBody()
        {
            return browser.Read(PostBodyLocator);
        }

        public string GetPostDate()
        {
            return browser.Read(PostDateLocator);
        }

        public string GetPostAuthor()
        {
            return browser.Read(PostAuthorLocator);
        }

    }
}
