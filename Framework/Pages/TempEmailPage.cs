
using System;
using Framework.WebdriverAddons;
using OpenQA.Selenium;

namespace Framework.Pages
{
    class TempEmailPage : AbstractPage
    {
        private static string Url = "https://mytemp.email/2/#!/";
        private static By EmailNameLocator = By.Id("inbox-name");
        private static string SelectEmailLocatorPattern = "//span[text()='{0}']";
        private static By WordpressLetterLinkLocator = By.XPath("//span[contains(text(),'WordPress')]");
        private static By RegisterLinkLocator = By.XPath("//a[contains(@href,'action=rp')]");


        public TempEmailPage Open()
        {
            Browser.Get().GoTo(Url);
            return new TempEmailPage();
        }

        public string GetEmailName()
        {
            return browser.Read(EmailNameLocator);
        }

        public TempEmailPage SelectEmail()
        {
            browser.Click(By.XPath(String.Format(SelectEmailLocatorPattern, GetEmailName())));
            return new TempEmailPage();
        }

        public TempEmailPage OpenWordpressLetter()
        {
            browser.Click(WordpressLetterLinkLocator);
            return new TempEmailPage();
        }

        public void FollowRegistrationLink()
        {
           browser.GoTo(browser.Read(RegisterLinkLocator));
        }
    }
}
