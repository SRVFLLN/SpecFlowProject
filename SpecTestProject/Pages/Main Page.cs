using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace SpecTestProject.Pages
{
    public class MainPage : Form
    {
        private static readonly IElementFactory _elementfactory = AqualityServices.Get<IElementFactory>();
        private static readonly ILink _reserchlink = _elementfactory.GetLink(By.XPath("//a[contains(@data-linkname,'research') and contains(@data-linkname,'header')]"), "Research page link");
        private static readonly ILink _advancedSearchLink = _elementfactory.GetLink(By.ClassName("search-advanced"),"Advanced search link");

        public MainPage() : base(By.ClassName("sds-home-search"), "Search field on main page") { }

        public void GoToAdvancedSearchPage() 
        {
            _advancedSearchLink.Click();
        }
        public void GoToResearchPage() 
        {
            _reserchlink.Click();
        }
    }
}
