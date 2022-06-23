using Aquality.Selenium.Browsers;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using SpecTestProject.Models_and_Utils_for;

namespace SpecTestProject.Pages
{
    public class YourCarComparePage : Form
    {
        private static readonly IElementFactory _elementfactory = AqualityServices.Get<IElementFactory>();
        private static ITextBox DoorCount(int indexOfCar) => _elementfactory.GetTextBox(By.XPath($"//td[text()='Door']/parent::tr/following-sibling::tr[1]/td[{indexOfCar}]"),"Door count textbox");
        private static ITextBox SeatsCount(int indexOfCar) => _elementfactory.GetTextBox(By.XPath($"//td[text()='Seats']/parent::tr/following-sibling::tr[1]/td[{indexOfCar}]"),"Seats count textbox");

        public YourCarComparePage() : base(By.XPath("//h1[contains(@class,'compare-details-header')]"),"Compare page header"){}

        public string GetDoorCount(int indexOfCar)
        {
            return DoorCount(indexOfCar).Text;
        }
        public string GetSeatCount(int indexOfCar)
        {
            return SeatsCount(indexOfCar).Text;
        }
    }
}