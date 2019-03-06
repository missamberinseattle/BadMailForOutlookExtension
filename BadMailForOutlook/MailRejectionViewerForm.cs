using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace BadMailForOutlook
{
    public partial class MailRejectionViewerForm : Form
    {
        #region Constructors, Destructors, and Initializers
        public MailRejectionViewerForm()
        {
            InitializeComponent();
        }

        private void LoadRejections()
        {
            StripLabelRejectionCount.Text = "";
            StripLabelMessage.Text = "";
            try
            {
                Rejections = MailRejection.LoadTimeRange(DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)));
                var bindingSource = new BindingSource();
                bindingSource.DataSource = Rejections;
                RejectionGrid.DataSource = bindingSource;

                StripLabelRejectionCount.Text = Rejections.Count.ToString();
                StripLabelRejectionCount.Alignment = ToolStripItemAlignment.Right;

                for (var xx = 0; xx < RejectionGrid.ColumnCount; xx++)
                {
                    RejectionGrid.Columns[xx].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Rejections not loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Rejections could not be loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Public Properties
        public List<MailRejection> Rejections { get; private set; }

        public MailRejection SelectedRejection
        {
            get
            {
                if (RejectionGrid.SelectedRows.Count == 0)
                {
                    return null;
                }

                return Rejections[RejectionGrid.SelectedRows[0].Index];
            }
        }
        #endregion

        #region Event Handlers
        #region Form Events
        private void MailRejectionViewerForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                LoadRejections();
            }
        }
        #endregion

        #region RejectionGrid Events
        private void RejectionGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var htEvent = RejectionGrid.HitTest(e.X, e.Y);
                               
                if (htEvent.RowIndex == -1) return;

                RejectionGrid.ClearSelection();
                RejectionGrid.Rows[htEvent.RowIndex].Selected = true;

                var reject = SelectedRejection;

                editRuleToolStripMenuItem.Enabled = true;
                viewLogEntryToolStripMenuItem.Enabled = true;

                disableRuleToolStripMenuItem.Visible = ( reject.RuleGroup != "CheckHost");
                whiteListHostToolStripMenuItem.Visible = !disableRuleToolStripMenuItem.Visible;
                GridContext.Show(MousePosition);
            }
        }
        private void whiteListHostToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rejection = SelectedRejection;

            //  { 207.211.34.125/r125.mail.fullbeauty.com;  -; None; 2; 5/20/2017 7:33:58 AM; 5/22/2017 7:58:05 AM }
            var spamIpXml = new XmlDocument();
            var filePath = Path.Combine(BadMailAddIn.MailDataPath, "spam-ip-catalog.xml");

            spamIpXml.Load(filePath);

            // <catalog>
            // <ip address="10.193.39.9" messageCount="2" firstSeen="12/29/2014 7:22:52 AM" lastSeen="12/29/2014 7:22:36 PM" host="10.193.39.9" state="None" modified="10/29/2018 10:41:42 PM" />

            string ip = null;
            try
            {
                ip = Regex.Match(rejection.Rule, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}", RegexOptions.IgnorePatternWhitespace).Value;
            }
            catch (ArgumentException ex)
            {
                Trace.WriteLine(ex.ToString());
            }

            if (ip == null)
            {
                SetStatus("Couuld not find IP address in rule");
                return;
            }

            // XPath query //catalog/ip[@address='1.163.149.184']

            XmlNode ipNode = spamIpXml.SelectSingleNode("//catalog/ip[@address='" + ip + "']");
            if (ipNode == null)
            {
                SetStatus("Could not find IP address in spam XML");
                return;
            }

            ipNode.Attributes["state"].Value = "WhiteList";

            spamIpXml.Save(filePath);
        }

        #endregion

        #region Window Menu Events
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotYetImplemented();
        }

        private void ruleGroupMappingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NotYetImplemented();
        }

        private void viewLogEntryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewMailLogEntry(RejectionGrid.SelectedCells);
        }

        private void openLogFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rejection = GetRejectionFromGrid();

            Process.Start(rejection.LogFilePath);
        }

        private void disableRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DisableRule();
        }
        #endregion

        #region Context Menu Events
        private void ViewMailLogEntry(DataGridViewSelectedCellCollection selectedCells)
        {
            var rowIndex = selectedCells[0].RowIndex;
            var reject = Rejections[rowIndex];
            var output = new StringBuilder();

            var keepGoing = true;
            var logDate = reject.RejectedOn;

            while (keepGoing)
            {

                var filePath = MailRejection.GetLogFilePath(logDate);

                using (TextReader reader = new StreamReader(filePath))
                {
                    var fileRow = 0;
                    var line = string.Empty;

                    while (true)
                    {
                        fileRow++;

                        line = reader.ReadLine();

                        if (line == null) break;
                        if (fileRow < reject.LogLine) continue;

                        // 09:12:01.5101	Statistics	    Total: 726; Accepted: 376; Rejected: 337 (AcceptNoImitations: 2, BannedTldHosts: 80, BannedTldSenders: 20, ChameleonHostsForbidden: 28, CheckHost: 8, Exception: 1, MalformedFromHeader: 4, NoNameHostReject: 130, NoPoorlyChosenNames: 41, NoQuestionableBodies: 18, RejectImposters: 2, RejectTabooTopics: 3)
                        if (line.Contains("\tStatistics\t"))
                        {
                            keepGoing = false;
                            break;
                        }

                        output.AppendLine(line);
                    }
                }

                logDate = logDate.AddDays(1);
            }

            TextViewerForm.DisplayForm(output.ToString(), "Log Entry");
        }

        private void editRuleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditRule();
        }
        #endregion

        #endregion

        #region Helper Methods
        private void SetStatus(string text)
        {
            StripLabelMessage.Text = text;
        }
        private void EditRule()
        {
            var rejection = GetRejectionFromGrid();
            var map = RuleGroupConfigMap.Instance;

            var filePath = Path.Combine(BadMailAddIn.MailDataPath, map.GetFile(rejection.RuleGroup));

            var patterns = new PatternCollection(filePath);

            var pattern = patterns.Find(rejection.Rule);

            if (pattern == null)
            {
                MessageBox.Show("Could not find rule in the configuration files", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var newPattern = EditRuleForm.DisplayEditForm(pattern);

            if (newPattern == null) return;

            patterns.Remove(pattern);
            patterns.Add(newPattern);
            
            patterns.Save();
        }


        private void DisableRule()
        {
            var rejection = GetRejectionFromGrid();
            var map = RuleGroupConfigMap.Instance;

            var filePath = Path.Combine(BadMailAddIn.MailDataPath, map.GetFile(rejection.RuleGroup));

            var patterns = new PatternCollection(filePath);

            var pattern = patterns.Find(rejection.Rule);

            if (pattern == null)
            {
                MessageBox.Show("Could not find rule in the configuration files", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pattern.Enable = false;
            patterns.MarkDirty();

            patterns.Save();
        }

        private bool IsOnlyRowOneSelected()
        {
            if (RejectionGrid.SelectedRows.Count > 1) return false;
            if (RejectionGrid.SelectedColumns.Count > 0) return false;

            var curRow = -1;

            foreach (DataGridViewCell cell in RejectionGrid.SelectedCells)
            {
                if (curRow == -1)
                {
                    curRow = cell.RowIndex;
                }
                else if (curRow != cell.RowIndex)
                {
                    return false;
                }
            }

            return true;
        }


        private MailRejection GetRejectionFromGrid()
        {
            var rowIndex = RejectionGrid.SelectedCells[0].RowIndex;
            return Rejections[rowIndex];
        }

        private void NotYetImplemented()
        {
            MessageBox.Show("Not yet implemented.", "Not done yet!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
        #endregion

    }
}
