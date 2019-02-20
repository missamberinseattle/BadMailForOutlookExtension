namespace BadMailForOutlook
{
    partial class SpamResultsForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpamResultsForm));
            this.SpamTabs = new System.Windows.Forms.TabControl();
            this.SpamTabPage = new System.Windows.Forms.TabPage();
            this.BtnOk = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.ListViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.viewMailRejectionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SpamTabs.SuspendLayout();
            this.ListViewContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // SpamTabs
            // 
            this.SpamTabs.Controls.Add(this.SpamTabPage);
            this.SpamTabs.Location = new System.Drawing.Point(12, 12);
            this.SpamTabs.Name = "SpamTabs";
            this.SpamTabs.SelectedIndex = 0;
            this.SpamTabs.Size = new System.Drawing.Size(523, 319);
            this.SpamTabs.TabIndex = 0;
            // 
            // SpamTabPage
            // 
            this.SpamTabPage.Location = new System.Drawing.Point(4, 22);
            this.SpamTabPage.Name = "SpamTabPage";
            this.SpamTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.SpamTabPage.Size = new System.Drawing.Size(515, 293);
            this.SpamTabPage.TabIndex = 0;
            this.SpamTabPage.UseVisualStyleBackColor = true;
            // 
            // BtnOk
            // 
            this.BtnOk.Location = new System.Drawing.Point(372, 337);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(75, 23);
            this.BtnOk.TabIndex = 1;
            this.BtnOk.Text = "&OK";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(453, 337);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(75, 23);
            this.BtnCancel.TabIndex = 2;
            this.BtnCancel.Text = "&Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            // 
            // ListViewContextMenu
            // 
            this.ListViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolStripMenuItem1,
            this.viewMailRejectionsToolStripMenuItem});
            this.ListViewContextMenu.Name = "ListViewContextMenu";
            this.ListViewContextMenu.Size = new System.Drawing.Size(189, 98);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.copyToolStripMenuItem.Text = "&Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.editToolStripMenuItem.Text = "&Edit...";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(185, 6);
            // 
            // viewMailRejectionsToolStripMenuItem
            // 
            this.viewMailRejectionsToolStripMenuItem.Name = "viewMailRejectionsToolStripMenuItem";
            this.viewMailRejectionsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.viewMailRejectionsToolStripMenuItem.Text = "&View mail rejections...";
            this.viewMailRejectionsToolStripMenuItem.Click += new System.EventHandler(this.viewMailRejectionsToolStripMenuItem_Click);
            // 
            // SpamResultsForm
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(543, 372);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.SpamTabs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SpamResultsForm";
            this.Text = "Analysis Results";
            this.Resize += new System.EventHandler(this.SpamResultsForm_Resize);
            this.SpamTabs.ResumeLayout(false);
            this.ListViewContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl SpamTabs;
        private System.Windows.Forms.TabPage SpamTabPage;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.ContextMenuStrip ListViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewMailRejectionsToolStripMenuItem;
    }
}