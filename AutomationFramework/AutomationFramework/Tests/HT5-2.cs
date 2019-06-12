using AutomationFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Tests
{
    public class HT52 : BaseTest
    {
        public ChromeDriver CreateDriver()
        {
            return new IWebDriver();
        }

        private string nbcSerialName = "The Blacklist";

        [Test]
        [Description("New Description")]
        public void HT52Test()
        {
            Driver1 = CreateDriver();
            NavigateToSite(Driver1);

            var headerPage = new NBCHeader(Driver1);
            var  nbcShows = headerPage
                .ClickSHows()
                .ClickCurrent()
                .ClickUpcoming()
                .ClickThrowback()
                .ClickAll();

            Assert.That(nbcShows.IsShowBlockByNameExist(nbcSerialName),
                Is.True, $"Сериала с именем {nbcSerialName} нет");

            nbcShows.ClickOnShowBlockByName(nbcSerialName);
        }
    }
}
