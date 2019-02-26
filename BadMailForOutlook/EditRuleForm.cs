using System.Windows.Forms;

namespace BadMailForOutlook
{
    public partial class EditRuleForm : Form
    {
        public EditRuleForm()
        {
            InitializeComponent();
        }


        public static Pattern DisplayEditForm(Pattern pattern)
        {
            var form = new EditRuleForm();
            form.EditRulePattern.Text = pattern.Expression;
            form.EditSample.Text = pattern.Sample;
            form.IsRuleEnabled.Checked = pattern.Enable;

            var result = form.ShowDialog();

            if (result == DialogResult.Cancel) return null;

            pattern.Expression = form.EditRulePattern.Text;
            pattern.Sample = form.EditSample.Text;
            pattern.Enable = form.IsRuleEnabled.Checked;

            return pattern;
        }

        private void EditRulePattern_Enter(object sender, System.EventArgs e)
        {
            EditRulePattern.SelectAll();
        }

        private void EditSample_Enter(object sender, System.EventArgs e)
        {
            EditSample.SelectAll();
        }

        private void EditRulePattern_TextChanged(object sender, System.EventArgs e)
        {
            ButtonOK.Enabled = (EditRulePattern.Text.Trim().Length > 0);
        }

        private void ButtonOK_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ButtonCancel_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
