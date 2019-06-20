using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using AutomationFramework.Utils;
using NUnit.Allure.Core;

namespace AutomationFramework.Tests
{
    public class FeaturesTests : BaseTest
    {
        [Test]
        [Description("The most stable test")]
        public void PassedTest()
        {
            Allure.WrapInStep(() => { Console.WriteLine("Passed"); }, "Step 1");
            Assert.Pass("this test will pass");
        }

        [Test]
        public void IgnoredTest()
        {
            Allure.WrapInStep(() => { Console.WriteLine("Ignored"); }, "Step 1");
            Assert.Ignore("Will be ignored. Reason");
        }

        [Test]
        [Category("AssertTests")]
        public void Assertion()
        {
            Allure.WrapInStep(() => { Console.WriteLine("Assertion"); }, "Step 1");
            Assert.Multiple(() =>
            {
                Assert.That(() => Heplers.ReturnRandomIntTenAsMax() == 6, Is.True.After(30).Seconds.PollEvery(1).Seconds, "Unexpected");
                Assert.That(() => Heplers.ReturnRandomIntTenAsMax() == 7, Is.True.After(30).Seconds.PollEvery(1).Seconds, "Unexpected");
                Assert.That(Heplers.ReturnRandomIntTenAsMax(), Is.Not.EqualTo(11), "Unexpected");
            });
        }

        [Test]
        [Category("AssertDuringTimeTests")]
        public void AssertDuringTime()
        {
            Allure.WrapInStep(() => { Console.WriteLine("AssertDuringTime"); }, "Step 1");
            Assert.That(() => Heplers.ReturnRandomIntTenAsMax(), Is.EqualTo(8).After(30).Seconds.PollEvery(1).Seconds);
        }

        [Test]
        [TestCase(7)]
        [TestCase(5)]
        [Category("ParamTests")]        
        public void ParamsTest(int number)
        {
            Allure.WrapInStep(() => { Console.WriteLine("ParamTests"); }, "Step 1");
            Assert.That(number > 6, Is.True, "Unexpected number");
        }
    }
}
