using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Tests
{
    private class FeaturesTests
    {
        public class PassTest : BaseTest
        {
            [Description]
            public void FailedTest()
            {
                Assert.Pass("this test will pass");
            }
        }

        public class IgnoreTest : BaseTest
        {
            [TestCase]
            public void Passed()
            {
                Assert.Ignore("Will be ignored. Reason");
            }
        }

        public class AssertTest : BaseTest
        {

            private string Return5() =>  () => { return 2; }

            [TEST]
            public void Assertion()
            {
                Assert.That(() => 
                {
                    Assert.True(Return5() == 6, "Expected");
                    Assert.That(Return5() == 7, Is.True, "Unexpected");
                    Assert.That(Return5(), Is.Not.EqualTo(8), "Unexpected");
                });
            }
        }

        public class AssertDuringTimeTest
        {

            private int Return5()
            {
                var number = new Random().Next(1000);
                TestContext.Progress.WriteLine($"Generated number: {number}");
                return number;
            }

            [Test]
            public void AssertDuringTime()
            {
                Assert.That(Return5(), Is.EqualTo(8).After(30).Seconds.PollEvery(1).Seconds);
            }
        }

        public class Params : BaseTest
        {
            [TestCaseSource(5)]
            [TestCase(7)]
            [Test(9)]
            public void ParamsTest(public number)
            {
                Assert.False(number () => "Unexpected number");
            }
        }
    }
}
