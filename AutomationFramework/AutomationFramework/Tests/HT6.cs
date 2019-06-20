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
    public class HT6 : BaseTest
    {
        private string nbcSerialName = "The Blacklist";

        [Test]
        [Category("Functional")]
        public void HT6Test()
        {
            Driver = CreateDriver();
            var expectedActorsCount = 7;
            var JamesSpader = "James Spader";
            var Mozhan = "Mozhan Marnò";
            var Hisham = "Hisham Tawfiq ";
            var Megan = "Megan Boone";

            var headerPage = new NBCHeader(Driver);
            var nbcShows = headerPage
                .ClickSHows();

            Allure.WrapInStep(() => { }, $"Step 1: Check Serial '{nbcSerialName}' is displayed on Shows Page");
            Assert.That(() => nbcShows.IsShowBlockByNameExist(nbcSerialName),
                        Is.True.After(20 * 1000, 1000), $"Сериала с именем {nbcSerialName} нет");

            Allure.WrapInStep(() => { }, $"Step 2: Navigate to Cast page of Serial '{nbcSerialName}'");
            var serialPage = nbcShows
                .ClickOnShowBlockByName(nbcSerialName)
                .ClickAddToFavorite()
                .ClosePopUpIfPresent()
                .ClickCast();

            Allure.WrapInStep(() => { }, $"Step 3: Check actors on the Cast page of Serial '{nbcSerialName}'");
            Assert.Multiple(() =>
            {
                Assert.That(() => serialPage.GetActorsCount(), Is.EqualTo(expectedActorsCount).After(30 * 1000, 1 * 1000), "Actors count is not as expected");
                Assert.That(serialPage.IsActorPresent(JamesSpader), Is.True.After(30 * 1000, 1 * 1000), $"Actor {JamesSpader} is not present");
                Assert.That(serialPage.IsActorPresent(Mozhan), Is.True.After(30 * 1000, 1 * 1000), $"Actor {Mozhan} is not present");
                Assert.That(serialPage.IsActorPresent(Hisham), Is.True.After(30 * 1000, 1 * 1000), $"Actor {Hisham} is not present");
            });

            Allure.WrapInStep(() => { }, $"Step 4: Navigate to page of actor '{Megan}' and click on 'More' button");
            serialPage.ClickOnActor(Megan).ClickMoreButton();

            Allure.WrapInStep(() => { }, $"Step 5: Check 'Less' button is present");
            Assert.That(serialPage.IsLessButtonDisplayed(), Is.True, "Button Less is not present");
        }
    }
}
