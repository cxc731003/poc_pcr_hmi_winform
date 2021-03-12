namespace ABI_POC_PCR
{
    partial class UI_for_Tester
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
            this.panel_ui = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panel_TestInfo
            // 
            this.panel_ui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_ui.Location = new System.Drawing.Point(0, 0);
            this.panel_ui.Name = "panel_TestInfo";
            this.panel_ui.Size = new System.Drawing.Size(1080, 800);
            this.panel_ui.TabIndex = 24;
            this.panel_ui.Visible = false;
            // 
            // UI_for_Tester
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1080, 800);
            this.Controls.Add(this.panel_ui);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UI_for_Tester";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UI_for_Tester";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.UI_for_Tester_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel_ui;
    }
}