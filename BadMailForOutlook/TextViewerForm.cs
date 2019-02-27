using System.Windows.Forms;

namespace BadMailForOutlook
{
    public partial class TextViewerForm : Form
    {
        public TextViewerForm()
        {
            InitializeComponent();
        }

        public static void DisplayForm(string text, string caption)
        {
            var form = new TextViewerForm();
            form.Text = caption;
            form.TextWindow.Text = text;
            form.TextWindow.SelectionStart = 0;
            form.TextWindow.SelectionLength = 0;
            form.Show();
        }
    }
}
