using OpenQA.Selenium;

namespace AutomationFramework.Pages
{
    public class SerialPage : BasePage
    {
        private const string btnAddToFavorite = "div.show-header__menu a.navigation__item__link--favorite-add";
        private const string btnCast = "a[href$='/cast']";
        private const string lstActors = ".shelf__tiles a";
        private string lnkActor(string name) => $"//span[contains(text(),'{name}')]/../../../../..";

        private const string btnMore = ".bio__long-desc__more";
        private const string btnLess = ".bio__long-desc__more--active";

        private const string btnClosePopUp = ".modal__icon__exit";

        public SerialPage(IWebDriver driver) : base(driver)
        {
        }

        public SerialPage ClosePopUpIfPresent()
        {
            WaitForElementPresent(By.CssSelector(btnClosePopUp)).Click();
            return WaitForPageLoaded();
        }

        public SerialPage WaitForPageLoaded()
        {
            return (SerialPage)WaitForAnyPageLoaded();
        }

        public SerialPage ClickAddToFavorite()
        {
            WaitForElementPresent(By.CssSelector(btnAddToFavorite)).Click();
            return WaitForPageLoaded();
        }

        public bool IsActorPresent(string name) => IsElementDisplayed(By.XPath(lnkActor(name)));

        public SerialPage ClickOnActor(string name)
        {
            WaitForElementPresent(By.XPath(lnkActor(name))).Click();
            return WaitForPageLoaded();
        }
        public SerialPage ClickCast()
        {
            WaitForElementPresent(By.CssSelector(btnCast)).Click();
            return WaitForPageLoaded();
        }

        public int GetActorsCount() => driver.FindElements(By.CssSelector(lstActors)).Count;

        public SerialPage ClickMoreButton()
        {
            WaitForElementPresent(By.CssSelector(btnMore)).Click();
            return WaitForPageLoaded();
        }
         
        public bool IsLessButtonDisplayed() => IsElementDisplayed(By.CssSelector(btnLess));
    }
}
