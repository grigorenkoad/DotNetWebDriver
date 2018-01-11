
using System;
using OpenQA.Selenium;

namespace Framework.Pages
{
    class FeedPage : MainPage
    {
        private static string PostHeaderLocatorPattern = "//h2[@class='entry-title']/a[text()='{0}']";
        private static string PostIdLocatorPattern = "//artcile[@id='{0}']";

        public OpenedPostPage OpenPost(string postName)
        {
            browser.Click(By.XPath(String.Format(PostHeaderLocatorPattern, postName)));
            return new OpenedPostPage();
        }

        public bool IsPostDisplayed(string postId)
        {
            return browser.IsElementDisplayed(By.XPath(String.Format(PostIdLocatorPattern, postId)));
        }

    }
}


