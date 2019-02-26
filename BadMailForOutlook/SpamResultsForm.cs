using System;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace BadMailForOutlook
{
    public partial class SpamResultsForm : Form
    {
        public SpamResultsForm()
        {
            InitializeComponent();
        }

        public SpamLibraries SpamCollections { get; private set; }
        public ListView ActiveListView { get; private set; }

        public static SpamLibraries DisplayForm(SpamLibraries spamCollections)
        {
            var spamForm = new SpamResultsForm();
            spamForm.InitializeControls(spamCollections);

            dynamic activeWindow = BadMailAddIn.Session.Application.ActiveWindow();
            IOleWindow win = activeWindow as IOleWindow;
            IntPtr hWnd;

            win.GetWindow(out hWnd);

            IWin32Window window = Control.FromHandle(hWnd);

            var result = spamForm.ShowDialog(window);

            if (result == DialogResult.OK)
            {
                return spamForm.SpamCollections;
            }

            return null;
        }

        private void InitializeControls(SpamLibraries spamCollections)
        {
            var index = 0;

            foreach (var key in spamCollections.Keys)
            {
                TabPage page;

                if (spamCollections[key].Count > 0)
                {
                    if (index == 0)
                    {
                        page = SpamTabs.TabPages[0];
                        page.Text = key;
                        page.Name = key;
                    }
                    else
                    {
                        page = new TabPage(key);
                        page.Name = key;
                        page.Padding = SpamTabs.TabPages[0].Padding;
                        page.Margin = SpamTabs.TabPages[0].Margin;
                        page.Size = SpamTabs.TabPages[0].Size;
                        SpamTabs.TabPages.Add(page);
                    }

                    BuildSpamTabUi(page);
                    LoadListView(index, spamCollections[key]);
                    index++;
                }
            }
        }

        private void LoadListView(int tabIndex, PatternCollection patternCollection)
        {
            var tabPage = SpamTabs.TabPages[tabIndex];
            var listView = (ListView)tabPage.Controls[0];
            listView.CheckBoxes = true;
            listView.FullRowSelect = true;
            listView.HeaderStyle = ColumnHeaderStyle.Clickable;
            listView.MouseClick += ListView_MouseClick;
            foreach (var pattern in patternCollection)
            {
                var lvItem = new ListViewItem();
                lvItem.Checked = pattern.Enable;
                lvItem.Text = pattern.Expression;
                // lvItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = pattern.Expression });
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = pattern.Sample });
                lvItem.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = pattern.GetWarnings() });

                listView.Items.Add(lvItem);
            }
        }

        private void ListView_MouseClick(object sender, MouseEventArgs e)
        {
            ActiveListView = (ListView)sender;

            if (e.Button == MouseButtons.Right)
            {
                if (ActiveListView.FocusedItem.Bounds.Contains(e.Location))
                {
                    ListViewContextMenu.Tag = ActiveListView;
                    ListViewContextMenu.Show(Cursor.Position);
                }
            }
            else if (e.Clicks == 2 && e.Button == MouseButtons.Left)
            {
                ListViewContextMenu.Tag = ActiveListView;
                editToolStripMenuItem_Click(this, EventArgs.Empty);
            }
        }

        private void BuildSpamTabUi(TabPage page)
        {
            var listView = new ListView();

            page.Controls.Add(listView);

            listView.Dock = DockStyle.Fill;
            listView.View = View.Details;

            var colWidthPattern = (int)(listView.Width * .40);
            var colWidthSample = (int)(listView.Width * .30);
            var colWidthWarnings = (int)(listView.Width * .30);

            listView.Columns.Add(new ColumnHeader { Name = "Pattern", Text = "Pattern", Width = colWidthPattern });
            listView.Columns.Add(new ColumnHeader { Name = "Sample", Text = "Sample", Width = colWidthSample });
            listView.Columns.Add(new ColumnHeader { Name = "Warnings", Text = "Warnings", Width = colWidthWarnings });
        }

        private void SpamResultsForm_Resize(object sender, EventArgs e)
        {
            var margin = 12;

            try
            {
                BtnCancel.Top = Height - (margin * 4) - BtnCancel.Height;
                BtnCancel.Left = Width - (margin * 2) - BtnCancel.Width;

                Trace.WriteLine("BtnCancel.Location = " + BtnCancel.Location + "; BrnCancel.Size = " + BtnCancel.Size);
                BtnOk.Top = BtnCancel.Top;
                BtnOk.Left = BtnCancel.Left - margin - BtnOk.Width;

                SpamTabs.Width = Width - (margin * 3);
                SpamTabs.Height = Height - SpamTabs.Top - (margin * 5) - BtnCancel.Height;

            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }

        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            var spamCollections = SpamLibraries.GetEmptyLibrary();

            foreach (var key in spamCollections.Keys)
            {
                if (SpamTabs.TabPages.ContainsKey(key))
                {
                    TabPage page = SpamTabs.TabPages[key];
                    var spamList = page.Controls[0] as ListView;

                    for (var xx = 0; xx < spamList.Items.Count; xx++)
                    {
                        var item = spamList.Items[xx];

                        if (!item.Checked) continue;

                        var pattern = Pattern.FromRegEx(item.Text);
                        pattern.Sample = item.SubItems[0].Text;

                        if (!spamCollections[key].Contains(pattern))
                        {
                            spamCollections[key].Add(pattern);
                        }
                    }
                }
            }

            SpamCollections = spamCollections;
            Close();
            DialogResult = DialogResult.OK;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListViewItem item = ActiveListView.SelectedItems[0];

            var pattern = Pattern.FromRegEx(item.Text, item.SubItems[1].Text);
            pattern.Enable = item.Checked;

            var result = EditRuleForm.DisplayEditForm(pattern);

            if (result != null)
            {
                item.Checked = pattern.Enable;
                item.Text = pattern.Expression;
                item.SubItems[1].Text = pattern.Sample;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var listView = ListViewContextMenu.Tag as ListView;

            if (!(listView is ListView))
            {
                Trace.WriteLine("Not a ListView!");
                return;
            }

            var clipboard = new StringBuilder();

            foreach(ListViewItem item in listView.SelectedItems)
            {
                var pattern = Pattern.FromRegEx(item.Text, item.SubItems[0].Text);
                pattern.Enable = item.Checked;

                clipboard.AppendLine(pattern.FormatForFile());
            }

            Clipboard.SetText(clipboard.ToString());

            MessageBox.Show("Patterns copied to clipboard.", "Clipboard");
        }

        private void viewMailRejectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rejections = new MailRejectionViewerForm();
            rejections.Show();
        }

    }
}
