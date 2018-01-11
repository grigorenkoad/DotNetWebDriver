using OpenQA.Selenium;
using System;

namespace Framework.Pages
{
    public class CommentsPage : DashboardPage
    {
        private string TrashButtonLocatorPattern = "//a[text()='{0}']/../../div[@class='row-actions']/span[@class='trash']/a";
        private string EditButtonLocatorPattern = "//a[text()='{0}']/../../div[@class='row-actions']/span[@class='edit']/a";
        private string CommentTitleLocatorPattern = "//a[text()='{0}']";

        private static By UserNameLocator = By.Name("author");
        private static By UserEmailLocator = By.Name("email");
        private static By UserUrlLocator = By.Name("url");
        private static By UserCommentLocator = By.Name("comment");
        private static By SubmitLocator = By.Name("submit");
        private static By LoggedAsLocator = By.ClassName("logged-in-as");

        public bool IsCommentDisplayed(string commentText)
        {
            return browser.IsElementDisplayed(By.XPath(String.Format(CommentTitleLocatorPattern, commentText)));
        }

        public bool IsUserLogged()
        {
            return browser.IsElementPresent(LoggedAsLocator);
        }

        public CommentsPage InputCommentText (string commentText)
        {
            browser.Type(UserCommentLocator, commentText);
            return new CommentsPage();
        }

        public CommentsPage InputUserName(string userName)
        {
            browser.Type(UserNameLocator, userName);
            return new CommentsPage();
        }

        public CommentsPage InputUserEmail(string userEmail)
        {
            browser.Type(UserEmailLocator, userEmail);
            return new CommentsPage();
        }

        public CommentsPage InputUserUrl(string userUrl)
        {
            browser.Type(UserUrlLocator, userUrl);
            return new CommentsPage();
        }

        public CommentsPage ClickOnSubmit()
        {
            browser.Click(SubmitLocator);
            return new CommentsPage();
        }
                
        private CommentsPage HighlightComment(string commentText)
        {
            browser.MouseOver(By.XPath(String.Format(CommentTitleLocatorPattern, commentText)));
            return new CommentsPage();
        }

        public CommentsPage ClickTrash(string commentText)
        {
            new CommentsPage().HighlightComment(commentText); 
            browser.Click(By.XPath(String.Format(TrashButtonLocatorPattern, commentText)));
            return new CommentsPage();
        }

        public void ClickEdit(string commentText)
        {
            new CommentsPage().HighlightComment(commentText); 
            browser.Click(By.XPath(String.Format(EditButtonLocatorPattern, commentText)));
            new CommentsPage().InputNewComment();
        }

        private CommentsPage InputNewComment()
        {
            new EditCommentPage().EditComment(); 
            return new CommentsPage();
        }
    }
}
