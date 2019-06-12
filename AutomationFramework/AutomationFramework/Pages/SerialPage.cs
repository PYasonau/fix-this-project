using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Pages
{
    public class SerialPage
    {
        private const string btnAddToFavorite = "div.show-header__menu a.navigation__item__link--favorite-add";
        private const string btnCast = "a[href$='/cast']";
        private const string lstActors = ".shelf__tiles a";
        private string lnkActor(string name) => $"//*[@class='tile__description__part-bold' and text()='{name}']";

        private const string btnMore = ".bio__long-desc__more";
        private const string btnLess = ".bio__long-desc__more--active";

        private const string btnClosePopUp = ".modal__icon__exit";

        public SerialPage(IWebDriver driver)
        {
        }

        public SerialPage ClosePopUpIfPresent()
        {
            driver.FindElement(By.CssSelector(btnClosePopUp)).Click();
            return WaitForPageLoaded();
        }

        public SerialPage WaitForPageLoaded()
        {
            return WaitForAnyPageLoaded();
        }

        public SerialPage ClickAddToFavorite()
        {
            WaitForElementPresent(By.CssSelector(btnAddToFavorite)).Click();
            return WaitForPageLoaded();
        }

        public bool IsActorPresent(string name) => driver.FindElements(By.XPath(lnkActor(name))).Count == 0;

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
         
        public bool IsLessButtonDisplayed() => driver.FindElements(By.CssSelector(btnLess)).Count > 0;
    }
}
