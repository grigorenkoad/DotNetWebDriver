using System;
using Framework.Cli;
using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Logger = NLog.Logger;

namespace Framework.WebdriverAddons
{
    public class Browser
    {
        public IWebDriver driver;

        private static TimeSpan PAGE_LOAD_DEFAULT_TIMEOUT_SECONDS = TimeSpan.FromSeconds(15);
        private static TimeSpan COMMAND_DEFAULT_TIMEOUT_SECONDS = TimeSpan.FromSeconds(1);
        private static TimeSpan WAIT_ELEMENT_TIMEOUT = TimeSpan.FromSeconds(5);
        private static int AJAX_TIMEOUT_SECONDS = 5;
        private static Browser instance = null;
        private int scrCounter = 0;
        private static Logger log = LogManager.GetCurrentClassLogger();

        public Browser(IWebDriver driver)
        {
            this.driver = driver;
        }

        public static Browser Get()
        {
            if (instance != null)
            {
                return instance;
            }
            return instance = Init();
        }
        
        private static Browser Init()
        {
            log.Info("Initializing browser...");
            string browserType = TestRunnerOptions.getBrowserType();
            IWebDriver driver = null;
            switch (browserType)
            {
                case "ff":
                    driver = new FirefoxDriver();
                    break;
                case "gc":
                    driver = new ChromeDriver();
                    break;
                case "ie":
                    driver = new InternetExplorerDriver();
                    break;
            }
            driver.Manage().Timeouts().ImplicitlyWait(COMMAND_DEFAULT_TIMEOUT_SECONDS);
            driver.Manage().Timeouts().SetPageLoadTimeout(PAGE_LOAD_DEFAULT_TIMEOUT_SECONDS);
            driver.Manage().Window.Maximize();
            return new Browser(driver);
        }

        public static void Kill()
        {
            if (instance != null)
            {
                try
                {
                    instance.driver.Close();
                }
                catch (Exception e)
                {
                    log.Error("Cannot kill browser", e);
                }
                finally
                {
                    instance = null;
                }
            }
        }

        public void GoTo(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void Type(By locator, string text)
        {
            WaitForElementPresent(locator);
            WaitForElementEnabled(locator);
            WaitForElementVisible(locator);
            log.Info("Writing '" + text + "' to " + locator);
            highliteElement(locator);
            takeScreenshot();
            driver.FindElement(locator).SendKeys(text);
        }

        public void Click(By locator)
        {
            WaitForElementPresent(locator);
            WaitForElementEnabled(locator);
            WaitForElementVisible(locator);
            log.Info("Clicking " + locator);
            highliteElement(locator);
            takeScreenshot();
            driver.FindElement(locator).Click();
        }

        public String Read(By locator)
        {
            WaitForElementPresent(locator);
            WaitForElementEnabled(locator);
            WaitForElementVisible(locator);
            log.Info("Reading text: " + driver.FindElement(locator).Text);
            highliteElement(locator);
            takeScreenshot();
            return driver.FindElement(locator).Text;
        }

        public void MarkCheckbox(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            log.Info("Marking checkbox " + locator);
            if (!element.Selected) Click(locator);
        }

        public void UnmarkCheckbox(By locator)
        {
            IWebElement element = driver.FindElement(locator);
            log.Info("Umnarking checkbox " + locator);
            if (element.Selected) Click(locator);
        }

        public void WaitForElementPresent(By locator)
        {
            new WebDriverWait(driver, WAIT_ELEMENT_TIMEOUT).Until(ExpectedConditions.ElementExists((locator)));
        }

        public void WaitForElementVisible(By locator)
        {
            new WebDriverWait(driver, WAIT_ELEMENT_TIMEOUT).Until(ExpectedConditions.ElementIsVisible((locator)));
        }

        public void WaitForElementClickable(By locator)
        {
            new WebDriverWait(driver, WAIT_ELEMENT_TIMEOUT).Until(ExpectedConditions.ElementToBeClickable((locator)));
        }

        public void WaitForElementEnabled(By locator)
        {
            new WebDriverWait(driver, WAIT_ELEMENT_TIMEOUT).Until(driver => driver.FindElement(locator).Enabled);
        }

        public void WaitForAjax()
        {
            int time = 0;
            while (time < AJAX_TIMEOUT_SECONDS*1000)
            {
                System.Threading.Thread.Sleep(100);
                time += 100;
                var ajaxIsComplete = (bool)(driver as IJavaScriptExecutor).ExecuteScript("return jQuery.active == 0");
                if (ajaxIsComplete)
                    break;
              }
        }

        public void highliteElement(By locator)
        {
            var jsDriver = (IJavaScriptExecutor)driver;
            var element = driver.FindElement(locator);
            string highlightJavascript = @"arguments[0].style.cssText = ""border-width: 3px; border-style: solid; border-color: red"";";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
        }

        public void takeScreenshot()
        {
            instance.scrCounter++;
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile("D:/Screenshot_" + instance.scrCounter, System.Drawing.Imaging.ImageFormat.Jpeg);
        }

        public void MouseOver(By locator)
        {
            new Actions(driver).MoveToElement(driver.FindElement(locator)).Perform();
        }

        public bool IsElementPresent(By locator)
        {
            return driver.FindElements(locator).Count != 0;
        }

        public bool IsElementDisplayed(By locator)
        {
            return driver.FindElement(locator).Displayed;
        }

    }
}
