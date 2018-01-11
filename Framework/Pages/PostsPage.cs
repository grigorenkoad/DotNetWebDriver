
using System;
using Framework.BO;
using OpenQA.Selenium;

namespace Framework.Pages
{
    public class PostsPage :  DashboardPage
    {
        private string TrashButtonLocatorPattern = "//a[text()='{0}']/../../div[@class='row-actions']/span[@class='trash']/a";
        private string EditButtonLocatorPattern = "//a[text()='{0}']/../../div[@class='row-actions']/span[@class='edit']/a";
        private string PostTitleLocatorPattern = "//a[text()='{0}']";

        public PostsPage ClickToTrash(Post post)
        {
            browser.MouseOver(By.XPath(String.Format(PostTitleLocatorPattern, post.Header)));
            browser.Click(By.XPath(String.Format(TrashButtonLocatorPattern, post.Header)));
            return new PostsPage();
        }

        public EditPostPage ClickToEdit(Post post)
        {
            browser.MouseOver(By.XPath(String.Format(PostTitleLocatorPattern, post.Header)));
            browser.Click(By.XPath(String.Format(EditButtonLocatorPattern, post.Header)));
            return new EditPostPage();
        }
    }
}
