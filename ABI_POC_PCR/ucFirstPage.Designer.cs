namespace ABI_POC_PCR
{
    partial class ucFirstPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucFirstPage));
            this.btnPreviousTest = new System.Windows.Forms.Button();
            this.btnNewTest = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPreviousTest
            // 
            this.btnPreviousTest.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPreviousTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreviousTest.Location = new System.Drawing.Point(590, 280);
            this.btnPreviousTest.Name = "btnPreviousTest";
            this.btnPreviousTest.Size = new System.Drawing.Size(400, 240);
            this.btnPreviousTest.TabIndex = 25;
            this.btnPreviousTest.Text = "Previous Test";
            this.btnPreviousTest.UseVisualStyleBackColor = false;
            //this.btnPreviousTest.Click += new System.EventHandler(this.btnPreviousTest_Click);
            // 
            // btnNewTest
            // 
            this.btnNewTest.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnNewTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewTest.Location = new System.Drawing.Point(90, 280);
            this.btnNewTest.Name = "btnNewTest";
            this.btnNewTest.Size = new System.Drawing.Size(400, 240);
            this.btnNewTest.TabIndex = 24;
            this.btnNewTest.Text = "New Test";
            this.btnNewTest.UseVisualStyleBackColor = false;
            //this.btnNewTest.Click += new System.EventHandler(this.btnNewTest_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(810, 700);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 26;
            this.pictureBox2.TabStop = false;
            // 
            // ucFirstScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Controls.Add(this.btnPreviousTest);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.btnNewTest);
            this.Name = "ucFirstScreen";
            this.Size = new System.Drawing.Size(1080, 800);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPreviousTest;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnNewTest;
    }
}
