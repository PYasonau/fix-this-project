using AutomationFramework.Pages;
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

            Assert.That(() => nbcShows.IsShowBlockByNameExist(nbcSerialName),
                        Is.True.After(20 * 1000, 1000), $"Сериала с именем {nbcSerialName} нет");

            var serialPage = nbcShows
                .ClickOnShowBlockByName(nbcSerialName)
                .ClickAddToFavorite()
                .ClosePopUpIfPresent()
                .ClickCast();

            Assert.Multiple(() =>
            {
                Assert.That(() => serialPage.GetActorsCount(), Is.EqualTo(expectedActorsCount).After(30 * 1000, 1 * 1000), "Actors count is not as expected");
                Assert.That(serialPage.IsActorPresent(JamesSpader), Is.True.After(30 * 1000, 1 * 1000), $"Actor {JamesSpader} is not present");
                Assert.That(serialPage.IsActorPresent(Mozhan), Is.True.After(30 * 1000, 1 * 1000), $"Actor {Mozhan} is not present");
                Assert.That(serialPage.IsActorPresent(Hisham), Is.True.After(30 * 1000, 1 * 1000), $"Actor {Hisham} is not present");
            });
            serialPage.ClickOnActor(Megan).ClickMoreButton();

            Assert.That(serialPage.IsLessButtonDisplayed(), Is.True, "Button Less is not present");
        }
    }
}
