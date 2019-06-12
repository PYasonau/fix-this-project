using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Tests
{
    [Parallelizable(ParallelScope.Fixtures)]
    public class BaseTest
    {
        protected IWebDriver Driver1;
        protected IWebDriver Driver2;

        [SetUp]
        public void CreateAndPushDrivers()
        {
            Driver1?.Quit();
            Driver2?.Quit();
        }

        [OneTimeTearDown]
        public void ModifyDrivers()
        {
        }

        public void NavigateToSite(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.nbc.com");
        }
    }
}
