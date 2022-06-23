using Aquality.Selenium.Browsers;
using Aquality.Selenium.Elements.Interfaces;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;

namespace SpecTestProject.Pages
{
    public class AdvancedResultsPage : Form
    {
        private static readonly IElementFactory _elementfactory = AqualityServices.Get<IElementFactory>();
        private static ILabel TrimLabel(string trim) => _elementfactory.GetLabel(By.XPath($"//div[@id='trim']//label[contains(@for,'{trim}')]"),"Trim label");
        private static IComboBox minYearComboBox = _elementfactory.GetComboBox(By.XPath("//select[@id='year_year_min_select']"), "Min year combobox");
        private static IComboBox maxYearComboBox = _elementfactory.GetComboBox(By.XPath("//select[@id='year_year_max_select']"), "Max year combobox");
        private static ITextBox priceBox = _elementfactory.GetTextBox(By.XPath("//div[@data-tracking-id='1']//span[@class='primary-price'][1]"),"Car price");
        private static ILabel MinComboBoxElement(string name) => _elementfactory.GetLabel(By.XPath($"//select[@id='year_year_min_select']//option[@value='{name}']"), "Combo box element");
        private static ILabel MaxComboBoxElement(string name) => _elementfactory.GetLabel(By.XPath($"//select[@id='year_year_max_select']//option[@value='{name}']"), "Combo box element");
        public AdvancedResultsPage() : base(By.ClassName("vehicle-cards"),"Results cards") { }

        public void SelectTrim(string trimName) 
        {
            TrimLabel(trimName).Click();
        }
        public void SelectYear(string year) 
        {
            minYearComboBox.Click();
            MinComboBoxElement(year).Click();
            maxYearComboBox.Click();
            MaxComboBoxElement(year).Click();
        }
        public string GetPrice() => priceBox.Text; 
    }
}
