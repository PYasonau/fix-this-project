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
        [Category("Functional")]
        public void HT52Test()
        {
            Driver = CreateDriver();

            var  nbcShows = new NBCHeader(Driver)
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
