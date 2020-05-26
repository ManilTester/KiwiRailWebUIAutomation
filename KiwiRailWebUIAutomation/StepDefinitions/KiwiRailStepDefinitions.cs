using System.Linq;
using KiwiRailWebUIAutomation.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace KiwiRailWebUIAutomation.StepDefinitions
{
    [Binding]
    public sealed class KiwiRailStepDefinitions
    {
        private readonly MainPage _mainPage;
        public KiwiRailStepDefinitions(IWebDriver driver)
        {
            _mainPage = new MainPage(driver);
        }
        [Given(@"I navigate to the Kiwi Rail Website")]
        public void GivenINavigateToTheKiwiRailWebsite()
        {
            _mainPage.Navigate("https://www.kiwirail.co.nz/");
        }

        [When(@"I hover over the Primary Navigation Menu Option :")]
        public void WhenIHoverOverThePrimaryNavigationMenuOption(Table table)
        {
            var menuItem = table.Rows.First();
            _mainPage.HoverOverTheNavigationMenu(menuItem[0]);
        }

        [Then(@"I verify that the menu contains items :")]
        public void ThenIVerifyThatTheMenuContainsItems(Table table)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I verify that I am on Kiwi Rail Website Main Page")]
        public void ThenIVerifyThatIAmOnKiwiRailWebsiteMainPage()
        {
            var pageLocator = _mainPage.PageLocator;
            _mainPage.IsPageLoaded(pageLocator);
        }

        [Then(@"I verify the main header navigation links are:")]
        public void ThenIVerifyTheMainHeaderNavigationLinksAre(Table links)
        {
            foreach (var link in links.Rows)
            {
                Assert.IsTrue(_mainPage.IsLinkPresentOnTheHeader(link[0]));
            }
        }

    }
}
