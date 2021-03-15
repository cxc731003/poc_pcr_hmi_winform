namespace ABI_POC_PCR
{
    partial class ucTestStart
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnTestStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestStart
            // 
            this.btnTestStart.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTestStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTestStart.Location = new System.Drawing.Point(340, 280);
            this.btnTestStart.Name = "btnTestStart";
            this.btnTestStart.Size = new System.Drawing.Size(400, 240);
            this.btnTestStart.TabIndex = 25;
            this.btnTestStart.Text = "Test Start";
            this.btnTestStart.UseVisualStyleBackColor = false;
            // 
            // ucTestStart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btnTestStart);
            this.Name = "ucTestStart";
            this.Size = new System.Drawing.Size(1080, 800);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestStart;
    }
}
