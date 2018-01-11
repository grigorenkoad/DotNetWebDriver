using Framework.WebdriverAddons;
namespace Framework.Pages
{
    public class AbstractPage
    {
        protected Browser browser;
        public AbstractPage()
        {
            this.browser = Browser.Get();
        }
    }
}
