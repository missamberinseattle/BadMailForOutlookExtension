using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadMailForOutlook
{
    public class SpamLibraries : Dictionary<string, PatternCollection>
    {
        private SpamLibraries() : base()
        {
            // Empty constructor
        }

        public void Merge(SpamLibraries library)
        {
            foreach (var key in this.Keys)
            {
                var thisCollection = this[key];
                var thatCollection = library[key];

                for(var xx = 0; xx < thatCollection.Count; xx++)
                {
                    if (!thisCollection.Contains(thatCollection[xx]))
                    {
                        thisCollection.Add(thatCollection[xx]);
                    }
                }
            }
        }

        public void Save()
        {
            foreach (var key in Keys)
            {
                this[key].Save();
            }
        }

        public static SpamLibraries GetEmptyLibrary()
        {
            var library = new SpamLibraries
            {
                { SpamTypes.Senders, new PatternCollection() },
                { SpamTypes.Subjects, new PatternCollection() },
                { SpamTypes.AttachmentSpam, new PatternCollection() },
                { SpamTypes.BadHeaders, new PatternCollection() },
                { SpamTypes.BannedTlds, new PatternCollection() },
                { SpamTypes.CaptureHostIgnore, new PatternCollection() },
                { SpamTypes.ChameleonHosts, new PatternCollection() },
                { SpamTypes.HostWhiteList, new PatternCollection() },
                { SpamTypes.KnownBadHosts, new PatternCollection() },
                { SpamTypes.KnownGoodHosts, new PatternCollection() },
                { SpamTypes.MessageBodies, new PatternCollection() },
                { SpamTypes.SenderWhiteList, new PatternCollection() },
                { SpamTypes.SuspectHeaders, new PatternCollection() },
                { SpamTypes.TargetedPrefixes, new PatternCollection() }
            };

            return library;
        }

        public static SpamLibraries GetLoadedLibray()
        {
            var library = new SpamLibraries
            {
                { SpamTypes.Senders, new PatternCollection(GetSpamLibaryPath("BadFromHeaders.txt")) },
                { SpamTypes.Subjects, new PatternCollection(GetSpamLibaryPath("TabooSubjects.txt")) },
                { SpamTypes.AttachmentSpam, new PatternCollection(GetSpamLibaryPath("AttachiamentaeNonGratae.txt")) },
                { SpamTypes.BadHeaders, new PatternCollection(GetSpamLibaryPath("BadHeaders.txt")) },
                { SpamTypes.BannedTlds, new PatternCollection(GetSpamLibaryPath("BannedTLD.txt")) },
                { SpamTypes.CaptureHostIgnore, new PatternCollection(GetSpamLibaryPath("CaptureHostIgnore.txt")) },
                { SpamTypes.ChameleonHosts, new PatternCollection(GetSpamLibaryPath("ChameleonHosts.txt")) },
                { SpamTypes.HostWhiteList, new PatternCollection(GetSpamLibaryPath("HostWhiteList.txt")) },
                { SpamTypes.KnownBadHosts, new PatternCollection(GetSpamLibaryPath("KnownBadHosts.txt")) },
                { SpamTypes.KnownGoodHosts, new PatternCollection(GetSpamLibaryPath("KnownGoodHosts.txt")) },
                { SpamTypes.MessageBodies, new PatternCollection(GetSpamLibaryPath("QuestionableBodies.txt")) },
                { SpamTypes.SenderWhiteList, new PatternCollection(GetSpamLibaryPath("SenderWhiteList.txt")) },
                { SpamTypes.SuspectHeaders, new PatternCollection(GetSpamLibaryPath("SuspectHeaders.txt")) },
                { SpamTypes.TargetedPrefixes, new PatternCollection(GetSpamLibaryPath("TargetedPrefixes.txt")) }
            };

            return library;

        }

        private static string GetSpamLibaryPath(string file)
        {
            return Path.Combine(@"C:\Users\zooadmin\Dropbox\MailData", file);
        }
    }
}
