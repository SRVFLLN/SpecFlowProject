using Aquality.Selenium.Browsers;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using SpecTestProject.Models_and_Utils_for;

namespace SpecTestProject.Pages
{
    public class CarPage : Form
    {
        private static readonly IElementFactory _elementfactory = AqualityServices.Get<IElementFactory>();
        private static readonly ILink _trimLink = _elementfactory.GetLink(By.XPath("//ul[contains(@class,'trim')]/li/a[1]"), "Trim link");

        public CarPage() : base(By.Id("vehicle-reviews"), "Reviews section") { }

        public void GoToTrimPage() 
        {
            _trimLink.Click();
        }
        public void GetTrimName(TrimModel model) 
        {
            model.TrimName = _trimLink.Text;
        }
    }
}
