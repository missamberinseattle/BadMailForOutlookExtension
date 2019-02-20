using System;
using System.Text;

namespace BadMailForOutlook
{
    public class Pattern : IComparable<Pattern>
    {
        private Pattern()
        {
            Enable = true;
            Sample = string.Empty;
        }

        private static int maxExpressionLength = 0;
        private string _expression;

        public bool Enable { get; set; }
        public string Expression
        {
            get { return _expression; }
            set
            {
                if (value != null && value.Length > maxExpressionLength)
                {
                    maxExpressionLength = value.Length;
                }
                _expression = value;
            }
        }
        public string Sample { get; set; }

        public static Pattern FromRegEx(string regex, string sample = null)
        {
            var pattern = new Pattern();

            if (regex.StartsWith("#"))
            {
                pattern.Enable = false;
                regex = regex.Substring(1);
            }

            if (regex.Contains("#") && sample == null)
            {
                var pos = regex.IndexOf('#');
                pattern.Sample = regex.Substring(pos + 1).TrimStart(' ', '\t');
                regex = regex.Substring(0, pos);
            }
            else if (sample != null)
            {
                pattern.Sample = sample;
            }

            regex = regex.TrimEnd(' ', '\t');

            pattern.Expression = regex;

            return pattern;
        }


        public static Pattern FromText(string text)
        {
            return FromText(text, true);
        }
        public static Pattern FromText(string text, bool enable)
        {
            if (string.IsNullOrEmpty(text)) return null;

            var pattern = new Pattern();

            pattern.Expression = CreateExpression(text);
            pattern.Sample = text;
            pattern.Enable = enable;

            return pattern;
        }

        public static string GenerateSample(string expression)
        {
            if (expression.IndexOf('#') > 0)
            {
                var sample = expression.Substring(expression.IndexOf('#', 1));
                return sample;
            }

            expression = expression.Replace(@"\.", ".");


            return expression;
        }

        public string FormatForFile()
        {
            var output = new StringBuilder();
            var space = new string(' ', maxExpressionLength + 2); // 1 for a possible leading comment and another for the sample

            if (!Enable)
            {
                output.Append("#");
            }

            output.Append(Expression);

            if (Sample != null && Sample.Length > 0)
            {
                output.Append(space.Substring(0, output.Length));
                output.Append("#");
                output.Append(Sample);
            }

            return output.ToString();
        }

        public string GetWarnings()
        {
            var warnings = new StringBuilder();

            if (Sample.Length < 6) warnings.Join("Under 6 characters long;");
            if (Sample.WordCount() < 3) warnings.Join("Pattern for " + Sample.WordCount() +" words");

            return warnings.ToString();
        }

        public static string CreateExpression(string text)
        {
            var badChars = @" []\^$.|?*+(){}#";
            var numChars = "0123456789";
            var digitReplacement = @"\d{1,25}";
            text = text.ToLower();
            var output = "";
            for (var xx = 0; xx < text.Length; xx++)
            {
                var chr = text[xx].ToString();

                if (badChars.Contains(chr))
                {
                    chr = ".?";
                }
                else if (numChars.Contains(chr))
                {
                    chr = digitReplacement;
                }

                output += chr;
            }

            while (output.Contains(digitReplacement + digitReplacement))
            {
                output = output.Replace(digitReplacement + digitReplacement, digitReplacement);
            }

            return @"\b" + output + @"\b";
        }

        public override string ToString()
        {
            var output = new StringBuilder();

            output.Append("{ ");
            output.Append(Expression);

            if (!Enable)
            {
                output.Append(" (disabled)");
            }
            output.Append(" }");
            return output.ToString();
        }

        public int CompareTo(Pattern that)
        {
            if (that == null)
            {
                return 1;
            }

            return this.Expression.CompareTo(that.Expression);
        }

        public static Pattern RawText(string value)
        {
            var pattern = new Pattern();
            pattern.Expression = value;

            return pattern;
        }
    }
}
