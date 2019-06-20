using Allure.Commons;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomationFramework.Tests
{
    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    public class BaseTest : BaseAllure
    {
        protected IWebDriver Driver;
        private string nbcUrl = "https://www.nbc.com";
        protected static AllureLifecycle Allure = AllureLifecycle.Instance;

        public IWebDriver CreateDriver ()
        {
            Driver = new RemoteWebDriver(new ChromeOptions());
            NavigateToSite(Driver);
            return Driver;
        }
       
        [TearDown]
        public void CloseDrivers()
        {
            Driver?.Quit();
        }

        public void NavigateToSite(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(nbcUrl);
        }
    }
}
