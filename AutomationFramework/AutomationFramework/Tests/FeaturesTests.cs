using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Tests
{
    public class FeaturesTests
    {
        public class PassTest 
        {
            [Description("PassedTest Description")]
            [Test]
            public void PassedTest()
            {
                Assert.Pass("this test will pass");
            }
        }

        public class IgnoreTest
        {
            [Test]
            public void Ignored()
            {
                Assert.Ignore("Will be ignored. Reason");
            }
        }


        public class AssertTest
        {

            private int Return5() => 5;

            [Test]
            public void Assertion()
            {
                Assert.Multiple(() => 
                {
                    Assert.True(Return5() != 6, "Unexpected");
                    Assert.That(Return5() == 5, Is.True, "Unexpected");
                    Assert.That(Return5(), Is.Not.EqualTo(8), "Unexpected");
                });
            }
        }

        public class AssertDuringTimeTest
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
                Assert.That(() => ReturnRandomNumber(), Is.EqualTo(8).After(30).Seconds.PollEvery(1).Seconds);
            }
        }

        public class Params
        {
            static int[] Numbers = new int[] { 2, 4, 6, 8 };

            [TestCaseSource("Numbers")]
            [TestCase(10)]
            public void ParamsTest(int number)
            {
                Assert.False(number == 7, "Unexpected number");
            }
        }
    }
}
