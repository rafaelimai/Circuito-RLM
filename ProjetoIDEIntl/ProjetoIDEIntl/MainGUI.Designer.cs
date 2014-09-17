namespace ProjetoIDEIntl
{
    partial class MainGUI
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.filesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openTranslationFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveCurrentChangesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.currentTranslationSettingsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateSupportedlanguagesdatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportIssuesToPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intlIDEWebsiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutIntlIDEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filesToolStripMenuItem,
            this.currentTranslationSettingsStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(696, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // filesToolStripMenuItem
            // 
            this.filesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openTranslationFileToolStripMenuItem,
            this.saveCurrentChangesToolStripMenuItem,
            this.exportAsPDFToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.filesToolStripMenuItem.Name = "filesToolStripMenuItem";
            this.filesToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.filesToolStripMenuItem.Text = "File";
            // 
            // openTranslationFileToolStripMenuItem
            // 
            this.openTranslationFileToolStripMenuItem.Name = "openTranslationFileToolStripMenuItem";
            this.openTranslationFileToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openTranslationFileToolStripMenuItem.Text = "Open Translation File";
            this.openTranslationFileToolStripMenuItem.Click += new System.EventHandler(this.openTranslationFileToolStripMenuItem_Click);
            // 
            // saveCurrentChangesToolStripMenuItem
            // 
            this.saveCurrentChangesToolStripMenuItem.Name = "saveCurrentChangesToolStripMenuItem";
            this.saveCurrentChangesToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveCurrentChangesToolStripMenuItem.Text = "Save Current Changes";
            // 
            // exportAsPDFToolStripMenuItem
            // 
            this.exportAsPDFToolStripMenuItem.Name = "exportAsPDFToolStripMenuItem";
            this.exportAsPDFToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exportAsPDFToolStripMenuItem.Text = "Export as PDF";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // currentTranslationSettingsStripMenuItem
            // 
            this.currentTranslationSettingsStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateSupportedlanguagesdatToolStripMenuItem,
            this.exportIssuesToPDFToolStripMenuItem});
            this.currentTranslationSettingsStripMenuItem.Name = "currentTranslationSettingsStripMenuItem";
            this.currentTranslationSettingsStripMenuItem.Size = new System.Drawing.Size(166, 20);
            this.currentTranslationSettingsStripMenuItem.Text = "Current Translation Settings";
            // 
            // updateSupportedlanguagesdatToolStripMenuItem
            // 
            this.updateSupportedlanguagesdatToolStripMenuItem.Name = "updateSupportedlanguagesdatToolStripMenuItem";
            this.updateSupportedlanguagesdatToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.updateSupportedlanguagesdatToolStripMenuItem.Text = "Manage avaliable languages";
            this.updateSupportedlanguagesdatToolStripMenuItem.Click += new System.EventHandler(this.updateSupportedlanguagesdatToolStripMenuItem_Click);
            // 
            // exportIssuesToPDFToolStripMenuItem
            // 
            this.exportIssuesToPDFToolStripMenuItem.Name = "exportIssuesToPDFToolStripMenuItem";
            this.exportIssuesToPDFToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.exportIssuesToPDFToolStripMenuItem.Text = "Export Issues to PDF";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intlIDEWebsiteToolStripMenuItem,
            this.aboutIntlIDEToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // intlIDEWebsiteToolStripMenuItem
            // 
            this.intlIDEWebsiteToolStripMenuItem.Name = "intlIDEWebsiteToolStripMenuItem";
            this.intlIDEWebsiteToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.intlIDEWebsiteToolStripMenuItem.Text = "Intl IDE Website";
            // 
            // aboutIntlIDEToolStripMenuItem
            // 
            this.aboutIntlIDEToolStripMenuItem.Name = "aboutIntlIDEToolStripMenuItem";
            this.aboutIntlIDEToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.aboutIntlIDEToolStripMenuItem.Text = "About Intl IDE";
            this.aboutIntlIDEToolStripMenuItem.Click += new System.EventHandler(this.aboutIntlIDEToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 59);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(345, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select the dialog to be worked with:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(370, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Or type the dialog number here and press enter:";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(373, 60);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(228, 20);
            this.textBox1.TabIndex = 4;
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 422);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainGUI";
            this.Text = "Intl IDE";
            this.Load += new System.EventHandler(this.MainGUI_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem filesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openTranslationFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveCurrentChangesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportAsPDFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutIntlIDEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem currentTranslationSettingsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateSupportedlanguagesdatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intlIDEWebsiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportIssuesToPDFToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
    }
}

