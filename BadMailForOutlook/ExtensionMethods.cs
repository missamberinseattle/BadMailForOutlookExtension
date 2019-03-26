using Microsoft.Office.Interop.Outlook;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BadMailForOutlook
{

    public static class ExtensionMethods
    {
        #region String Extension Methods
        public static bool EndsWithAny(this string text, string[] endings)
        {
            foreach(var ending in endings)
            {
                if (text.EndsWith(text))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool EndsWithAny(this string text, string[] endings, StringComparison comparisonType)
        {
            foreach (var ending in endings)
            {
                if (text.EndsWith(text, comparisonType))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool EndsWithAny(this string text, string[] endings, bool ignoreCase, CultureInfo cultureInfo)
        {
            foreach (var ending in endings)
            {
                if (text.EndsWith(text, ignoreCase, cultureInfo))
                {
                    return true;
                }
            }

            return false;
        }

        public static int WordCount(this string text)
        {
            string pattern = "[^\\w]";
            //get all spaces and other signs, like: '.' '?' '!'

            string[] words = null;
            int i = 0;
            int count = 0;
            words = Regex.Split(text, pattern, RegexOptions.IgnoreCase);
            for (i = words.GetLowerBound(0); i <= words.GetUpperBound(0); i++)
            {
                if (words[i].ToString() == string.Empty)
                {
                    count = count - 1;
                }
                count = count + 1;
            }

            return count;
        }
        #endregion

        #region String Builder Extension Methods
        public static void Join(this StringBuilder builder, string text, string separator = "; ")
        {
            if (builder.Length > 0) builder.Append(separator);

            builder.Append(text);
        }
        #endregion

        #region MailItem Extension Methods
        private const string HeaderRegex =
            @"^(?<header_key>[-A-Za-z0-9]+)(?<seperator>:[ \t]*)" +
                "(?<header_value>([^\r\n]|\r\n[ \t]+)*)(?<terminator>\r\n)";
        private const string TransportMessageHeadersSchema =
            "http://schemas.microsoft.com/mapi/proptag/0x007D001E";

        public static string SingleHeader(this MailItem mailItem, string name, string defaultValue = "")
        {
            var results = mailItem.Headers(name);
            var value = defaultValue;

            if (results.Length > 0)
            {
                value = results[0];
            }

            return value;
        }
        public static string[] Headers(this MailItem mailItem, string name)
        {
            var headers = mailItem.HeaderLookup();
            if (headers.Contains(name))
                return headers[name].ToArray();
            return new string[0];
        }

        public static string GetFirstHeader(this MailItem mailItem, string name)
        {
            var values = mailItem.Headers(name);

            if (values.Length == 1)
            {
                return values[0];
            }

            if (values.Length == 0)
            {
                return null;
            }

            return string.Join("\r\n", values);
        }

        public static ILookup<string, string> HeaderLookup(this MailItem mailItem)
        {
            var headerString = mailItem.HeaderString();
            var headerMatches = Regex.Matches
                (headerString, HeaderRegex, RegexOptions.Multiline).Cast<Match>();
            return headerMatches.ToLookup(
                h => h.Groups["header_key"].Value,
                h => h.Groups["header_value"].Value);
        }

        public static string HeaderString(this MailItem mailItem)
        {
            return (string)mailItem.PropertyAccessor
                .GetProperty(TransportMessageHeadersSchema);
        }
        #endregion
    }
}