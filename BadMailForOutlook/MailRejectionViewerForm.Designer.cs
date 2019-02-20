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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailRejectionViewerForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.ListViewRejects = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // ListViewRejects
            // 
            this.ListViewRejects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListViewRejects.Location = new System.Drawing.Point(0, 24);
            this.ListViewRejects.Name = "ListViewRejects";
            this.ListViewRejects.Size = new System.Drawing.Size(800, 426);
            this.ListViewRejects.TabIndex = 1;
            this.ListViewRejects.UseCompatibleStateImageBehavior = false;
            // 
            // MailRejectionViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ListViewRejects);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MailRejectionViewerForm";
            this.Text = "Mail Rejections";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ListView ListViewRejects;
    }
}