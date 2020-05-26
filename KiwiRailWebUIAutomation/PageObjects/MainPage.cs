using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace KiwiRailWebUIAutomation.PageObjects
{
    internal class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        #region Locators

        public By PageLocator => By.CssSelector("body header[role=banner] a[class=main-header__logo]");

        private IEnumerable<IWebElement> NavigationLinks =>
            Driver.FindElements(By.CssSelector("header nav[class=primary-nav] ul li[class=primary-nav__item]"));

        private IEnumerable<IWebElement> ActiveNavigationMenuItems =>
            Driver.FindElements(By.CssSelector("ul li[class*=active] div[class=primary-nav__menu-container] ul[class=primary-nav__menu] li"));

        private IWebElement PageHeader =>
            Driver.FindElement(By.CssSelector("main[id=maincontent] h1[class*=page-title]"));

        #endregion

        /// <summary>
        /// Verifies if Navigation Option is present on Main Page Header
        /// </summary>
        /// <param name="linkText"></param>
        /// <returns></returns>
        public bool? IsLinkPresentOnTheHeader(string linkText)
        {
            return NavigationLinks.First(navLink => navLink.Text.Trim() == linkText).Displayed;
        }

        public void HoverOverTheNavigationMenu(string navLink)
        {
            Actions action = new Actions(Driver);

            var navigationItem = NavigationLinks.First(nav => nav.Text.Trim() == navLink);

            action.MoveToElement(navigationItem).Perform();
        }

        public void ClickNavigationMenuItem(string item)
        {
            ActiveNavigationMenuItems.First(m => m.Text.Trim() == item).Click();
        }

        /// <summary>
        /// This is common method to extract the Header Text of different pages
        /// to verify on clicking a navigation link user lands on it's page.
        /// Example: After clicking Freight user lands on Freight Page
        /// </summary>
        /// <returns></returns>
        public string GetPageHeader()
        {
            return PageHeader.Text;
        }
    }
}