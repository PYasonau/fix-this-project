using OpenQA.Selenium;

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

        private IWebElement lnkShows => WaitForElementPresent(By.CssSelector(lnkShowsLocator));
        private IWebElement lnkEpisodes => driver.FindElement(By.CssSelector(lnkEpisodesLocator));
        private IWebElement lnkSchedule => driver.FindElement(By.CssSelector(lnkScheduleLocator));
        private IWebElement lnkNewsSports => driver.FindElement(By.CssSelector(lnkNewsSportsLocator));
        private IWebElement lnkShop => driver.FindElement(By.CssSelector(lnkShopLocator));
        private IWebElement lnkApp => driver.FindElement(By.CssSelector(lnkAppLocator));
        private IWebElement btnSearch => driver.FindElement(By.CssSelector(btnSearchLocator));

        public NBCHeader(IWebDriver driver) : base(driver)
        {
        }

        public ShowsPage ClickShows()
        {
            lnkShows.Click();
            return new ShowsPage(driver).WaitForPageLoaded();
        }
        public NBCHeader WaitForPageLoaded()
        {
            return (NBCHeader)WaitForAnyPageLoaded();
        }
    }
}
