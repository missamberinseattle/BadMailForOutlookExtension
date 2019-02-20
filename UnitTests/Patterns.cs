using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BadMailForOutlook;

namespace BadMailForOutlook.UnitTests
{
    [TestClass]
    public class Patterns
    {
        [TestMethod]
        public void Pattern_FromText()
        {
            var pattern = Pattern.FromText("Urgent Blood Sugar Info");
        }

        [TestMethod]
        public void Pattern_FromRegEx_EnabledNoSample()
        {
            var testValue = "paypal.?deposit.?received.?\\d{1,2}.?\\d{1,2}";
            var expected = "paypal.?deposit.?received.?\\d{1,2}.?\\d{1,2}";

            var pattern = Pattern.FromRegEx(testValue);

            Assert.IsTrue(pattern.Enable, "Pattern is not enable");
            Assert.IsTrue(pattern.Sample.Length == 0, "Sample is not empty");
            Assert.IsTrue(pattern.Expression == expected, "Expression (" + pattern.Expression + ") != expected (" + expected + ")");
        }

        [TestMethod]
        public void Pattern_FromRegEx_EnabledNoSampleWithTrailingSpaces()
        {
            var testValue = "paypal.?deposit.?received.?\\d{1,2}.?\\d{1,2}     ";
            var expected = "paypal.?deposit.?received.?\\d{1,2}.?\\d{1,2}";

            var pattern = Pattern.FromRegEx(testValue);

            Assert.IsTrue(pattern.Enable, "Pattern is not enable");
            Assert.IsTrue(pattern.Sample.Length == 0, "Sample is not empty");
            Assert.IsTrue(pattern.Expression == expected, "Expression (" + pattern.Expression + ") != expected (" + expected + ")");
        }

        [TestMethod]
        public void Pattern_FromRegEx_EnabledNoSampleWithTrailingTabs()
        {
            var testValue = "paypal.?deposit.?received.?\\d{1,2}.?\\d{1,2}\t\t\t";
            var expected = "paypal.?deposit.?received.?\\d{1,2}.?\\d{1,2}";

            var pattern = Pattern.FromRegEx(testValue);

            Assert.IsTrue(pattern.Enable, "Pattern is not enable");
            Assert.IsTrue(pattern.Sample.Length == 0, "Sample is not empty");
            Assert.IsTrue(pattern.Expression == expected, "Expression (" + pattern.Expression + ") != expected (" + expected + ")");
        }

        [TestMethod]
        public void Pattern_FromRegEx_EnabledNoSampleWithTrailingWhiteSpace()
        {
            var testValue = "paypal.?deposit.?received.?\\d{1,2}.?\\d{1,2}\t  \t\t    ";
            var expected = "paypal.?deposit.?received.?\\d{1,2}.?\\d{1,2}";

            var pattern = Pattern.FromRegEx(testValue);

            Assert.IsTrue(pattern.Enable, "Pattern is not enable");
            Assert.IsTrue(pattern.Sample.Length == 0, "Sample is not empty");
            Assert.IsTrue(pattern.Expression == expected, "Expression (" + pattern.Expression + ") != expected (" + expected + ")");
        }
    }
}
