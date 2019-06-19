using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Utils
{
    public static class Heplers
    {
        public static int ReturnRandomIntTenAsMax()
        {
            var number = new Random().Next(11);
            TestContext.Progress.WriteLine($"Generated number: {number}");
            return number;
        }
    }
}