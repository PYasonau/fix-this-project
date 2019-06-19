using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Pages
{
    public class NBCHeader : BasePage
    {
        private static string lnkShowsLocator = "a[href='/shows']";
        private static string lnkEpisodesLocator = "a[href='/video']";
        private static string lnkScheduleLocator = "a[href='/schedule']";
        private static string lnkNewsSportsLocator = "//*[contains(text(), 'Sports')]/.."; //XPath locator
        private static string lnkShopLocator = "a[href$='shop']"; //ends with shop

        private static string lnkAppLocator = "a[href='/apps']";
        private static string btnSearchLocator = "[class$='search'] button";

        private IWebElement lnkShows => driver.FindElement(By.CssSelector(lnkShowsLocator));
        private IWebElement lnkEpisodes => driver.FindElement(By.CssSelector(lnkEpisodesLocator));
        private IWebElement lnkSchedule => driver.FindElement(By.CssSelector(lnkScheduleLocator));
        private IWebElement lnkNewsSports => driver.FindElement(By.CssSelector(lnkNewsSportsLocator));
        private IWebElement lnkShop => driver.FindElement(By.CssSelector(lnkShopLocator));
        private IWebElement lnkApp => driver.FindElement(By.CssSelector(lnkAppLocator));
        private IWebElement btnSearch => driver.FindElement(By.CssSelector(btnSearchLocator));

        public NBCHeader(IWebDriver driver) : base(driver)
        {
        }

        public ShowsPage ClickSHows()
        {
            WaitForElementPresent(By.CssSelector(lnkShowsLocator)).Click();
            WaitForAnyPageLoaded();
            return new ShowsPage(driver);
        }
    }
}
