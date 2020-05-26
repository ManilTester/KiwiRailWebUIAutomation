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

        public By PageLocator => By.CssSelector("body header[role=banner] a[class=main-header__logo]");

        private IEnumerable<IWebElement> NavigationLinks =>
            Driver.FindElements(By.CssSelector("header nav[class=primary-nav] ul li[class=primary-nav__item]"));

        private IEnumerable<IWebElement> ActiveNavigationMenuItems =>
        Driver.FindElements(By.CssSelector("ul li[class*=active] div ul li"));

        public bool? IsLinkPresentOnTheHeader(string linkText)
        {
            return NavigationLinks.First(navLink => navLink.Text.Trim() == linkText).Displayed;
        }

        public void HoverOverTheNavigationMenu(string navLink)
        {
            Actions action = new Actions(Driver);

            var navigationItem = NavigationLinks.First(nav => nav.Text.Trim() == navLink);

            action.MoveToElement(navigationItem).Perform();
            GetNavigationMenuItems();
        }

        public List<string> GetNavigationMenuItems()
        {
            List<string> menuItems = null;
            menuItems.AddRange(ActiveNavigationMenuItems.Select(item => item.Text));
            return menuItems.Count == 0 ? null : menuItems;
        }
    }
}