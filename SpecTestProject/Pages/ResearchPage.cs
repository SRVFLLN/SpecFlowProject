using Aquality.Selenium.Browsers;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using SpecTestProject.Models_and_Utils_for;

namespace SpecTestProject.Pages
{
    public class ResearchPage : Form
    {
        private static readonly IElementFactory _elementfactory = AqualityServices.Get<IElementFactory>();
        private static readonly IComboBox _makeComboBox = _elementfactory.GetComboBox(By.Id("make-select"), "Make combobox");
        private static readonly IComboBox _modelComboBox = _elementfactory.GetComboBox(By.Id("model-select"), "Model combobox");
        private static readonly IComboBox _yearComboBox = _elementfactory.GetComboBox(By.Id("year-select"), "Year combobox");
        private static readonly IButton _researchButton = _elementfactory.GetButton(By.XPath("//button[text()='Research']"), "Research button");
        private static readonly ILink _compareLink = _elementfactory.GetLink(By.XPath("//div[@class='tools-section']//a[@data-linkname='research-compare']"),"Compare models link");
        private static ITextBox ComboBoxElement(string name) => _elementfactory.GetTextBox(By.XPath($"//option[@value='{name.ToLower()}']"), "Make element");

        public ResearchPage() : base(By.XPath("//h1[contains(text(),'Research')]"), "Research page title") { }
        public void GoToComparePage()
        {
            _compareLink.Click();
        }
        private void SelectMake(string makeName) 
        {
            _makeComboBox.Click();
            ComboBoxElement(makeName).Click();
        }
        private void SelectModel(string modelName) 
        {
            _modelComboBox.Click();
            ComboBoxElement(modelName).Click();
        }
        private void SelectYear(string year) 
        {
            _yearComboBox.Click();
            ComboBoxElement(year).Click();
        }
        public void FillResearchForm(TrimModel model)
        {
            SelectMake(model.MakeName);
            SelectModel(model.ModelName);
            SelectYear(model.Year);            
        }
        public void ClickToResearchButton() 
        {
            _researchButton.Click();
        }
    }
}
