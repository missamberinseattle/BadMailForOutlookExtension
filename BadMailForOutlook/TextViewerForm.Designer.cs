﻿namespace BadMailForOutlook
{
    partial class TextViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextViewerForm));
            this.TextWindow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextWindow
            // 
            this.TextWindow.BackColor = System.Drawing.SystemColors.Window;
            this.TextWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextWindow.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextWindow.Location = new System.Drawing.Point(0, 0);
            this.TextWindow.Multiline = true;
            this.TextWindow.Name = "TextWindow";
            this.TextWindow.ReadOnly = true;
            this.TextWindow.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TextWindow.Size = new System.Drawing.Size(800, 450);
            this.TextWindow.TabIndex = 0;
            // 
            // TextViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.TextWindow);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TextViewerForm";
            this.Text = "Rejection Log Entry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextWindow;
    }
}