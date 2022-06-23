using Aquality.Selenium.Browsers;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using SpecTestProject.Models_and_Utils_for;

namespace SpecTestProject.Pages
{
    public class ComparePage : Form
    {
        private static readonly IElementFactory _elementfactory = AqualityServices.Get<IElementFactory>();
        private static readonly IComboBox _makeSelection = _elementfactory.GetComboBox(By.Id("vehicle_selection_make"),"Make selection");
        private static readonly IComboBox _modelSelection = _elementfactory.GetComboBox(By.Id("vehicle_selection_model"),"Model selection");
        private static readonly IComboBox _yearSelection = _elementfactory.GetComboBox(By.Id("vehicle_selection_year"),"Year selection");
        private static readonly IComboBox _trimSelection = _elementfactory.GetComboBox(By.Id("vehicle_selection_trim"),"Trim selection");
        private static readonly IButton _addCarButton = _elementfactory.GetButton(By.XPath("//div[@class='research-search']//button[@class='sds-button']"),"Add car button");
        private static readonly IButton _seeComparisonButton = _elementfactory.GetButton(By.XPath("//div[contains(@class,'comparison-box')]//button[@class='sds-button']"),"See the comparison button");
        private static ITextBox ComboBoxElement(string name) => _elementfactory.GetTextBox(By.XPath($"//option[@value='{name.ToLower()}']"), "Make element");
        private static ITextBox TrimComboBoxElement(string name) => _elementfactory.GetTextBox(By.XPath($"//option[contains(text(),'{name}')]"), "Make element");
        private static IButton CompareCard(int numberOfCard) => _elementfactory.GetButton(By.XPath($"//div[contains(@class,'card{numberOfCard}')]"),"First compare card");

        public ComparePage():base(By.ClassName("comparison-container"),"Compare container") {}

        public void ClickToCompareButton() 
        {
            _seeComparisonButton.Click();
        }
        public void FillCompareCard(TrimModel model, int numberOfCard)
        {
            CompareCard(numberOfCard).Click();
            SelectMake(model.MakeName);
            SelectModel(model.ModelName);
            SelectYear(model.Year);
            SelectTrim(model.TrimName);
            ClickToAddCarButton();
        }
        private void ClickToAddCarButton()
        {
            _addCarButton.State.WaitForClickable();
            _addCarButton.Click();
        }
        private void SelectMake(string makeName)
        {
            _makeSelection.Click();
            ComboBoxElement(makeName).Click();
        }
        private void SelectModel(string modelName)
        {
            _modelSelection.Click();
            ComboBoxElement(modelName).Click();
        }
        private void SelectYear(string year)
        {
            _yearSelection.Click();
            ComboBoxElement(year).Click();
        }
        private void SelectTrim(string trimName)
        {
            _trimSelection.Click();
            TrimComboBoxElement(trimName).Click();
        }
    }
}