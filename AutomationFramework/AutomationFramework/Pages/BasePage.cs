using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver driver;
        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By spinner = By.CssSelector(".basic-loading-page.basic-loading-page--show-page");

        public bool IsElementPresent(By locator) => driver.FindElements(locator).Count > 0;

        public IWebElement WaitForElementPresent(By locator, int timeInSeconds = 15)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds)).Until(d => IsElementPresent(locator));
            return driver.FindElement(locator);
        }

        public BasePage WaitForElementNotPresent(By locator, int timeInSeconds = 15)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds)).Until(d => !IsElementPresent(locator));
            return this;
        }

        public void WaitForAnyPageLoaded()
        {
            WaitForElementNotPresent(spinner);
        }
    }
}
