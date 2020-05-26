using KiwiRailWebUIAutomation.PageObjects;
using KiwiRailWebUIAutomation.Support;
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
            // Gets the website URL from appsettings.json
            _mainPage.Navigate(TestConfiguration.GetSectionAndValue("Settings","url"));
        }

        [When(@"I hover over the Primary Navigation menu : (.*)")]
        public void WhenIHoverOverThePrimaryNavigationMenu(string navMenu)
        {
            _mainPage.HoverOverTheNavigationMenu(navMenu);
        }

        [When(@"I click the menu item : (.*)")]
        public void WhenIClickTheMenuItem(string item)
        {
            _mainPage.ClickNavigationMenuItem(item);
        }

        [Then(@"I verify that I am on the page : (.*)")]
        public void ThenIVerifyThatIAmOnThePage(string pageHeader)
        {
            Assert.AreEqual(pageHeader,_mainPage.GetPageHeader());
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
