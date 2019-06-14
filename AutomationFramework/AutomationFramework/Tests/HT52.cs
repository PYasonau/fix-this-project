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
        private string nbcSerialName = "The Blacklist";

        [Test]
        [Description("HT52Test Description")]
        public void HT52Test()
        {
            var  nbcShows = NavigateToNBCSite()
                .ClickShows()
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
