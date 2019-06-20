using AutomationFramework.Pages;
using NUnit.Allure.Core;
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

            Allure.WrapInStep(() => {}, "Step 1: Check navigation by tabs on Shows Page ");
            var  nbcShows = new NBCHeader(Driver)
                .ClickSHows()
                .ClickCurrent()
                .ClickUpcoming()
                .ClickThrowback()
                .ClickAll();

            Allure.WrapInStep(() => {}, $"Step 2: Check Serial '{nbcSerialName}' is displayed on Shows Page");
            Assert.That(nbcShows.IsShowBlockByNameExist(nbcSerialName),
                Is.True, $"Сериала с именем {nbcSerialName} нет");

            Allure.WrapInStep(() => {}, $"Step 3: Click on Serial by name: '{nbcSerialName}'");
            nbcShows.ClickOnShowBlockByName(nbcSerialName);
        }
    }
}
