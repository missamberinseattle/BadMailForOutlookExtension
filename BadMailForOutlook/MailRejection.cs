using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BadMailForOutlook
{
    public class MailRejection
    {
        private static Regex _parseRegEx;

        private MailRejection()
        {

        }

        public DateTime RejectedOn { get; private set; }
        public string RuleGroup { get; private set; }
        public string Reason { get; private set; }
        public string Source { get; private set; }
        public string Rule { get; private set; }
        public string Sample { get; private set; }
        public string Match { get; private set; }

        public static List<MailRejection> LoadTimeRange(DateTime start)
        {
            return LoadTimeRange(start, DateTime.Now);
        }
        public static List<MailRejection> LoadTimeRange(DateTime start, DateTime end)
        {
            var result = new List<MailRejection>();

            if (start > end)
            {
                throw new ArgumentException("start must be less than end");
            }

            var curDate = start.Date;

            // 2/11/2019 20:58
            while (curDate <= end.Date)
            {
                //AGMSService_20190122.log
                var filePath = Path.Combine(BadMailAddIn.MailDataPath, "AGMSService_" + curDate.ToString("yyyyMMdd") + ".log");

                using (TextReader reader = new StreamReader(filePath))
                {
                    string line;

                    do
                    {
                        line = reader.ReadLine();

                        if (line == null)
                        {
                            break;
                        }

                        if (!IsRejectionContains(line))
                        {
                            continue;
                        }

                        var rejection = Parse(line, curDate);

                        if (rejection != null && rejection.RejectedOn >= start && rejection.RejectedOn <= end)
                        {
                            result.Add(rejection);
                        }
                        else if (rejection != null && rejection.RejectedOn > end)
                        {
                            break;
                        }
                    } while (line != null);

                    curDate = curDate.AddDays(1);
                }
            }

            return result;
        }

        public static MailRejection Parse(string line, DateTime date)
        {
            var rejection = new MailRejection();
            rejection.RejectedOn = date;

            if (_parseRegEx == null)
            {
                var parsePattern = @"(?<Time>\d\d:\d\d:\d\d\.\d{4})\t" +
                    @"(?<IpAddress>\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3})\t" +
                    @"(?<RuleGroup>[A-Za-z]*)::" +
                    @"Rejected (?<Reason>.*)::" +
                    @"Rule (?<Rule>.*)::" +
                    @"Sample (?<Sample>.*)";
                _parseRegEx = new Regex(parsePattern, RegexOptions.IgnoreCase);
            }

            Match match = _parseRegEx.Match(line);

            if (!match.Success) return null;

            var time = DateTime.Parse(match.Groups["Time"].Value);
            var span = new TimeSpan(0, time.Hour, time.Minute, time.Second, time.Millisecond);
            rejection.RejectedOn = date.Add(span);

            rejection.Source = match.Groups["IpAddress"].Value;
            rejection.RuleGroup = match.Groups["RuleGroup"].Value;
            rejection.Reason = match.Groups["Reason"].Value;
            rejection.Rule = match.Groups["Rule"].Value;
            rejection.Sample = match.Groups["Sample"].Value;

            return rejection;
        }

        public static bool IsRejectionRegex(string line)
        {
            var result = false;


            return result;
        }

        public static bool IsRejectionContains(string line)
        {
            var result = false;

            if (line.Contains("::Rejected"))
            {
                result = true;
            }

            return result;
        }
    }

    public class RejectionEventArgs : EventArgs
    {
        public RejectionEventArgs() : base()
        {

        }

        public RejectionEventArgs(MailRejection rejection) : base()
        {
            Rejection = rejection;
        }

        public MailRejection Rejection { get; private set; }
    }

}
