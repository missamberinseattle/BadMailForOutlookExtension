using System;
using System.Diagnostics;
using BadMailForOutlook;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadMailForOutlook.UnitTests
{
    [TestClass]
    public class NameList_Tests
    {
        [TestMethod]
        public void NameIndex_KnownValue()
        {
            var names = NameList.GetInstance("TestNames_5.txt");

            Assert.IsTrue(names.NameIndex("Amber") == 0);
            Assert.IsTrue(names.NameIndex("Danny") == 1);
            Assert.IsTrue(names.NameIndex("Donny") == 2);
            Assert.IsTrue(names.NameIndex("Gina") == 3);
            Assert.IsTrue(names.NameIndex("Willow") == 4);

        }

        [TestMethod]
        public void NameIndex_NotFoundValue()
        {
            var names = NameList.GetInstance("TestNames_5.txt");

            Assert.IsTrue(names.NameIndex("Lilith") == -1);
        }

        [TestMethod]
        public void NameIndex_BigList()
        {
            var names = NameList.GetInstance(@"c:\Users\zooadmin\Dropbox\MailData\Names.txt");

            Assert.IsTrue(names.NameIndex("Amber") != -1);
            Assert.IsTrue(names.NameIndex("Danny") != -1);
            Assert.IsTrue(names.NameIndex("Donny") != -1);
            Assert.IsTrue(names.NameIndex("Gina") != -1);
            Assert.IsTrue(names.NameIndex("Willow") != -1);

            Assert.IsTrue(names.NameIndex("Lilith") != -1);
        }

        [TestMethod]
        public void PerfTest_NameIndex()
        {
            var names = NameList.GetInstance(@"c:\Users\zooadmin\Dropbox\MailData\Names.txt");

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            for (var xx = 0; xx < 1000; xx++)
            {
                names.NameIndex("Amber");
                names.NameIndex("Danny");
                names.NameIndex("Donny");
                names.NameIndex("Gina");
                names.NameIndex("Willow");
                names.NameIndex("Lilith");
            }

            stopwatch.Stop();

            Debug.Write("PerfTest_NameIndex == " + stopwatch.ElapsedMilliseconds);
        }

        [TestMethod]
        public void PerfTest_HasName()
        {
            var names = NameList.GetInstance(@"c:\Users\zooadmin\Dropbox\MailData\Names.txt");

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            for (var xx = 0; xx < 1000; xx++)
            {
                names.HasName("Amber");
                names.HasName("Danny");
                names.HasName("Donny");
                names.HasName("Gina");
                names.HasName("Willow");
                names.HasName("Lilith");
            }

            stopwatch.Stop();

            Debug.Write("PerfTest_HasName == " + stopwatch.ElapsedMilliseconds);
        }
    }
}
