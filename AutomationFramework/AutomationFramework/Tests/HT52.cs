using AutomationFramework.Pages;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace AutomationFramework.Tests
{
    public class HT52 : BaseTest
    {
        private string nbcSerialName = "The Blacklist";

        [Test]
        [Description("HT52Test Description")]
        public void HT52Test()
        {
            Allure.WrapInStep(() =>
            {
                NavigateToNBCSite();
            }, "Step1: Navigate To NBC Site");

            Allure.WrapInStep(() =>
            {
                var nbcShows = new NBCHeader(driver)
                .ClickShows()
                .ClickCurrent()
                .ClickUpcoming()
                .ClickThrowback()
                .ClickAll();
                Assert.That(nbcShows.IsShowBlockByNameExist(nbcSerialName),
                Is.True, $"Сериала с именем {nbcSerialName} нет");
            }, "Step2: Check if the series exists");

            Allure.WrapInStep(() =>
            {
                new ShowsPage(driver).ClickOnShowBlockByName(nbcSerialName);
            }, "Step3: Open series page");
        }
    }
}
