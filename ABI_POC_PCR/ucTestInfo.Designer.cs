namespace ABI_POC_PCR
{
    partial class ucTestInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucTestInfo));
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picBox_TestInfoNext = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_TestInfoNext)).BeginInit();
            this.SuspendLayout();
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(151, 556);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(199, 37);
            this.label29.TabIndex = 27;
            this.label29.Text = "* Tester Info.";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(556, 285);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(241, 37);
            this.label28.TabIndex = 26;
            this.label28.Text = "* Cartridge Info.";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(151, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(171, 37);
            this.label11.TabIndex = 25;
            this.label11.Text = "* Test Info.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(137, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(423, 55);
            this.label1.TabIndex = 28;
            this.label1.Text = "1. Test Information";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(20, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // picBox_TestInfoNext
            // 
            this.picBox_TestInfoNext.Image = ((System.Drawing.Image)(resources.GetObject("picBox_TestInfoNext.Image")));
            this.picBox_TestInfoNext.Location = new System.Drawing.Point(972, 712);
            this.picBox_TestInfoNext.Name = "picBox_TestInfoNext";
            this.picBox_TestInfoNext.Size = new System.Drawing.Size(72, 70);
            this.picBox_TestInfoNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_TestInfoNext.TabIndex = 29;
            this.picBox_TestInfoNext.TabStop = false;
            // 
            // ucTestInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.picBox_TestInfoNext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.pictureBox2);
            this.Name = "ucTestInfo";
            this.Size = new System.Drawing.Size(1080, 800);
            this.Load += new System.EventHandler(this.ucTestInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_TestInfoNext)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBox_TestInfoNext;
    }
}
