using AutomationFramework.Pages;
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
        protected IWebDriver driver;

        [SetUp]
        public void CreateAndPushDriver()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void ModifyDrivers()
        {
            driver?.Quit();
        }

        public NBCHeader NavigateToNBCSite()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.nbc.com");
            return new NBCHeader(driver);
        }
    }
}
