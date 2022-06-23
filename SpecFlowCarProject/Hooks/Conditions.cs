using TechTalk.SpecFlow;
using Aquality.Selenium.Browsers;

namespace SpecFlowCarProject.Hooks
{
    [Binding]
    public static class Conditions
    {
        private static Browser _browser;
        [BeforeScenario]
        public static void OpenBrowser() 
        {
            _browser = AqualityServices.Browser;
            _browser.Maximize();
            _browser.GoTo("http://www.cars.com/");
        }
        [AfterScenario]
        public static void CloseBrowser() 
        {
            _browser.Quit();
        }
    }
}
