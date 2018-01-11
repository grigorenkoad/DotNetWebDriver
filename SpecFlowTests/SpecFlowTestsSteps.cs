using Framework.BO;
using TechTalk.SpecFlow;
using Framework.Pages;
using Framework.Services;
using NUnit.Framework;

namespace SpecFlowTests
{
    [Binding]
    public class SpecFlowTestsSteps
    {
        [Given(@"I entered wordpress main page")]
        public void GivenIEnteredWordpressMainPage()
        {
            MainPage.Open();
        }

        [Given(@"I registered a user")]
        public void GivenIRegisteredAUser()
        {
            RegistrationService.RegisterNewUser(AccountBuilder.CreateAccount());
        }

        [Given(@"I am logged as moderator")]
        public void GivenIAmLoggedAsModerator()
        {
            LoginService.Login(RegistrationService.RegisterNewUser(AccountBuilder.CreateAccount()));
        }

        [Given(@"There is some post")]
        public void GivenThereIsSomePost()
        {
            PostService.AddPost(PostBuilder.GeneratePost(LoginService.Login(RegistrationService.RegisterNewUser(AccountBuilder.CreateAccount()))));
        }

        [Given(@"There is some post with comment")]
        public void GivenThereIsSomePostWithComment()
        {
            GivenThereIsSomePost();
            CommentService.AddComment(CommentBuilder.GenerateComment());
        }

        [When(@"I try to login with (\w+) account")]
        public void WhenITryToLoginWithWrongAccount(string wichAccount)
        {
            if (wichAccount == "right")
            {
                LoginService.Login(RegistrationService.RegisterNewUser(AccountBuilder.CreateAccount()));
            }
            else
            {
                LoginService.Login(AccountBuilder.CreateAccount());
            }
        }

        [When(@"I register new user")]
        public void WhenIRegisterNewUser()
        {
            GivenIRegisteredAUser();
        }

        [When(@"I add a post")]
        public void WhenIAddAPost()
        {
            GivenThereIsSomePost();
        }

        [When(@"I add a comment to the post")]
        public void WhenIAddACommentToThePost()
        {
            GivenThereIsSomePostWithComment();
        }

        [When(@"I delete the comment")]
        public void WhenIDeleteTheComment()
        {
            GivenThereIsSomePost();
            CommentService.DeleteComment(CommentBuilder.GenerateComment());
        }

        [When(@"I delete the post")]
        public void WhenIDeleteThePost()
        {
            GivenIAmLoggedAsModerator();
            PostService.DeletePost(PostBuilder.GeneratePost(LoginService.Login(RegistrationService.RegisterNewUser(AccountBuilder.CreateAccount()))));
        }

        [Then(@"I see error message")]
        public void ThenISeeErrorMessage()
        {
            Assert.IsTrue(LoginService.IsErrorMessageDisplayed());
        }

        [Then(@"I can assign new password")]
        public void ThenICanAssignNewPassword()
        {
            Assert.IsTrue(RegistrationService.IsNewPasswordDisplayed());
        }

        [Then(@"I see dashboard")]
        public void ThenISeeDashboard()
        {
            Assert.IsTrue(LoginService.IsDashboardDisplayed());
        }

        [Then(@"Comment is (\w*)\s?displayed under the post")]
        public void ThenCommentIsNotDisplayedUnderThePost(string yesOrNot)
        {


            GivenThereIsSomePost();
            bool areDisplayed = yesOrNot != "not";
            if (areDisplayed)
            {
                Assert.IsTrue(CommentService.IsCommentDisplayed(CommentService.AddComment(CommentBuilder.GenerateComment())));
            }
            else
            {
                Assert.IsFalse(CommentService.IsCommentDisplayed(CommentService.AddComment(CommentBuilder.GenerateComment())));
            }
        }

        [Then(@"Post is (\w*)\s?displayed on main page")]
        public void ThenPostIsNotDisplayedOnMainPage(string isDisplayed)
        {
            Post post = PostBuilder.GeneratePost(RegistrationService.RegisterNewUser(AccountBuilder.CreateAccount()));
            PostService.AddPost(post);
            if (isDisplayed != "not")
            {

                Assert.IsTrue(PostService.IsPostDisplayed(post));
            }
            else
            {
                Assert.IsFalse(PostService.IsPostDisplayed(post));
            }
        }
    }
}
