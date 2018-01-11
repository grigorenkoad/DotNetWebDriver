using OpenQA.Selenium;

namespace Framework.Pages
{
    public class DashboardPage : UpperMenuScreen
    {
        public static By PostsLocator = By.Id("menu-posts");
        public static By CommentsLocator = By.Id("menu-comments");

        public static By DashboardLocator = By.Id("wp-menu-name");

        public PostsPage OpenPostsPage()
        {
            browser.Click(PostsLocator);
            return new PostsPage();
        }

        public CommentsPage OpenCommentsPage()
        {
            browser.Click(PostsLocator);
            return new CommentsPage();
        }
        
        public bool IsDashboardLocatorDisplayed()
        {
            return browser.IsElementDisplayed(DashboardLocator);
        }
    }
}
