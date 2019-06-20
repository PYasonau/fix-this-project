using NUnit.Allure.Core;
using NUnit.Framework;
using System;

namespace AutomationFramework.Tests
{
    public class FeaturesTests
    {
        public class PassTest : BaseTest
        {
            [Description("PassedTest Description")]
            [Test]
            public void PassedTest()
            {
                Allure.WrapInStep(() =>
                {
                    Console.WriteLine("This test will pass in step1!");
                    Assert.Pass("this test will pass");
                }, "Step1");
            }
        }

        public class IgnoreTest : BaseTest
        {
            [Test]
            public void Ignored()
            {
                Allure.WrapInStep(() =>
                {
                    Console.WriteLine("This test will be ignored step1!");
                    Assert.Ignore("Will be ignored. Reason");
                }, "Step1");
            }
        }


        public class AssertTest : BaseTest
        {

            private int Return5() => 5;

            [Test]
            public void Assertion()
            {
                Allure.WrapInStep(() =>
                {
                    Assert.Multiple(() =>
                    {
                        Assert.True(Return5() != 6, "Unexpected");
                        Assert.That(Return5() == 5, Is.True, "Unexpected");
                        Assert.That(Return5(), Is.Not.EqualTo(8), "Unexpected");
                    });
                }, "Step1");
            }
        }

        public class AssertDuringTimeTest : BaseTest
        {

            private int ReturnRandomNumber()
            {
                var number = new Random().Next(10);
                TestContext.Progress.WriteLine($"Generated number: {number}");
                return number;
            }

            [Test]
            public void AssertDuringTime()
            {
                Allure.WrapInStep(() =>
                {
                    Assert.That(() => ReturnRandomNumber(), Is.EqualTo(8).After(30).Seconds.PollEvery(1).Seconds);
                }, "Step1");
            }
        }

        public class Params : BaseTest
        {
            static int[] Numbers = new int[] { 2, 4, 6, 8 };

            [TestCaseSource("Numbers")]
            [TestCase(10)]
            public void ParamsTest(int number)
            {
                Allure.WrapInStep(() =>
                {
                    Assert.False(number == 7, "Unexpected number");
                }, "Step1");
            }
        }
    }
}
