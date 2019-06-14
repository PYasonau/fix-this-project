using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Pages
{
    public class ShowsPage : BasePage
    {

        public ShowsPage(IWebDriver driver) : base(driver)
        {
        }

        private string lnkAll = "a[href='/shows/all']";
        private string lnkCurrent = "a[href='/shows/current']";
        private string lnkUpcoming = "a[href='/shows/upcoming']";
        private string lnkThrowBack = "a[href='/shows/classic-throwback']";
        private string lnkShowBlockByText(string text) => $"//div[contains(text(),'{text}')]/../../..";

        public ShowsPage ClickAll()
        {
            WaitForElementPresent(By.CssSelector(lnkAll)).Click();
            return WaitForPageLoaded();
        }
        public ShowsPage ClickCurrent()
        {
            WaitForElementPresent(By.CssSelector(lnkCurrent)).Click();
            return WaitForPageLoaded();
        }
        public ShowsPage ClickUpcoming()
        {
            WaitForElementPresent(By.CssSelector(lnkUpcoming)).Click();
            return WaitForPageLoaded();
        }
        public ShowsPage ClickThrowback()
        {
            WaitForElementPresent(By.CssSelector(lnkThrowBack)).Click();
            return WaitForPageLoaded();
        }

        public SerialPage ClickOnShowBlockByName(string name)
        {
            WaitForElementPresent(By.XPath(lnkShowBlockByText(name))).Click();
            return new SerialPage(driver).WaitForPageLoaded();
        }

        public bool IsShowBlockByNameExist(string name) => IsElementDisplayed(By.XPath(lnkShowBlockByText(name)));

        public ShowsPage WaitForPageLoaded()
        {
            WaitForAnyPageLoaded();
            return this;
        }
    }
}
