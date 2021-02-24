namespace ABI_POC_PCR
{
    partial class InfoDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InfoDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_OK_InfoDlg = new System.Windows.Forms.Button();
            this.btn_Cancle_InfoDlg = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(485, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "아래 사진과 같이 카트리지를 장착한 후 [확인] 버튼을 눌러주세요.";
            // 
            // btn_OK_InfoDlg
            // 
            this.btn_OK_InfoDlg.Location = new System.Drawing.Point(516, 14);
            this.btn_OK_InfoDlg.Name = "btn_OK_InfoDlg";
            this.btn_OK_InfoDlg.Size = new System.Drawing.Size(109, 35);
            this.btn_OK_InfoDlg.TabIndex = 2;
            this.btn_OK_InfoDlg.Text = "확인";
            this.btn_OK_InfoDlg.UseVisualStyleBackColor = true;
            this.btn_OK_InfoDlg.Click += new System.EventHandler(this.btn_OK_InfoDlg_Click);
            // 
            // btn_Cancle_InfoDlg
            // 
            this.btn_Cancle_InfoDlg.Location = new System.Drawing.Point(28, 42);
            this.btn_Cancle_InfoDlg.Name = "btn_Cancle_InfoDlg";
            this.btn_Cancle_InfoDlg.Size = new System.Drawing.Size(109, 35);
            this.btn_Cancle_InfoDlg.TabIndex = 3;
            this.btn_Cancle_InfoDlg.Text = "취소";
            this.btn_Cancle_InfoDlg.UseVisualStyleBackColor = true;
            this.btn_Cancle_InfoDlg.Visible = false;
            this.btn_Cancle_InfoDlg.Click += new System.EventHandler(this.btn_Cancle_InfoDlg_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(109, 132);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(444, 418);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // InfoDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(652, 634);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_Cancle_InfoDlg);
            this.Controls.Add(this.btn_OK_InfoDlg);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Gulim", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "InfoDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InfoDialog";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_OK_InfoDlg;
        private System.Windows.Forms.Button btn_Cancle_InfoDlg;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}