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

        public IWebElement WaitForElementPresent(By locator, int timeInSeconds = 10) => 
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds)).Until(ExpectedConditions.ElementIsVisible(locator));

        public void WaitForElementNotPresent(By locator, int timeInSeconds = 10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds)).Until((IWebDriver d) => !IsElementPresent(locator));
        }

        public bool IsElementDisplayed(By locator, int timeInSeconds = 10) =>
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeInSeconds)).Until((IWebDriver d) => driver.FindElements(locator).Count > 0);
        public void WaitForAnyPageLoaded()
        {
            WaitForElementNotPresent(spinner);
        }
    }
}
