namespace BadMailForOutlook
{
    partial class EditRuleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditRuleForm));
            this.RuleLabel = new System.Windows.Forms.Label();
            this.EditRulePattern = new System.Windows.Forms.TextBox();
            this.SampleLabel = new System.Windows.Forms.Label();
            this.EditSample = new System.Windows.Forms.TextBox();
            this.IsRuleEnabled = new System.Windows.Forms.CheckBox();
            this.ButtonOK = new System.Windows.Forms.Button();
            this.ButtonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RuleLabel
            // 
            this.RuleLabel.AutoSize = true;
            this.RuleLabel.Location = new System.Drawing.Point(13, 13);
            this.RuleLabel.Name = "RuleLabel";
            this.RuleLabel.Size = new System.Drawing.Size(66, 13);
            this.RuleLabel.TabIndex = 0;
            this.RuleLabel.Text = "&Rule Pattern";
            // 
            // EditRulePattern
            // 
            this.EditRulePattern.Location = new System.Drawing.Point(94, 10);
            this.EditRulePattern.Name = "EditRulePattern";
            this.EditRulePattern.Size = new System.Drawing.Size(228, 20);
            this.EditRulePattern.TabIndex = 1;
            this.EditRulePattern.TextChanged += new System.EventHandler(this.EditRulePattern_TextChanged);
            this.EditRulePattern.Enter += new System.EventHandler(this.EditRulePattern_Enter);
            // 
            // SampleLabel
            // 
            this.SampleLabel.AutoSize = true;
            this.SampleLabel.Location = new System.Drawing.Point(13, 46);
            this.SampleLabel.Name = "SampleLabel";
            this.SampleLabel.Size = new System.Drawing.Size(42, 13);
            this.SampleLabel.TabIndex = 2;
            this.SampleLabel.Text = "&Sample";
            // 
            // EditSample
            // 
            this.EditSample.Location = new System.Drawing.Point(94, 43);
            this.EditSample.Name = "EditSample";
            this.EditSample.Size = new System.Drawing.Size(228, 20);
            this.EditSample.TabIndex = 3;
            this.EditSample.Enter += new System.EventHandler(this.EditSample_Enter);
            // 
            // IsRuleEnabled
            // 
            this.IsRuleEnabled.AutoSize = true;
            this.IsRuleEnabled.Location = new System.Drawing.Point(257, 69);
            this.IsRuleEnabled.Name = "IsRuleEnabled";
            this.IsRuleEnabled.Size = new System.Drawing.Size(65, 17);
            this.IsRuleEnabled.TabIndex = 4;
            this.IsRuleEnabled.Text = "&Enabled";
            this.IsRuleEnabled.UseVisualStyleBackColor = true;
            // 
            // ButtonOK
            // 
            this.ButtonOK.Location = new System.Drawing.Point(166, 92);
            this.ButtonOK.Name = "ButtonOK";
            this.ButtonOK.Size = new System.Drawing.Size(75, 23);
            this.ButtonOK.TabIndex = 5;
            this.ButtonOK.Text = "OK";
            this.ButtonOK.UseVisualStyleBackColor = true;
            this.ButtonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // ButtonCancel
            // 
            this.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ButtonCancel.Location = new System.Drawing.Point(247, 92);
            this.ButtonCancel.Name = "ButtonCancel";
            this.ButtonCancel.Size = new System.Drawing.Size(75, 23);
            this.ButtonCancel.TabIndex = 6;
            this.ButtonCancel.Text = "Cancel";
            this.ButtonCancel.UseVisualStyleBackColor = true;
            this.ButtonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // EditRuleForm
            // 
            this.AcceptButton = this.ButtonOK;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.ButtonCancel;
            this.ClientSize = new System.Drawing.Size(337, 128);
            this.Controls.Add(this.ButtonCancel);
            this.Controls.Add(this.ButtonOK);
            this.Controls.Add(this.IsRuleEnabled);
            this.Controls.Add(this.EditSample);
            this.Controls.Add(this.SampleLabel);
            this.Controls.Add(this.EditRulePattern);
            this.Controls.Add(this.RuleLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditRuleForm";
            this.Text = "Edit Rule";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label RuleLabel;
        private System.Windows.Forms.TextBox EditRulePattern;
        private System.Windows.Forms.Label SampleLabel;
        private System.Windows.Forms.TextBox EditSample;
        private System.Windows.Forms.CheckBox IsRuleEnabled;
        private System.Windows.Forms.Button ButtonOK;
        private System.Windows.Forms.Button ButtonCancel;
    }
}