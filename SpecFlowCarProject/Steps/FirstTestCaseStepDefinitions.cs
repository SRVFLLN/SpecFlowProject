using TechTalk.SpecFlow;
using SpecTestProject.Models_and_Utils_for;
using SpecTestProject.Pages;
using System.Collections.Generic;
using FluentAssertions;
using TechTalk.SpecFlow.Assist;

namespace SpecFlowCarProject.Steps
{
    [Binding]
    public sealed class FirstTestCaseStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private bool _result;
        private bool _secondResult;
        private readonly List<TrimModel> models = Deserialization.GetModelListFromFile<TrimModel>(System.IO.Directory.GetCurrentDirectory() + "/Test Data/firstmodel.json");
        private CarPage carPage;
        private ComparePage comparePage;
        private MainPage mainPage;
        private ResearchPage researchPage;
        private TrimPage trimPage;
        private YourCarComparePage yourComparePage;
        private TrimModel model;
        private AdvancedSearchPage searchPage;
        private AdvancedResultsPage resultsPage;

        public FirstTestCaseStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }
        [When(@"start page is open")]
        public void WhenStartPageIsOpen()
        {
            mainPage = new MainPage();   
        }
        [Then(@"page should be opened")]
        public void ThenPageShouldBeOpened()
        {
            mainPage.State.IsDisplayed.Should().BeTrue();
        }
        [When(@"click on research page link")]
        public void WhenClickOnResearchPageLink()
        {
            mainPage.GoToResearchPage();
            researchPage = new ResearchPage();
        }
        [Then(@"research page is opened")]
        public void ThenResearchPageIsOpened()
        {
             researchPage.State.IsDisplayed.Should().BeTrue(); ;
        }
        [Given(@"fill form with first trim model")]
        public void GivenFillFormWithFirstTrimModel()
        {
            researchPage.FillResearchForm(models[0]);
        }
        [When(@"click on search button")]
        public void WhenClickOnSearchButton()
        {
            researchPage.ClickToResearchButton();
            carPage = new CarPage();
        }
        [Then(@"car page is opened")]
        public void ThenCarPageIsOpened()
        {
            carPage.State.IsDisplayed.Should().BeTrue();
        }
        [When(@"click on first trim comparison link")]
        public void WhenClickOnFirstTrimComparisonLink()
        {
            carPage.GetTrimName(models[0]);
            carPage.GoToTrimPage();
            trimPage = new TrimPage();
        }
        [When(@"click on second trim comparison link")]
        public void WhenClickOnSecondTrimComparisonLink()
        {
            carPage.GetTrimName(models[1]);
            carPage.GoToTrimPage();
            trimPage = new TrimPage();
        }
        [When(@"go to trim page")]
        public void WhenGoToTrimPage(Table table)
        {
            model = table.CreateInstance<TrimModel>();
            mainPage = new MainPage();
            mainPage.GoToResearchPage();
            researchPage = new ResearchPage();
            researchPage.FillResearchForm(model);
            researchPage.ClickToResearchButton();
            carPage = new CarPage();
            carPage.GoToTrimPage();
            trimPage = new TrimPage();
        }
        [Given(@"save trim price")]
        public void GivenSaveTrimPrice()
        {
            model.Price = trimPage.GetPrice();
        }
        [When(@"open Advanced search page")]
        public void WhenOpenAdvancedSearchPage()
        {
            mainPage.GoToAdvancedSearchPage();
            searchPage = new AdvancedSearchPage();
        }
        [Then(@"advanced search page opened")]
        public void ThenAdvancedSearchPageOpened()
        {
            searchPage.State.IsDisplayed.Should().BeTrue();

        }
        [When(@"fill advanced search form")]
        public void WhenFillAdvancedSearchForm()
        {
            searchPage.ClearAllTags();
            searchPage.SelectMake(model.MakeName);
            searchPage.SelectRadius(20);
            searchPage.SelectStock("used");
            searchPage.SelectZip("10001");
            searchPage.SelectModel(model.ModelName);
            searchPage.ClickOnSearchButton();
            resultsPage = new AdvancedResultsPage();
        }
        [Then(@"results page have results")]
        public void ThenResultsPageHaveResults()
        {
            resultsPage.State.IsDisplayed.Should().BeTrue();
        }
        [When(@"add new info")]
        public void WhenAddNewInfo()
        {
            resultsPage.SelectTrim(model.TrimName);
            resultsPage.SelectYear(model.Year);
        }
        [When(@"compare prices")]
        public void WhenComparePrices()
        {
            _result = TextUtils.GetIntPrice(resultsPage.GetPrice()) < TextUtils.GetIntPrice(model.Price);
        }
        [Then(@"new car price is bigger")]
        public void ThenNewCarPriceIsBigger()
        {
            _result.Should().BeTrue();
        }

        [Then(@"Trim page is opened")]
        public void ThenTrimPageIsOpened()
        {
            trimPage.State.IsDisplayed.Should().BeTrue();
        }
        [Given(@"save trim features")]
        public void GivenSaveTrimFeatures()
        {
            trimPage.SaveTrimInfo(models[0]);
        }
        [When(@"go to main page")]
        public void WhenGoToMainPage()
        {
            trimPage.GoToMainPage();
        }
        [Given(@"fill form with second trim model")]
        public void GivenFillFormWithSecondTrimModel()
        {
            researchPage.FillResearchForm(models[^1]);
        }
        [Given(@"save second trim features")]
        public void GivenSaveSecondTrimFeatures()
        {
            trimPage.SaveTrimInfo(models[^1]);
        }
        [When(@"go to Compare page")]
        public void WhenGoToComparePage()
        {
            researchPage.GoToComparePage();
            comparePage = new ComparePage();
        }
        [Then(@"compare page is opened")]
        public void ThenComparePageIsOpened()
        {
            comparePage.State.IsDisplayed.Should().BeTrue();
        }
        [Given(@"fill fist card")]
        public void GivenFillFistCard()
        {
            comparePage.FillCompareCard(models[0], 1);
        }
        [Given(@"fill second card")]
        public void GivenFillSecondCard()
        {
            comparePage.FillCompareCard(models[^1], 2);
        }
        [When(@"click on Compare button")]
        public void WhenClickOnCompareButton()
        {
            comparePage.ClickToCompareButton();
            yourComparePage = new YourCarComparePage();
        }
        [Then(@"car comparison page is opened")]
        public void ThenCarComparisonPageIsOpened()
        {
            yourComparePage.State.WaitForDisplayed();
            yourComparePage.State.IsDisplayed.Should().BeTrue();
        }
        [When(@"check features for first model")]
        public void WhenCheckFeaturesForFirstModel()
        {
            _result = yourComparePage.GetDoorCount(1) == models[0].Doors && yourComparePage.GetSeatCount(1) == models[0].Seats;
        }
        [When(@"check features for second moodel")]
        public void WhenCheckFeaturesForSecondMoodel()
        {
            _secondResult = yourComparePage.GetDoorCount(2) == models[^1].Doors && yourComparePage.GetSeatCount(2) == models[^1].Seats;
        }
        [Then(@"features are correct")]
        public void ThenFeaturesAreCorrect()
        {
            (_result == _secondResult).Should().BeTrue();
        }







    }
}
