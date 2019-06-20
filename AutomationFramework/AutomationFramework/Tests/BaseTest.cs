using Allure.Commons;
using AutomationFramework.Pages;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace AutomationFramework.Tests
{
    public class AllureBase
    {
        [OneTimeSetUp]
        public void SetAllureEnvironmentVariable()
        {
            Environment.SetEnvironmentVariable("ALLURE_CONFIG", Path.Combine(TestContext.CurrentContext.WorkDirectory, "allureConfig.json"));
        }
    }

    [Parallelizable(ParallelScope.Fixtures)]
    [AllureNUnit]
    public class BaseTest : AllureBase
    {
        protected IWebDriver driver;
        protected static AllureLifecycle Allure = AllureLifecycle.Instance;

        [SetUp]
        public void CreateDriver()
        {
            driver = new ChromeDriver();
        }

        [TearDown]
        public void DeleteDriver()
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
