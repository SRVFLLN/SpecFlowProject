using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace SpecTestProject.Pages
{
    public class AdvancedSearchPage : Form
    {
        private static readonly IElementFactory _elementfactory = AqualityServices.Get<IElementFactory>();
        private static readonly IComboBox _distanceComboBox = _elementfactory.GetComboBox(By.Id("desktop-location-select"), "Distace Combo Box");
        private static readonly ILabel _zipLabel = _elementfactory.GetLabel(By.Id("desktop-location-zip"), "Zip label");
        private static readonly IComboBox _stockTypeComboBox = _elementfactory.GetComboBox(By.Id("desktop-stock-type-select"), "Stock type combo box");
        private static readonly IComboBox _makeComboBox = _elementfactory.GetComboBox(By.Id("desktop-make_select"), "Make combo box");
        private static readonly IButton _advancedSearchButton = _elementfactory.GetButton(By.XPath("//div[contains(@class,'advanced-search-submit')]//button"),"Advanced search button");
        private static readonly IButton _clearAllTagsButton = _elementfactory.GetButton(By.XPath("//form[contains(@class,'desktop')]//div[@class='clear-all-filter-tags']//span"), "Clear All Tags Button");
        private static ILabel ModelLabel(string modelName) => _elementfactory.GetLabel(By.XPath($"//label[contains(@for,'{modelName}')]"),"Model input");
        private static ILabel ComboBoxElement(string name) => _elementfactory.GetLabel(By.XPath($"//option[@value='{name}']"),"Combo box element");
        private static ILabel MakeComboBoxElement(string name) => _elementfactory.GetLabel(By.XPath($"//optgroup[@label='Popular makes']//option[@value='{name}']"), "Combo box element");

        public AdvancedSearchPage() : base(By.Id("advanced-search-content"), "Page content") { }

        public void ClearAllTags() 
        {
            if (_clearAllTagsButton.State.IsEnabled) 
            {
                _clearAllTagsButton.Click();
            }
        }

        public void SelectRadius(int radius) 
        {
            _distanceComboBox.Click();
            ComboBoxElement($"{radius}").Click();
        }
        public void SelectZip(string zip) 
        {
            _zipLabel.Click();
            _zipLabel.JsActions.SetValue(zip);
        }
        public void SelectStock(string stock) 
        {
            _stockTypeComboBox.Click();
            ComboBoxElement(stock).Click();
        }
        public void SelectMake(string make) 
        {
            _makeComboBox.Click();
            MakeComboBoxElement(make).Click();
        }
        public void SelectModel(string model) 
        {
            ModelLabel(model).JsActions.SetFocus();
            ModelLabel(model).Click();
        }
        public void ClickOnSearchButton() 
        {
            _advancedSearchButton.Click();
        }
    }
}
