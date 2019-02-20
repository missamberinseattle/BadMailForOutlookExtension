using System;
using BadMailForOutlook;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BadMailForOutlook.UnitTests
{
    [TestClass]
    public class MailRejectionTests
    {
        [TestMethod]
        public void Load()
        {
            var rejections = MailRejection.LoadTimeRange(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)));
        }

        [TestMethod]
        public void Parse()
        {
            var line = @"12:08:44.3942	50.195.7.180	ChameleonHostsForbidden::Rejected Rejected host for matching chameleon host pattern::Rule \d{1,3}[-.]\d{1,3}[-.]\d{1,3}[-.]\d{1,3}[-.]static::Sample 50-195-7-180-static.hfc.comcastbusiness.net";
            var rejection = MailRejection.Parse(line, DateTime.Now.Date);
        }
    }
}
