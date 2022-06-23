using Aquality.Selenium.Browsers;
using Aquality.Selenium.Forms;
using OpenQA.Selenium;
using Aquality.Selenium.Elements.Interfaces;
using SpecTestProject.Models_and_Utils_for;
using System;

namespace SpecTestProject.Pages
{
    public class TrimPage : Form
    {
        private static readonly IElementFactory _elementfactory = AqualityServices.Get<IElementFactory>();
        private static readonly ITextBox _doorsCount = _elementfactory.GetTextBox(By.XPath("//label[contains(text(),'door')]"), "Label of door count");
        private static readonly ITextBox _seatsCount = _elementfactory.GetTextBox(By.XPath("//label[contains(text(),'seat')]"), "Label of seat count");
        private static readonly ILink _researchlink = _elementfactory.GetLink(By.XPath("//a[contains(@data-linkname,'research') and contains(@data-linkname,'header')]"), "Research page link");
        private static readonly ITextBox _priceTextBox = _elementfactory.GetTextBox(By.ClassName("price-amount"),"Price textbox");
        private static readonly ILink _mainPageLink = _elementfactory.GetLink(By.XPath("//a[@data-linkname='header-home']"),"Main page link");
        public TrimPage() : base(By.XPath("//div[contains(@class,'key-specs')]"),"Specs container") { }

        public void GoToMainPage() 
        {
            _mainPageLink.Click();
        }
        public void GoToResearchPage()
        {
            _researchlink.Click();            
        }
        public void SaveTrimInfo(TrimModel model)
        {
            model.Doors = GetDoorCount();
            model.Seats = GetSeatCount();
        }

        public string GetPrice()
        {
            return _priceTextBox.Text;
        }
        private string GetDoorCount() 
        {
            return _doorsCount.Text;
        }
        private string GetSeatCount() 
        {
            return _seatsCount.Text.Split()[0];
        }
    }
}
