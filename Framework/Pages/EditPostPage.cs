using OpenQA.Selenium;

namespace Framework.Pages
{
    public class EditPostPage : DashboardPage
    {
        public static By TitleInputLocator = By.Id("title");
        public static By ContentInputLocator = By.Id("content");
        public static By UpdateButtonLocator = By.Id("publish");

        public EditPostPage ClickUpdateButton()
        {
            browser.Click(UpdateButtonLocator);
            return new EditPostPage();
        }

        public EditPostPage FillTitleInput(string text)
        {
            browser.Type(TitleInputLocator, text);
            return new EditPostPage();
        }

        public EditPostPage FillContentInput(string text)
        {
            browser.Type(TitleInputLocator, text);
            return new EditPostPage();
        }
    }
}
