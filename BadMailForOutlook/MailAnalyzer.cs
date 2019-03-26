using Microsoft.Office.Interop.Outlook;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace BadMailForOutlook
{
    public class MailAnalyzer
    {
        private const string NameDataPath = @"c:\users\zooadmin\Dropbox\MailData\Names.txt";

        private readonly MailItem _item;
        private static List<string> _names = null;

        public List<string> Names
        {
            get
            {
                if (_names == null)
                {
                    _names = File.ReadAllLines(NameDataPath).ToList();
                }

                return _names;
            }
        }

        public string Subject { get { return _item.Subject; } }
        public string SenderDisplayName { get; private set; }
        public string SenderEmailAddress { get; private set; }
        public string HostIP { get; private set; }
        public string HostName { get; private set; }
        public string SmtpSender { get; private set; }
        public string ReplyTo { get; private set; }

        public static PatternCollection BadSenders
        {
            get
            {
                return PatternCollection.GetCollection(GetMailDataPath("BadFromHeaders.txt"));
            }
        }

        private static string GetMailDataPath(string fileName)
        {
            return Path.Combine(@"c:\Users\zooadmin\Dropbox\MailData", fileName);
        }

        public MailAnalyzer(MailItem item)
        {
            _item = item;

            SenderDisplayName = _item.SenderName;
            SenderEmailAddress = _item.SenderEmailAddress;
            HostIP = _item.SingleHeader("X-FromIP");
            HostName = _item.SingleHeader("X-HostName");
            SmtpSender = _item.SingleHeader("X-SmtpFrom");
            ReplyTo = _item.SingleHeader("Reply-To");
        }

        public PatternCollection GetSpamSenders()
        {
            var senders = new List<string>();
            var patterns = new PatternCollection();
            var queue = new List<string>();

            queue.Add(SenderDisplayName);
            queue.Add(SenderEmailAddress);
            queue.Add(SmtpSender);
            queue.Add(ReplyTo);

            foreach (var item in queue)
            {
                if (item.Length == 0) continue;

                try
                {
                    var email = new MailAddress(item);
                    senders.Add(email.DisplayName);
                    senders.Add(email.Address);
                }
                catch (FormatException)
                {
                    senders.Add(item);
                }
                catch (System.Exception)
                {
                    throw;
                }
            }

            for (var xx = 0; xx < senders.Count; xx++)
            {
                if (string.IsNullOrEmpty(senders[xx])) { continue; }

                var text = RemoveNames(senders[xx]);

                if (text.Length == 0) continue;

                var pattern = Pattern.FromText(text);

                if (patterns.Contains(pattern)) { continue; }

                patterns.Add(pattern);
            }

            return patterns;
        }

        private string RemoveNames(string text)
        {
            var wordBoundaries = (" ,.<>;:[]{}()!@#$%^&*()-_`~=+").ToCharArray();
            var words = text.Split(wordBoundaries, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var word in words)
            {
                if (!Names.Contains(word.ToUpper())) continue;

                return "";
            }

            return text;
        }

        private string GetSpamWords(string text)
        {
            var names = NameList.GetInstance(@"c:\Users\zooadmin\Dropbox\MailData\Names.txt");

            var words = text.Split(new[] { " ", "@", "." }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var word in words)
            {
                if (names.HasName(word))
                {
                    return null;
                }
            }

            return text;
        }

        internal static List<MailAnalyzer> ProcessItems(List<MailItem> mailItems, out SpamLibraries patternCollections)
        {
            var items = new List<MailAnalyzer>();
            var badSenders = new List<string>();

            patternCollections = SpamLibraries.GetEmptyLibrary();

            var trashFolder = BadMailAddIn.Session.GetDefaultFolder(OlDefaultFolders.olFolderDeletedItems);

            foreach (var item in mailItems)
            {
                var analyzed = new MailAnalyzer(item);
                items.Add(analyzed);

                patternCollections[SpamTypes.Senders].AddRange(analyzed.GetSpamSenders());
                patternCollections[SpamTypes.Subjects].Add(GetSpamSubject(analyzed.Subject));
                patternCollections[SpamTypes.AttachmentSpam].AddRange(analyzed.GetSpamAttachments());
                patternCollections[SpamTypes.BannedTlds].AddRange(analyzed.GetSuspectTlds());
                patternCollections[SpamTypes.ChameleonHosts].AddRange(analyzed.GetChameleonHosts());
                patternCollections[SpamTypes.ChameleonHosts].AddRange(analyzed.GetBadHosts());
                patternCollections[SpamTypes.MessageBodies].AddRange(analyzed.GetSuspectLinks());
                item.Move(trashFolder);
            }

            var spamResults = SpamResultsForm.DisplayForm(patternCollections);

            if (spamResults != null)
            {
                var masterCollection = SpamLibraries.GetLoadedLibray();
                masterCollection.Merge(spamResults);
                masterCollection.Save();
            }
            return items;
        }

        private PatternCollection GetSuspectLinks()
        {
            var body = _item.Body;
            var patterns = new PatternCollection();
            if (body == null) return patterns;

            patterns.AddRange(GetShortTLDLinks(body));
            patterns.AddRange(GetAllUrls(body));

            return patterns;
        }

        private PatternCollection GetAllUrls(string body)
        {
            var patterns = new PatternCollection();
            // 

            var regEx = new Regex(@"<(?<link>https?://.*?)>");

            MatchCollection matches = regEx.Matches(body);

            foreach (Match match in matches)
            {
                var value = match.Groups["link"];
                var href = value.Value;

                var pattern = Pattern.FromRegEx(href, href);

                if (href.EndsWithAny(new[] {".png", ".jpg", ".gif" }))
                {
                    pattern.Enable = false;
                }

                if (!patterns.Contains(pattern))
                {
                    patterns.Add(pattern);
                }
            }

            return patterns;
        }

        private PatternCollection GetShortTLDLinks(string body)
        {
            var patterns = new PatternCollection();

            var regEx = new Regex(@"<(?<link>https?://[a-z0-9\-]{1,20}\.[a-z]{2}/).*>");

            MatchCollection matches = regEx.Matches(body);

            foreach (Match match in matches)
            {
                var value = match.Groups["link"];
                var href = value.Value;
                var whackWhackPos = href.IndexOf("://");
                var lastDotPos = href.LastIndexOf(".");
                var domainBegin = whackWhackPos + 3;
                var sldLen = lastDotPos - domainBegin + 1; // second level domain

                href = href.Replace(href.Substring(domainBegin, sldLen), @"[a-z0-9-_.]*\.");
                // 0....|....1....|....2
                // https://booger.su/
                // wwp = 5
                // domainBegain = wwp + 3 (8)
                // ldp = 14
                // 8,6

                var pattern = Pattern.FromRegEx(href, value.Value);

                if (!patterns.Contains(pattern))
                {
                    patterns.Add(pattern);
                }
            }

            return patterns;
        }

        private PatternCollection GetBadHosts()
        {
            var hosts = new List<string>{
                HostName,
                GetEmailHost(SenderEmailAddress),
                GetEmailHost(SmtpSender)
            };

            var patterns = new PatternCollection();

            foreach (var host in hosts)
            {
                var pattern = Pattern.FromText(host);

                if (!patterns.Contains(pattern)) patterns.Add(pattern);
            }
            return patterns;
        }

        private string GetEmailHost(string address)
        {
            var result = string.Empty;
            if (string.IsNullOrEmpty(address)) return result;

            try
            {
                var email = new MailAddress(address);
                result = email.Host;
            }
            catch (System.Exception)
            {
                // Do notiong
            }

            return result;
        }

        private PatternCollection GetChameleonHosts()
        {
            var hosts = new List<string>{
                HostName,
                GetEmailHost(SenderEmailAddress),
                GetEmailHost(SmtpSender)
            };

            var patterns = new PatternCollection();

            foreach (var host in hosts)
            {
                // Chameleon host vortex33
                var foundMatch = Regex.IsMatch(host, @"\b[a-z]{1,50}\d{1,50}\.[a-z0-9]*\.[a-z]{2,20}\b");

                if (!foundMatch) continue;

                var pattern = Pattern.FromRegEx(host, host);
                if (!patterns.Contains(pattern)) patterns.Add(pattern);
            }

            return patterns;
        }

        private PatternCollection GetSuspectTlds()
        {
            var patterns = new PatternCollection();
            var tldList = new List<string>();

            tldList.Add(GetSpamTld(HostName));
            tldList.Add(GetSpamTld(ReplyTo));
            tldList.Add(GetSpamTld(SenderEmailAddress));
            tldList.Add(GetSpamTld(SmtpSender));

            foreach (var tld in tldList)
            {
                if (tld == null) continue;

                if (tld == ".com" || tld == ".net" || tld == ".org") continue;

                var pattern = Pattern.RawText(tld);

                if (patterns.Contains(pattern)) continue;

                patterns.Add(pattern);
            }

            return patterns;
        }

        private string GetSpamTld(string text)
        {
            if (string.IsNullOrEmpty(text)) return null;

            try
            {
                var email = new MailAddress(text);
                text = email.Host;
            }
            catch (FormatException)
            {
                // Do nothing
            }

            var lastDot = text.LastIndexOf(".");

            if (lastDot == -1) return null;

            var tld = text.Substring(lastDot).ToLower();

            if (text == ".com" || text == ".net" || text == ".org") return null;


            return tld;
        }

        public PatternCollection GetSpamAttachments()
        {
            var patterns = new PatternCollection();

            for (var xx = 0; xx < _item.Attachments.Count; xx++)
            {
                try
                {
                    var item = _item.Attachments[xx];

                    var pattern = Pattern.FromText(item.FileName);
                    patterns.Add(pattern);
                }
                catch (System.Exception ex)
                {
                    BadMailAddIn.LogError("Could not get attachment from _item. " + ex);
                }
            }

            return patterns;
        }

        public static Pattern GetSpamSubject(string subject)
        {
            if (subject == null) subject = string.Empty;

            Pattern result = null;
            var sample = subject;

            while (subject.StartsWith("RE:", StringComparison.InvariantCultureIgnoreCase) || subject.StartsWith(" "))
            {
                if (subject.StartsWith("RE:", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (subject.Length > 3)
                    {
                        subject = subject.Substring(3);
                    }
                    else
                    {
                        subject = "";
                    }
                }

                subject = subject.TrimStart(' ');
            }

            if (subject.Length == 0)
            {
                return result;
            }

            result = Pattern.FromText(subject);
            result.Sample = sample;

            return result;
        }
    }
}
