using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABI_POC_PCR.SerialComm;

namespace ABI_POC_PCR
{
    public partial class LogIn : MetroFramework.Forms.MetroForm
    {
        SharedMemory sm = SharedMemory.GetInstance();
        

        bool isConnected = false;

        public LogIn()
        {
            InitializeComponent();                     
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            // combo_comList = 콤보 박스
            //COM Port 리스트 얻어 오기
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void Sign_In()
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");
            if (!di.Exists) di.Create();

            string fileName = di.ToString() + "\\member.info";

            string[] lines = File.ReadAllLines(fileName);

            int readNum = 1;
            string temp = "";
            for (int i = 1; i < lines.Length; i++) //데이터가 존재하는 라인일 때에만, label에 출력한다.
            {
                temp = lines[i]; // name, ID, PW, athority

                char[] sep = { ',' };

                string[] result = temp.Split(sep);
                //string[] data6 = new string[4] { temp, temp, temp, temp };
                int index = 0;
                //foreach (var item in result)
                //{
                //    result[index++] = item;
                //}
                if (result[1] == tb_LoginID.Text &&
                    result[2] == tb_LoginPW.Text)
                {
                    sm.userName = result[0];
                    sm.userID = tb_LoginID.Text;
                    sm.userPW = tb_LoginPW.Text;
                    sm.userAccessibility = result[3];
                    sm.isLoginSucceeded = true;

                    //if (tb_LoginID.Text == "ABI" && tb_LoginPW.Text == "5344")
                    //{
                    // 엔지니어 계정 로그인임 --> 계정정보에서도 관리 가능


                    this.Visible = false;
                    MainFrm dlg = new MainFrm();
                    dlg.Owner = this;
                    dlg.ShowDialog();
                }
                //dataGridView_Manage.Rows.Add(data6);
            }

            if (!sm.isLoginSucceeded)
            {
                //MessageBox("Login Failed, Check your ID and Password");
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Sign_In();
        }

        private void btn_Connect_Main_Click(object sender, EventArgs e)
        {
            // 컴포트 선택 후 연결 버튼 클릭하면 ID, PW 입력창이 활성화됨
            //showLog("장치와 연결 동작");

          
        }

        
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void tb_LoginID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Sign_In();
            }
        }

        private void tb_LoginPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Sign_In();
            }
        }
    }
}


/*
                    sm.userName =   
                    this.Visible = false;
                    //this.Close();
                    //Home dlg = new Home();
                    MainFrm dlg = new MainFrm();
                    dlg.Owner = this;
                    dlg.ShowDialog();
                    //dlg.Owner = this;
                    //Owner.Show();

                    //}

                    ////this.Visible = false;
                    ////Home dlg = new Home();
                    ////dlg.Owner = this;
                    //home.ShowDialog();
                    //this.Close();
 */
