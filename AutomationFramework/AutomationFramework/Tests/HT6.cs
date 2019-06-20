using AutomationFramework.Pages;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class HT6 : BaseTest
    {
        private string nbcSerialName = "The Blacklist";

        [Test]
        [Category("Functional")]
        public void HT6Test()
        {
            var expectedActorsCount = 7;
            var JamesSpader = "James Spader";
            var Mozhan = "Mozhan Marnò";
            var Hisham = "Hisham Tawfiq ";
            var Megan = "Megan Boone";

            Allure.WrapInStep(() =>
            {
                NavigateToNBCSite();
            }, "Step1: Navigate To NBC Site");

            Allure.WrapInStep(() =>
            {
                var nbcShows = new NBCHeader(driver).ClickShows();
                Assert.That(nbcShows.IsShowBlockByNameExist(nbcSerialName),
                        Is.True, $"Сериала с именем {nbcSerialName} нет");
            }, "Step2: Check if the series exists");

            Allure.WrapInStep(() =>
            {
                var serialPage = new ShowsPage(driver)
                .ClickOnShowBlockByName(nbcSerialName)
                .ClickAddToFavorite()
                .ClosePopUpIfPresent()
                .ClickCast();
                Assert.Multiple(() =>
                {
                    Assert.That(() => serialPage.GetActorsCount(), Is.EqualTo(expectedActorsCount).After(30 * 1000, 1 * 1000), "Actors count is not as expected");
                    Assert.That(serialPage.IsActorPresent(JamesSpader), Is.True, $"Actor {JamesSpader} is not present");
                    Assert.That(serialPage.IsActorPresent(Mozhan), Is.True, $"Actor {Mozhan} is not present");
                    Assert.That(serialPage.IsActorPresent(Hisham), Is.True, $"Actor {Hisham} is not present");
                });
            }, "Step3: Check number of actors and name of actors in Cast tab");

            Allure.WrapInStep(() =>
            {
                new SerialPage(driver).ClickOnActor(Megan).ClickMoreButton();
            }, "Step4: Click on More button");

            Allure.WrapInStep(() =>
            {
                Assert.That(new SerialPage(driver).IsLessButtonDisplayed(), Is.True, "Button Less is not present");
            }, "Step5: Check if the Less button exists");
        }
    }
}
