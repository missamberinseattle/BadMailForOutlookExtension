using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BadMailForOutlook
{
    public partial class AcceptedMailViewerForm : Form
    {
        public AcceptedMailViewerForm()
        {
            InitializeComponent();
        }

        // Parsing reg
        // \d\d:\d\d:\d\d\.\d{4}\t\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\tEmail accepted\r?\n(?<EmailDump>.*?)\d\d:\d\d:\d\d\.\d{4}\t\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\tTSV

        /*
            string resultString = null;
            try {
	            resultString = Regex.Match(subjectString, @"\d\d:\d\d:\d\d\.\d{4}\t\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\tEmail accepted\r?\n(?<EmailDump>.*?)\d\d:\d\d:\d\d\.\d{4}\t\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\tTSV", RegexOptions.Singleline).Groups["EmailDump"].Value;
            } catch (ArgumentException ex) {
	            // Syntax error in the regular expression
            }
         */
    }
}
