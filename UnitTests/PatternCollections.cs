using BadMailForOutlook;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading;

namespace BadMailForOutlook.UnitTests
{
    [TestClass]
    public class PatternCollections
    {
        [TestMethod]
        public void LoadList()
        {
            var list = new PatternCollection("TestPatterns.txt");

            var OldCount = list.Count;

            File.AppendAllText("TestPatterns.txt", "\r\n#Added " + DateTime.Now.ToFileTimeUtc());

            Thread.Sleep(250);

            var newCount = list.Count;

            Assert.IsTrue(newCount == OldCount + 1);
        }
    }
}
