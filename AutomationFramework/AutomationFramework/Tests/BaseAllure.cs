using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AutomationFramework.Tests
{
    public class BaseAllure
    {
        [OneTimeSetUp]
        public void InitiateAllure()
        {
            Environment.SetEnvironmentVariable("ALLURE_CONFIG",
               Path.Combine(TestContext.CurrentContext.WorkDirectory, "allureConfig.json"));
        }
    }
}