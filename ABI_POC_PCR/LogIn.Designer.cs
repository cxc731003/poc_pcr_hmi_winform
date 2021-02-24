namespace ABI_POC_PCR
{
    partial class LogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnLogin = new MetroFramework.Controls.MetroButton();
            this.tb_LoginID = new System.Windows.Forms.TextBox();
            this.tb_LoginPW = new System.Windows.Forms.TextBox();
            this.cb_Port_Main = new System.Windows.Forms.ComboBox();
            this.btn_Connect_Main = new MetroFramework.Controls.MetroButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(150, 223);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 1);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(150, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(150, 260);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(149, 317);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 1);
            this.panel2.TabIndex = 5;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ABI_POC_PCR.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(320, 446);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(157, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnLogin.Location = new System.Drawing.Point(190, 350);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(120, 50);
            this.btnLogin.TabIndex = 7;
            this.btnLogin.Text = "Sign In";
            this.btnLogin.UseSelectable = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tb_LoginID
            // 
            this.tb_LoginID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_LoginID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_LoginID.Location = new System.Drawing.Point(150, 200);
            this.tb_LoginID.Name = "tb_LoginID";
            this.tb_LoginID.Size = new System.Drawing.Size(199, 19);
            this.tb_LoginID.TabIndex = 8;
            // 
            // tb_LoginPW
            // 
            this.tb_LoginPW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_LoginPW.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_LoginPW.Location = new System.Drawing.Point(150, 295);
            this.tb_LoginPW.Name = "tb_LoginPW";
            this.tb_LoginPW.Size = new System.Drawing.Size(199, 19);
            this.tb_LoginPW.TabIndex = 9;
            // 
            // cb_Port_Main
            // 
            this.cb_Port_Main.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.cb_Port_Main.FormattingEnabled = true;
            this.cb_Port_Main.Location = new System.Drawing.Point(74, 468);
            this.cb_Port_Main.Name = "cb_Port_Main";
            this.cb_Port_Main.Size = new System.Drawing.Size(214, 33);
            this.cb_Port_Main.TabIndex = 10;
            this.cb_Port_Main.Visible = false;
            // 
            // btn_Connect_Main
            // 
            this.btn_Connect_Main.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btn_Connect_Main.Location = new System.Drawing.Point(56, 436);
            this.btn_Connect_Main.Name = "btn_Connect_Main";
            this.btn_Connect_Main.Size = new System.Drawing.Size(112, 48);
            this.btn_Connect_Main.TabIndex = 11;
            this.btn_Connect_Main.Text = "Connect";
            this.btn_Connect_Main.UseSelectable = true;
            this.btn_Connect_Main.Visible = false;
            this.btn_Connect_Main.Click += new System.EventHandler(this.btn_Connect_Main_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(140, 40);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(220, 72);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 500);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btn_Connect_Main);
            this.Controls.Add(this.cb_Port_Main);
            this.Controls.Add(this.tb_LoginPW);
            this.Controls.Add(this.tb_LoginID);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "LogIn";
            this.Load += new System.EventHandler(this.LogIn_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private MetroFramework.Controls.MetroButton btnLogin;
        private System.Windows.Forms.TextBox tb_LoginID;
        private System.Windows.Forms.TextBox tb_LoginPW;
        private System.Windows.Forms.ComboBox cb_Port_Main;
        private MetroFramework.Controls.MetroButton btn_Connect_Main;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}