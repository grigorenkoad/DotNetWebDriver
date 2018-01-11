using OpenQA.Selenium;

namespace Framework.Pages
{
    public class UpperMenuScreen : AbstractPage
    {
        public static By AddNewPostLocator = By.Id("wp-admin-bar-new-content");

        public EditPostPage OpenAddPostPage()
        {
            browser.Click(AddNewPostLocator);
            return new EditPostPage();
        }

    }
}
