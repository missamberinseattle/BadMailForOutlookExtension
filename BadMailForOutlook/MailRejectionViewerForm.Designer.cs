namespace BadMailForOutlook
{
    partial class MailRejectionViewerForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailRejectionViewerForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ruleGroupMappingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RejectionGrid = new System.Windows.Forms.DataGridView();
            this.Status = new System.Windows.Forms.StatusStrip();
            this.StripLabelRejectionCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.GridContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.viewLogEntryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.disableRuleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RejectionGrid)).BeginInit();
            this.Status.SuspendLayout();
            this.GridContext.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewlToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.exportToolStripMenuItem.Text = "&Export...";
            this.exportToolStripMenuItem.Click += new System.EventHandler(this.exportToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // viewlToolStripMenuItem
            // 
            this.viewlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ruleGroupMappingsToolStripMenuItem});
            this.viewlToolStripMenuItem.Name = "viewlToolStripMenuItem";
            this.viewlToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewlToolStripMenuItem.Text = "&View";
            // 
            // ruleGroupMappingsToolStripMenuItem
            // 
            this.ruleGroupMappingsToolStripMenuItem.Name = "ruleGroupMappingsToolStripMenuItem";
            this.ruleGroupMappingsToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            this.ruleGroupMappingsToolStripMenuItem.Text = "&Rule Group Mappings...";
            this.ruleGroupMappingsToolStripMenuItem.Click += new System.EventHandler(this.ruleGroupMappingsToolStripMenuItem_Click);
            // 
            // RejectionGrid
            // 
            this.RejectionGrid.AllowUserToAddRows = false;
            this.RejectionGrid.AllowUserToDeleteRows = false;
            this.RejectionGrid.AllowUserToOrderColumns = true;
            this.RejectionGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.DarkBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RejectionGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.RejectionGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.RejectionGrid.DefaultCellStyle = dataGridViewCellStyle5;
            this.RejectionGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RejectionGrid.Location = new System.Drawing.Point(0, 24);
            this.RejectionGrid.Margin = new System.Windows.Forms.Padding(2);
            this.RejectionGrid.Name = "RejectionGrid";
            this.RejectionGrid.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.RejectionGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.RejectionGrid.RowTemplate.Height = 28;
            this.RejectionGrid.Size = new System.Drawing.Size(800, 426);
            this.RejectionGrid.TabIndex = 1;
            this.RejectionGrid.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RejectionGrid_CellMouseClick);
            this.RejectionGrid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.RejectionGrid_ColumnHeaderMouseClick);
            // 
            // Status
            // 
            this.Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripLabelRejectionCount});
            this.Status.Location = new System.Drawing.Point(0, 428);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(800, 22);
            this.Status.TabIndex = 2;
            this.Status.Text = "statusStrip1";
            // 
            // StripLabelRejectionCount
            // 
            this.StripLabelRejectionCount.Name = "StripLabelRejectionCount";
            this.StripLabelRejectionCount.Size = new System.Drawing.Size(0, 17);
            // 
            // GridContext
            // 
            this.GridContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openLogFileToolStripMenuItem,
            this.toolStripMenuItem2,
            this.viewLogEntryToolStripMenuItem,
            this.editRuleToolStripMenuItem,
            this.toolStripMenuItem1,
            this.disableRuleToolStripMenuItem});
            this.GridContext.Name = "GridContext";
            this.GridContext.Size = new System.Drawing.Size(181, 126);
            // 
            // viewLogEntryToolStripMenuItem
            // 
            this.viewLogEntryToolStripMenuItem.Name = "viewLogEntryToolStripMenuItem";
            this.viewLogEntryToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewLogEntryToolStripMenuItem.Text = "&View log entry...";
            this.viewLogEntryToolStripMenuItem.Click += new System.EventHandler(this.viewLogEntryToolStripMenuItem_Click);
            // 
            // editRuleToolStripMenuItem
            // 
            this.editRuleToolStripMenuItem.Name = "editRuleToolStripMenuItem";
            this.editRuleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editRuleToolStripMenuItem.Text = "&Edit rule...";
            this.editRuleToolStripMenuItem.Click += new System.EventHandler(this.editRuleToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // disableRuleToolStripMenuItem
            // 
            this.disableRuleToolStripMenuItem.Name = "disableRuleToolStripMenuItem";
            this.disableRuleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.disableRuleToolStripMenuItem.Text = "&Disable rule... ";
            this.disableRuleToolStripMenuItem.Click += new System.EventHandler(this.disableRuleToolStripMenuItem_Click);
            // 
            // openLogFileToolStripMenuItem
            // 
            this.openLogFileToolStripMenuItem.Name = "openLogFileToolStripMenuItem";
            this.openLogFileToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openLogFileToolStripMenuItem.Text = "&Open log file";
            this.openLogFileToolStripMenuItem.Click += new System.EventHandler(this.openLogFileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // MailRejectionViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Status);
            this.Controls.Add(this.RejectionGrid);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MailRejectionViewerForm";
            this.Text = "Mail Rejections";
            this.VisibleChanged += new System.EventHandler(this.MailRejectionViewerForm_VisibleChanged);
            this.Resize += new System.EventHandler(this.MailRejectionViewerForm_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RejectionGrid)).EndInit();
            this.Status.ResumeLayout(false);
            this.Status.PerformLayout();
            this.GridContext.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.DataGridView RejectionGrid;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ruleGroupMappingsToolStripMenuItem;
        private System.Windows.Forms.StatusStrip Status;
        private System.Windows.Forms.ToolStripStatusLabel StripLabelRejectionCount;
        private System.Windows.Forms.ContextMenuStrip GridContext;
        private System.Windows.Forms.ToolStripMenuItem viewLogEntryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editRuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem disableRuleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openLogFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
    }
}