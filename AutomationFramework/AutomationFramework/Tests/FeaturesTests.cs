using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Tests
{
    public class FeaturesTests: BaseTest
    {
        [Test]
        [Description("The most stable test")]
        public void FailedTest()
        {
            Assert.Pass("this test will pass");
        }

        [Test]
        public void IgnoreTest()
        {
            Assert.Ignore("Will be ignored. Reason");
        }

        public class AssertTest : BaseTest
        {
            private int Return5()
            {
                var number = new Random().Next(7);
                TestContext.Progress.WriteLine($"Generated number: {number}");
                return number;
            }

            [Test]
            public void Assertion()
            {
                Assert.Multiple(() => 
                {
                    Assert.True(Return5() == 6, "Expected");
                    Assert.That(() => Return5() == 7, Is.True, "Unexpected");
                    Assert.That(Return5(), Is.Not.EqualTo(8), "Unexpected");
                });
            }
        }

        public class AssertDuringTimeTest : BaseTest
        {

            private int Return5()
            {
                var number = new Random().Next(10);
                TestContext.Progress.WriteLine($"Generated number: {number}");
                return number;
            }

            [Test]
            public void AssertDuringTime()
            {
                Assert.That(() => Return5(), Is.EqualTo(8).After(30).Seconds.PollEvery(1).Seconds);
            }
        }

        public class Params : BaseTest
        {
            [TestCase(7)]
            [TestCase(5)]
            [Test]
            public void ParamsTest(int number)
            {
                Assert.That(number > 6, Is.True,  "Unexpected number");
            }
        }
    }
}
