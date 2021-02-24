using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using System.IO;


//public class ProgressBarEx : ProgressBar { 
//    private SolidBrush brush = null; 
//    public ProgressBarEx() { 
//        this.SetStyle(ControlStyles.UserPaint, true); 
//    } 
//    protected override void OnPaint(PaintEventArgs e) { 
//        if (brush == null || brush.Color != this.ForeColor) 
//            brush = new SolidBrush(this.ForeColor); 
//        Rectangle rec = new Rectangle(0, 0, this.Width, this.Height); 
        
//        if (ProgressBarRenderer.IsSupported) 
//            ProgressBarRenderer.DrawHorizontalBar(e.Graphics, rec); 
//        rec.Width = (int)(rec.Width * ((double)Value / Maximum)) - 4; 
//        rec.Height = rec.Height - 4; 
//        e.Graphics.FillRectangle(brush, 2, 2, rec.Width, rec.Height); 
//    } 
//}

namespace ABI_POC_PCR
{
    public partial class Form1 : Form
    {
        int userMode = 0;
        int processStep = 0;

        InfoDialog aboutBox;
        PrintForm reportDlg;

        int selectedRowCount = 0;
        private object tb_deID_IDManage;

        bool updateProgresBar = false;
        int nProgressBar = 0;

        bool bLoadedRecipe = false; // 레시피를 읽었는가?

        string[] headerName = { "", "", "", "" };
        string[] chamberName = { "", "", "", "" };

        public Form1()
        {
            InitializeComponent();

            // 초기 컴포넌트 세팅
    
            // 그리드 해더 이름 읽어와서 설정
            setHeaderName();

            // 그리드 기본 값 설정
            presetDataGrid_Tester(dataGridView1_Tester, chamberName[0]);
            presetDataGrid_Tester(dataGridView2_Tester, chamberName[1]);
            presetDataGrid_Tester(dataGridView3_Tester, chamberName[2]);
            presetDataGrid_Tester(dataGridView4_Tester, chamberName[3]);

            presetDataGrid_Engineer(dataGridView1_Engineer, chamberName[0]);
            presetDataGrid_Engineer(dataGridView2_Engineer, chamberName[1]);
            presetDataGrid_Engineer(dataGridView3_Engineer, chamberName[2]);
            presetDataGrid_Engineer(dataGridView4_Engineer, chamberName[3]);

            // 진행바 칼라 설정
            progressBar_step.ForeColor = Color.FromArgb(255, 0, 0);
            progressBar_step.BackColor = Color.FromArgb(150, 0, 0);

            // 작업진행상황 초기화
            setProcessMode(0);

            // 유저모드 초기화
            setUserMode(3);

            //////////////////////////////////////////////////////////////////////////////////
            ///// 데이터그리드 업데이트 테스트
            ///

            // 데이터 그리드 각 열에 대하여 데이터 4개를 변경할 수 있음
            // 전달인자 : 1, 1, 4개 값 --> 챔버1, 1번열, 4개의 값
            setDataGrid_Tester(dataGridView1_Tester, 1, "1", "2", "3", "4");
            setDataGrid_Tester(dataGridView2_Tester, 2, "11", "22", "33", "44");
            setDataGrid_Tester(dataGridView3_Tester, 3, "111", "222", "333", "444");
            setDataGrid_Tester(dataGridView4_Tester, 4, "1111", "2222", "3333", "4444");

            // 데이터 그리드 각 열에 대하여 데이터 4개를 변경할 수 있음
            // 전달인자 : 1, 1, 4개 값 --> 챔버1, 1번열, 4개의 값
            setDataGrid_Engineer(dataGridView1_Engineer, 1, 1, "a1", "a2", "a3", "a4"); 
            setDataGrid_Engineer(dataGridView1_Engineer, 1, 2, "b1", "b2", "b3", "b4");
            setDataGrid_Engineer(dataGridView1_Engineer, 1, 3, "c1", "c2", "c3", "c4");
            setDataGrid_Engineer(dataGridView1_Engineer, 1, 4, "d1", "d2", "d3", "d4");
            setDataGrid_Engineer(dataGridView1_Engineer, 1, 5, "e1", "e2", "e3", "e4");
            setDataGrid_Engineer(dataGridView1_Engineer, 1, 6, "f1", "f2", "f3", "f4");
            setDataGrid_Engineer(dataGridView1_Engineer, 1, 7, "g1", "g2", "g3", "g4");
            setDataGrid_Engineer(dataGridView1_Engineer, 1, 8, "h1", "h2", "h3", "h4");

            // 데이터 그리드 각 열에 대하여 데이터 4개를 변경할 수 있음
            // 전달인자 : 1, 1, 4개 값 --> 챔버1, 1번열, 4개의 값
            setDataGrid_Engineer(dataGridView2_Engineer, 1, 1, "a1", "a2", "a3", "a4");
            setDataGrid_Engineer(dataGridView2_Engineer, 1, 2, "b1", "b2", "b3", "b4");
            setDataGrid_Engineer(dataGridView3_Engineer, 1, 3, "c1", "c2", "c3", "c4");
            setDataGrid_Engineer(dataGridView3_Engineer, 1, 4, "d1", "d2", "d3", "d4");
            setDataGrid_Engineer(dataGridView4_Engineer, 1, 5, "e1", "e2", "e3", "e4");
            setDataGrid_Engineer(dataGridView4_Engineer, 1, 6, "f1", "f2", "f3", "f4");
            setDataGrid_Engineer(dataGridView2_Engineer, 1, 7, "g1", "g2", "g3", "g4");
            setDataGrid_Engineer(dataGridView3_Engineer, 1, 8, "h1", "h2", "h3", "h4");


        }
        private void setDataGrid_Engineer(DataGridView dgv, int chamberIndex, int columindex, string data1, string data2, string data3, string data4)
        {
            // chamberIndex : 1~4
            // columindex : base~final (1~8)

            // 기존 그리드 값을 읽어온 후 값을 업데이트 하고 다시 그리드 값을 설정하자
            //string[] chamberName = { "chamber1", "chamber2", "chamber3", "chamber4" };

            string[] d1 = new string[10] { chamberName[chamberIndex - 1], headerName[0], "0", "0", "0", "0", "0", "0", "0", "0" };
            string[] d2 = new string[10] { chamberName[chamberIndex - 1], headerName[1], "0", "0", "0", "0", "0", "0", "0", "0" };
            string[] d3 = new string[10] { chamberName[chamberIndex - 1], headerName[2], "0", "0", "0", "0", "0", "0", "0", "0" };
            string[] d4 = new string[10] { chamberName[chamberIndex - 1], headerName[3], "0", "0", "0", "0", "0", "0", "0", "0" };

            // 데이터 가져오기
            int rowNo = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                rowNo++;
                if (!row.IsNewRow)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        if (rowNo == 1) d1[i] = row.Cells[i].Value.ToString();
                        if (rowNo == 2) d2[i] = row.Cells[i].Value.ToString();
                        if (rowNo == 3) d3[i] = row.Cells[i].Value.ToString();
                        if (rowNo == 4) d4[i] = row.Cells[i].Value.ToString();
                    }
                }
            }
            
            // 데이터 업데이트
            d1[columindex + 1] = data1;
            d2[columindex + 1] = data2;
            d3[columindex + 1] = data3;
            d4[columindex + 1] = data4;
            
            // 새로운 데이터는 추가
            dgv.Rows.Add(d1);
            dgv.Rows.Add(d2);
            dgv.Rows.Add(d3);
            dgv.Rows.Add(d4);

            // 기존 데이터는 삭제
            dgv.Rows.RemoveAt(0);
            dgv.Rows.RemoveAt(0);
            dgv.Rows.RemoveAt(0);
            dgv.Rows.RemoveAt(0);


            // 그리드뷰를 설정
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (i % 2 != 0)
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
                }
            }
        }

        private void setDataGrid_Engineer2(DataGridView dgv, string chName, int index, string data1, string data2, string data3, string data4, string data5, string data6, string data7, string data8)
        {
            // 현재 줄을 지움
            dgv.Rows.RemoveAt(0);

            string[] data_1 = new string[10] { chName, headerName[index], data1, data2, data3, data4, data5, data6, data7, data8 };

            dgv.Rows.Add(data_1);

            // 그리드뷰를 설정
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (i % 2 != 0)
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
                }
            }
        }


        private void presetDataGrid_Engineer(DataGridView dgv, string value)
        {
            string[] data2 = new string[10] { value, headerName[0], "-", "-", "-", "-", "-", "-", "-", "-" };
            string[] data3 = new string[10] { value, headerName[1], "-", "-", "-", "-", "-", "-", "-", "-" };
            string[] data4 = new string[10] { value, headerName[2], "-", "-", "-", "-", "-", "-", "-", "-" };
            string[] data5 = new string[10] { value, headerName[3], "-", "-", "-", "-", "-", "-", "-", "-" };

            dgv.Rows.Add(data2);
            dgv.Rows.Add(data3);
            dgv.Rows.Add(data4);
            dgv.Rows.Add(data5);

            dgv.Font = new Font("문체부 제목 돋음체", 18, FontStyle.Regular);
            dgv.DefaultCellStyle.Font = new Font("문체부 제목 돋음체", 18, FontStyle.Bold);

            // 그리드뷰를 설정
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                if (i % 2 != 0)
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dgv.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
                }
            }
        }
        private void setDataGrid_Tester(DataGridView dgv, int chamberIndex, string data1, string data2, string data3, string data4)
        {
            // 현재 줄을 지움
            dgv.Rows.RemoveAt(0);

           // string[] chamberName = { "chamber1", "chamber2", "chamber3", "chamber4" };

            // 다시 업데이트
            string[] data = new string[5] { chamberName[chamberIndex - 1], data1, data2, data3, data4 };

            dgv.Rows.Add(data);
            dgv.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
        }

        private void presetDataGrid_Tester(DataGridView dgv, string value)
        {
            string[] data1 = new string[5] { value, "-", "-", "-", "-" };

            dgv.Rows.Add(data1);

            dgv.Font = new Font("문체부 제목 돋음체", 28, FontStyle.Regular);
            dgv.DefaultCellStyle.Font = new Font("문체부 제목 돋음체", 28, FontStyle.Bold);

            dgv.CurrentCell = null;

            dgv.Rows[0].DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
        }

        private void setHeaderName()
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");
            if (!di.Exists) di.Create();

            string fileName = di.ToString() + "\\header.info";

            string[] lines = File.ReadAllLines(fileName);

            string temp2 = "", temp0 = "", temp1 = "";
            temp0 = lines[1]; // 검사자용
            temp1 = lines[2]; // 관리자용
            temp2 = lines[0]; // 챔버이름


            char[] sep = { ',' };

            string[] result2 = temp2.Split(sep);
            chamberName[0] = result2[0];
            chamberName[1] = result2[1];
            chamberName[2] = result2[2];
            chamberName[3] = result2[3];

            string[] result0 = temp0.Split(sep);
            dataGridView1_Tester.Columns[0].HeaderText = result0[0];
            dataGridView1_Tester.Columns[1].HeaderText = result0[1];
            dataGridView1_Tester.Columns[2].HeaderText = result0[2];
            dataGridView1_Tester.Columns[3].HeaderText = result0[3];
            dataGridView1_Tester.Columns[4].HeaderText = result0[4];

            dataGridView2_Tester.Columns[0].HeaderText = result0[0];
            dataGridView2_Tester.Columns[1].HeaderText = result0[1];
            dataGridView2_Tester.Columns[2].HeaderText = result0[2];
            dataGridView2_Tester.Columns[3].HeaderText = result0[3];
            dataGridView2_Tester.Columns[4].HeaderText = result0[4];

            dataGridView3_Tester.Columns[0].HeaderText = result0[0];
            dataGridView3_Tester.Columns[1].HeaderText = result0[1];
            dataGridView3_Tester.Columns[2].HeaderText = result0[2];
            dataGridView3_Tester.Columns[3].HeaderText = result0[3];
            dataGridView3_Tester.Columns[4].HeaderText = result0[4];

            dataGridView4_Tester.Columns[0].HeaderText = result0[0];
            dataGridView4_Tester.Columns[1].HeaderText = result0[1];
            dataGridView4_Tester.Columns[2].HeaderText = result0[2];
            dataGridView4_Tester.Columns[3].HeaderText = result0[3];
            dataGridView4_Tester.Columns[4].HeaderText = result0[4];

            headerName[0] = result0[1];
            headerName[1] = result0[2];
            headerName[2] = result0[3];
            headerName[3] = result0[4];


            string[] result1 = temp1.Split(sep);
            dataGridView1_Engineer.Columns[0].HeaderText = result1[0];
            dataGridView1_Engineer.Columns[1].HeaderText = result1[1];
            dataGridView1_Engineer.Columns[2].HeaderText = result1[2];
            dataGridView1_Engineer.Columns[3].HeaderText = result1[3];
            dataGridView1_Engineer.Columns[4].HeaderText = result1[4];
            dataGridView1_Engineer.Columns[5].HeaderText = result1[5];
            dataGridView1_Engineer.Columns[6].HeaderText = result1[6];
            dataGridView1_Engineer.Columns[7].HeaderText = result1[7];
            dataGridView1_Engineer.Columns[8].HeaderText = result1[8];
            dataGridView1_Engineer.Columns[9].HeaderText = result1[9];

            dataGridView2_Engineer.Columns[0].HeaderText = result1[0];
            dataGridView2_Engineer.Columns[1].HeaderText = result1[1];
            dataGridView2_Engineer.Columns[2].HeaderText = result1[2];
            dataGridView2_Engineer.Columns[3].HeaderText = result1[3];
            dataGridView2_Engineer.Columns[4].HeaderText = result1[4];
            dataGridView2_Engineer.Columns[5].HeaderText = result1[5];
            dataGridView2_Engineer.Columns[6].HeaderText = result1[6];
            dataGridView2_Engineer.Columns[7].HeaderText = result1[7];
            dataGridView2_Engineer.Columns[8].HeaderText = result1[8];
            dataGridView2_Engineer.Columns[9].HeaderText = result1[9];

            dataGridView3_Engineer.Columns[0].HeaderText = result1[0];
            dataGridView3_Engineer.Columns[1].HeaderText = result1[1];
            dataGridView3_Engineer.Columns[2].HeaderText = result1[2];
            dataGridView3_Engineer.Columns[3].HeaderText = result1[3];
            dataGridView3_Engineer.Columns[4].HeaderText = result1[4];
            dataGridView3_Engineer.Columns[5].HeaderText = result1[5];
            dataGridView3_Engineer.Columns[6].HeaderText = result1[6];
            dataGridView3_Engineer.Columns[7].HeaderText = result1[7];
            dataGridView3_Engineer.Columns[8].HeaderText = result1[8];
            dataGridView3_Engineer.Columns[9].HeaderText = result1[9];

            dataGridView4_Engineer.Columns[0].HeaderText = result1[0];
            dataGridView4_Engineer.Columns[1].HeaderText = result1[1];
            dataGridView4_Engineer.Columns[2].HeaderText = result1[2];
            dataGridView4_Engineer.Columns[3].HeaderText = result1[3];
            dataGridView4_Engineer.Columns[4].HeaderText = result1[4];
            dataGridView4_Engineer.Columns[5].HeaderText = result1[5];
            dataGridView4_Engineer.Columns[6].HeaderText = result1[6];
            dataGridView4_Engineer.Columns[7].HeaderText = result1[7];
            dataGridView4_Engineer.Columns[8].HeaderText = result1[8];
            dataGridView4_Engineer.Columns[9].HeaderText = result1[9];
        }
        private void setUserMode(int um)
        {
            userMode = um;

            if (userMode != 0) btn_Login_Main.Text = "LOG OUT";

            // 검사자이면 검사탭으로 이동
            if (userMode == 0)
            {
                tabControl1.SelectedIndex = 0;
                tb_WorkerID_Test.Text = "";
                tb_WorkerName_Test.Text = "";
            }
            if (userMode == 1)
            {
                tabControl1.SelectedIndex = 1;
            }
            // 관리자이면 관리자탬으로 이동
            else if (userMode == 2)
            {
                tabControl1.SelectedIndex = 2;
            }
            // 엔지니어면 엔지니어탭으로 이동
            else if (userMode == 3)
            {
                tabControl1.SelectedIndex = 3;
            }

            //tb_PW_Main.Text = "";
        }

        private void setProcessMode(int pm)
        {
            switch (pm)
            {
                case 0:  // 검사 초기화
                    processStep = 0;
                    progressBar_step.Value = 0 / 8;
                    tb_PatientID_Test.Text = "";
                    tb_CartridgeID_Test.Text = "";
                    tb_SampleID_Test.Text = "";
                    break;
                case 1:
                    processStep = 1;
                    progressBar_step.Value = 100 / 8;
                    break;
                case 2:
                    processStep = 2;
                    progressBar_step.Value = 200 / 8;
                    break;
                case 3:
                    processStep = 3;
                    progressBar_step.Value = 300 / 8;
                    break;
                case 4:
                    processStep = 4;
                    progressBar_step.Value = 400 / 8;
                    break;
                case 5:
                    processStep = 5;
                    progressBar_step.Value = 500 / 8;
                    break;
                case 6:
                    processStep = 6;
                    progressBar_step.Value = 600 / 8;
                    break;
                case 7:
                    processStep = 7;
                    progressBar_step.Value = 700 / 8;
                    break;
                case 8:
                    processStep = 8;
                    progressBar_step.Value = 800 / 8;
                    break;
                case 9:
                    processStep = 9;
                    progressBar_step.Value = 800 / 8;
                    break;
            }

            //MessageBox.Show(pm.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            // combo_comList = 콤보 박스
            //COM Port 리스트 얻어 오기
            string[] comlist = System.IO.Ports.SerialPort.GetPortNames();

            //COM Port가 있는 경우에만 콤보 박스에 추가.
            if (comlist.Length > 0)
            {
                cb_Port_Main.Items.AddRange(comlist);
                //제일 처음에 위치한 녀석을 선택
                cb_Port_Main.SelectedIndex = 0;
            }

            aboutBox = new InfoDialog();
            reportDlg = new PrintForm();

            //제일 처음에 위치한 녀석을 선택
            tb_Right_IDManage.SelectedIndex = 0;

            // 레시피 파일을 검색해서 리스트를 채움
            SetRecipeCombobox_Test();

            // 라벨 투명하게 설정
            lb_Setting.BackColor = Color.Transparent;
            lb_Setting.Parent = progressBar_step;


            // 계정정보 읽기
            btn_Search_IDManage_Click(this, null);
        }

        private void SetRecipeCombobox_Test()
        {
            cb_Recipe_Eng.Items.Clear();
            cb_Recipe_Test.Items.Clear();

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");
            
            foreach (System.IO.FileInfo File in di.GetFiles())
            {
                if (File.Extension.ToLower().CompareTo(".rcp") == 0)
                {
                    String FileNameOnly = File.Name.Substring(0, File.Name.Length - 4);
                    String FullFileName = File.FullName;

                    //MessageBox.Show(FullFileName + " " + FileNameOnly);
                    cb_Recipe_Eng.Items.Add(FileNameOnly);
                    cb_Recipe_Test.Items.Add(FileNameOnly);
                }
            }
        }

        private void btn_Connect_Main_Click(object sender, EventArgs e)
        {
            // 컴포트 선택 후 연결 버튼 클릭하면 ID, PW 입력창이 활성화됨

            //컴포트 연결시도
            bool flag = true;
            
            //연결에 성공하면
            if (flag)
            {
                tb_ID_Main.Enabled = true;
                tb_PW_Main.Enabled = true;
                btn_Login_Main.Enabled = true;
            }
        }

        private void btn_Login_Main_Click(object sender, EventArgs e)
        {
            if (tb_ID_Main.Text == "ABI" && tb_PW_Main.Text == "5344")
            {
                // 엔지니어 계정 로그인임 --> 계정정보에서도 관리 가능
                setUserMode(3);

                tb_WorkerID_Test.Text = "ABI";
                tb_WorkerName_Test.Text = "ABI엔지니어";

                return;
            }
            if (btn_Login_Main.Text == "LOG OUT")
            {
                setUserMode(0);
                btn_Login_Main.Text = "LOGIN";
                MessageBox.Show("로그아웃 했습니다.", "로그아웃 안내", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tabControl1.SelectedIndex = 0;
                return;
            }
            // 로그인 계정을 체크
            string userRight = "NOT";

            // 계정에서 로그인한 계정 유무를 확인함
            // 데이터 비교
            foreach (DataGridViewRow row in dataGridView_Manage.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int i = 0; i < dataGridView_Manage.Columns.Count; i++)
                    {
                        if (tb_ID_Main.Text == row.Cells[1].Value.ToString() // ID
                            && tb_PW_Main.Text == row.Cells[2].Value.ToString()) // PW
                        {
                            userRight = row.Cells[3].Value.ToString();
                            tb_WorkerID_Test.Text = tb_ID_Main.Text;
                            tb_WorkerName_Test.Text = row.Cells[0].Value.ToString();
                        }
                    }
                }
            }
            
            switch (userRight)
            {
                case "검사자":
                    //MessageBox.Show("검사자 계정으로 로그인 했습니다.", "로그인 안내", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    setUserMode(1);
                    break;
                case "관리자":
                    //MessageBox.Show("관리자 계정으로 로그인 했습니다.", "로그인 안내", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    setUserMode(2);
                    break;
                case "엔지니어":
                    //MessageBox.Show("엔지니어 계정으로 로그인 했습니다.", "로그인 안내", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    setUserMode(3);
                    break;
                case "NOT":
                    MessageBox.Show("계정 정보 또는 비밀번호가 틀립니다. 관리자에게 문의 바랍니다.", "로그인 안내", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    setUserMode(0);
                    break;
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            // 탭의 이동을 원할 경우 권한을 체크함
            if (userMode == 0)
            {
                tabControl1.SelectedIndex = 0;
            }
            else if (userMode == 1)
            {
                if (tabControl1.SelectedIndex == 3 || tabControl1.SelectedIndex == 2)
                {
                    tabControl1.SelectedIndex = 1;
                }
            }
            else if (userMode == 2)
            {
                if (tabControl1.SelectedIndex == 3)
                {
                    tabControl1.SelectedIndex = 2;
                }
            }

            btn_Search_IDManage_Click(this, null);
        }

        private void tabControl4_Selected(object sender, TabControlEventArgs e)
        {
            // 탭의 이동을 원할 경우 권한을 체크함
            if (userMode == 1)
            {
                    tabControl4.SelectedIndex = 0;   // 권한이 없는 검사자는 관리자탭으로 이동 불가
            }
            if (processStep == 3) // 검사를 시작한 경우라면 관리자도 탭을 이동할 수 없음
            {
                // 관리자가 현재 보고 있는 탭을 체크하여 그대로 유지하여야 함
                // todo
            }
        }

        private void btn_OpenDoor_Test_Click(object sender, EventArgs e)
        {
            // MCU에 문을 열라고 명령함
            // todo

            // 문의 락이 풀리면
            if (MessageBox.Show("문 상단을 눌러 열어 주세요.", "검사 안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {// 예 클릭
                
                setProcessMode(1);

                if (MessageBox.Show("샘플 및 카트리지 바코드를 등록해 주세요.", "검사 안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    setProcessMode(2);
                    // 샘플 ID와 카트리지 ID 입력 가능 상태로 전환 --> 포커스를 옮김
                    MessageBox.Show("환자 ID, 샘플 ID 및 카트리지 ID 입력 후 검사설정을 해 주세요.", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tb_SampleID_Test.Focus();
                    setProcessMode(3);
                }
                else   // 취소
                {
                    //처음으로 돌아감
                    MessageBox.Show("작업 취소로 문을 닫습니다.", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    setProcessMode(0);
                }

            }
            else
            { // 취소 클릭
                  //처음으로 돌아감
                MessageBox.Show("작업 취소로 문을 닫습니다", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                setProcessMode(0);
            }
            /*
             AbortRetryIgnore : 중단, 다시시도, 무시 버튼 표시
        OK : 확인 버튼 표시 
        OKCancel : 확인, 취소 버튼 표시 
        RetryCancel : 다시 시도, 취소 버튼 표시 
        YesNo : 예, 아니요 버튼 표시 
        YesNoCancel : 예, 아니요, 취소 버튼 표시             

        Asterisk : 정보 아이콘 
        Error : 빨간색 원 안 X 표시 
        Exclamation : 경고 아이콘 
        Hand : 손바닥 아이콘 
        Information : 정보 아이콘
        None : 아이콘을 표시하지 않음 
        Question : 물음표 아이콘 
        Stop : 빨간색 원 안 X 표시 
        Warning : 경고 아이콘
             */

        }

        private void btn_SetRecipe_Test_Click(object sender, EventArgs e)
        {
            if (cb_Recipe_Test.SelectedIndex == -1)
            {
                MessageBox.Show("검사 항목을 선택 후 확인을 눌러주세요.", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            else
            {
                if (DialogResult.OK == MessageBox.Show("카트리지 커버 및 캡을 제거해 주세요.", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Information))
                {
                    setProcessMode(5);

                    aboutBox.ShowDialog();

                    if (aboutBox.retBtn == 1)
                    {
                        // 확인 --> 계속 진행
                        setProcessMode(6);

                        if (DialogResult.OK == MessageBox.Show("팁을 장착해 주세요.", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Information))
                        {
                            setProcessMode(7);

                            if (DialogResult.OK == MessageBox.Show("준비가 끝났습니다. 시작을 눌러 검사를 진행해 주세요.", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Information))
                            {
                                setProcessMode(8);

                            }

                        }
                    }
                    else
                    {
                        // 취소 --> 작업 취소
                        MessageBox.Show("검사 취소함", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setProcessMode(0);
                    }

                }
            }
        }

        private void btn_Start_Test_Click(object sender, EventArgs e)
        {
            if (processStep == 8)  // ID input complete
            {
                MessageBox.Show("검사를 시작합니다.", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btn_Start_Test.Text = "강제 종료";
                setProcessMode(9);

                // update 진행바
                updateProgresBar = true; 
            }
            else if (processStep == 9)
            {
                if (DialogResult.OK == MessageBox.Show("검사가 진행 중입니다. 검사를 멈추겠습니까?", "검사 안내", 
                                                       MessageBoxButtons.OKCancel, MessageBoxIcon.Information))

                {
                    btn_Start_Test.Text = "검사 시작";
                    setProcessMode(0);

                    // update 진행바
                    updateProgresBar = false;

                    MessageBox.Show("검사를 강제 종료하였습니다.", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else 
            {
                MessageBox.Show("검사 준비가 되지 않았습니다.", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void tb_PatientID_Test_TextChanged(object sender, EventArgs e)
        {
            if (tb_PatientID_Test.Text != "" && tb_CartridgeID_Test.Text != "" && tb_SampleID_Test.Text != "" )
            {
                //MessageBox.Show("다음으로 진행함", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setProcessMode(4);
            }
        }

        private void tb_SampleID_Test_TextChanged(object sender, EventArgs e)
        {
            if (tb_PatientID_Test.Text != "" && tb_CartridgeID_Test.Text != "" && tb_SampleID_Test.Text != "")
            {
                //MessageBox.Show("다음으로 진행함", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setProcessMode(4);
            }
        }

        private void tb_CartridgeID_Test_TextChanged(object sender, EventArgs e)
        {
            if (tb_PatientID_Test.Text != "" && tb_CartridgeID_Test.Text != "" && tb_SampleID_Test.Text != "")
            {
                //MessageBox.Show("다음으로 진행함", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setProcessMode(4);
            }
        }

        private void btn_About_Click(object sender, EventArgs e)
        {
            aboutBox.ShowDialog();
            if (aboutBox.retBtn == 1)
            {
                // 확인 --> 계속 진행
                MessageBox.Show("다음으로 진행함", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // 취소 --> 작업 취소
                MessageBox.Show("검사 취소함", "검사 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            dataGridView1_Engineer.CurrentCell = null;
            dataGridView2_Engineer.CurrentCell = null;
            dataGridView3_Engineer.CurrentCell = null;
            dataGridView4_Engineer.CurrentCell = null;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string cTime = DateTime.Now.ToLongTimeString();
            string cDate = DateTime.Now.ToLongDateString();
            this.Text = "ABI POC PCR ver. 2.0.0                                                                                                                                                                                     "+ cDate + " | " + cTime;

            if (updateProgresBar)
            {
                // 테스트용, 상태바를 1초마다 업데이트
                progressBar_Tester.Value = progressBar_Manager.Value = nProgressBar++ % 50 * 2; 
            }

            //progressBar_step.Value = progressBar_Manager.Value = nProgressBar++ % 6 * 20;
        }

        private void progressBar_Tester_Click(object sender, EventArgs e)
        {

        }

        private void btn_Regist_IDManage_Click(object sender, EventArgs e)
        {
            // 등록할 내용이 없으면 리턴
            if (tb_Name_IDManage.Text == "" || tb_ID_IDManage.Text == "" || tb_PW_IDManage.Text == "")
            {
                MessageBox.Show("성명, ID, Password 모두 입력하세요.", "계정 등록 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 신규 계정 등록
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");
            if (!di.Exists) {
                di.Create(); 
            }
            string fileName = di.ToString() + "\\member.info";

            StreamWriter sw = new StreamWriter(fileName, true);

            string buff = tb_Name_IDManage.Text + "," + tb_ID_IDManage.Text + "," + tb_PW_IDManage.Text + "," + tb_Right_IDManage.SelectedItem;

            sw.WriteLine(buff);
            
            sw.Close();

            MessageBox.Show("계정이 등록되었습니다.", "계정 등록 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btn_Search_IDManage_Click(this, null);

            tb_Name_IDManage.Text = "";
            tb_ID_IDManage.Text = "";
            tb_PW_IDManage.Text = "";
        }

        private void btn_Remove_IDManage_Click(object sender, EventArgs e)
        {
            if (tb_delName_IDManage.Text == "ABI엔지니어") // 관리자 계정 삭제 불가
            {
                MessageBox.Show("엔지니어 계정은 삭제할 수 없습니다.", "계정 삭제 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
            }
            else if (tb_delPW_IDManage.Text == "")
            {
                MessageBox.Show("삭제할 계정을 선택 후 암호를 입력해야 삭제할 수 있습니다.", "계정 삭제 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (tb_delPW_IDManage.Text != tb_delPW2_IDManage.Text) { 
                MessageBox.Show("암호가 일치해야 삭제할 수 있습니다.", "계정 삭제 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");
                
                string fileName = di.ToString() + "\\member.info";
                Save_Csv(fileName, dataGridView_Manage, true);

                tb_delName_IDManage.Text = "";
                tb_delID_IDManage.Text = "";
                tb_delPW_IDManage.Text = "";
                tb_delPW2_IDManage.Text = "";
            }
        }

        private void btn_Search_IDManage_Click(object sender, EventArgs e)
        {
            // 계정 조회
            dataGridView_Manage.Rows.Clear();

            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");
            if (!di.Exists)  di.Create();
            
            string fileName = di.ToString() + "\\member.info";

            string[] lines = File.ReadAllLines(fileName);

            int readNum = 1;
            string temp = "";
            for (int i = 1; i < lines.Length; i++) //데이터가 존재하는 라인일 때에만, label에 출력한다.
            {
                temp = lines[i];

                char[] sep = { ','};

                string[] result = temp.Split(sep);
                string[] data6 = new string[4] { temp, temp, temp, temp };
                int index = 0;
                foreach (var item in result)
                {
                    data6[index++] = item;
                }

                dataGridView_Manage.Rows.Add(data6);
            }
            
            for (int i = 0; i < dataGridView_Manage.Rows.Count; i++)
            {
                if (i % 2 != 0)
                {
                    dataGridView_Manage.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                else
                {
                    dataGridView_Manage.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240);
                }
            }
        }

        private void dataGridView_Manage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // 선택한 셀의 정보를 채움
            if (e.RowIndex == 0 && dataGridView_Manage.RowCount==1 || dataGridView_Manage.Rows.Count== (e.RowIndex+1)) 
                return;
            tb_delName_IDManage.Text = dataGridView_Manage.Rows[e.RowIndex].Cells[0].Value.ToString();
            tb_delID_IDManage.Text = dataGridView_Manage.Rows[e.RowIndex].Cells[1].Value.ToString();
            tb_delPW2_IDManage.Text = dataGridView_Manage.Rows[e.RowIndex].Cells[2].Value.ToString();

            selectedRowCount = e.RowIndex;
           // int selectedCount = dataGridView_Manage.SelectedRows.Count;

            //// 현재 선택한 셀의 정보를 삭제 후
            //foreach (DataGridViewRow dgr in dataGridView_Manage.SelectedRows)
            //{
            //    dataGridView_Manage.Rows.Remove(dgr);
            //}
        }


        /// <summary>
        /// 계정을 1개 삭제 후 dataGridView 데이터를 파일 내보내기
        /// </summary>
        private void Save_Csv(string fileName, DataGridView dgv, bool header)
        {
            // 현재 선택한 셀의 정보를 삭제 후
            //dataGridView_Manage.Rows.RemoveAt(this.dataGridView_Manage.SelectedRows[0].Index);
            int sIndex = dataGridView_Manage.CurrentCell.RowIndex;

            dataGridView_Manage.Rows.RemoveAt(sIndex);
            


            // 그리드뷰를 파일로 저장함
            string delimiter = ",";  // 구분자
            FileStream fs = new FileStream(fileName, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter csvExport = new StreamWriter(fs, System.Text.Encoding.UTF8);

            if (dgv.Rows.Count == 0) return;

            // 헤더정보 출력
            if (header)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    csvExport.Write(dgv.Columns[i].HeaderText);
                    if (i != dgv.Columns.Count - 1)
                    {
                        csvExport.Write(delimiter);
                    }
                }
            }

            csvExport.Write(csvExport.NewLine); // add new line

            // 데이터 출력
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    for (int i = 0; i < dgv.Columns.Count; i++)
                    {
                        csvExport.Write(row.Cells[i].Value);
                        if (i != dgv.Columns.Count - 1)
                        {
                            csvExport.Write(delimiter);
                        }
                    }
                    csvExport.Write(csvExport.NewLine); // write new line
                }
            }

            csvExport.Flush(); // flush from the buffers.
            csvExport.Close();
            fs.Close();
            MessageBox.Show("계정을 삭제하였습니다.", "계정 삭제 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btn_NewRecipe_Eng_Click(object sender, EventArgs e)
        {
            // 새로운 레시피를 만들고 싶으면 레시피 콤보박스에 이름을 넣은 후 클릭
            // 레시피 이름 입력 체크
            int index = cb_Recipe_Eng.SelectedIndex;    // -1 이면 입력한 것이 없음
            string str = cb_Recipe_Eng.Text;
            
            if (index == -1 && str != "")
            {
                MessageBox.Show("새로운 레시피 파일을 생성했습니다. 설정값을 저장해 주세요.", "레시피 생성 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // 새로운 레시피 파일 저장
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");
                if (!di.Exists)
                {
                    di.Create();
                }
                string fileName = di.ToString() + "\\" + str + ".rcp";

                // 기존 파일 삭제
                FileInfo fileDel = new FileInfo(fileName);
                if (fileDel.Exists) fileDel.Delete(); // 없어도 에러안남

                // 새로 저장
                StreamWriter sw = new StreamWriter(fileName, true);

                string buff = tb_PreTemp_Eng.Text + "," + tb_PreHoldSec_Eng.Text + "," + tb_1Temp_Eng.Text + "," + tb_1HoldSec_Eng.Text
                     + "," + tb_2Temp_Eng.Text + "," + tb_2HoldSec_Eng.Text + "," + tb_OCDelaySec_Eng.Text + "," + tb_OCHoldSec_Eng.Text
                     + "," + tb_FianlCycle_Eng.Text;

                sw.WriteLine(buff);

                sw.Close();
                // 콤보 박스 업데이트
                SetRecipeCombobox_Test();
            }
            else if (index == -1 || str == "")
            {
                MessageBox.Show("레시피 이름을 입력한 후 생성해 주세요.", "레시피 생성 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("기존에 존재하는 레시피 이름인지 확인해 주세요.", "레시피 생성 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_DelRecipe_Eng_Click(object sender, EventArgs e)
        {
            int index = cb_Recipe_Eng.SelectedIndex;    // -1 이면 입력한 것이 없음
            if (index == -1) return;

            string str = cb_Recipe_Eng.Text;
            // 현재 레시피 파일을 찾은 후 삭제
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");
            if (!di.Exists)
            {
                di.Create();
            }
            string fileName = di.ToString() + "\\" + str + ".rcp";

            FileInfo fileDel = new FileInfo(fileName);
            if (fileDel.Exists) // 삭제할 파일이 있는지
            {
                if (DialogResult.OK == MessageBox.Show("레시피를 삭제하겠습니까?", "레시피 삭제 안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)){
                    fileDel.Delete(); // 없어도 에러안남
                    
                    // 콤보 박스 업데이트
                    SetRecipeCombobox_Test();
                    cb_Recipe_Eng.SelectedIndex = 0;

                    MessageBox.Show("레시피를 삭제하였습니다.", "레시피 삭제 안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                }
            }
        }

        private void btn_SaveRecipe_Eng_Click(object sender, EventArgs e)
        {
            // 설정값을 현재 레시피에 저장
            int index = cb_Recipe_Eng.SelectedIndex;    // -1 이면 입력한 것이 없음
            if (index == -1) return;

            string str = cb_Recipe_Eng.Text;

        
            // 새로운 레시피 파일 저장
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");
            if (!di.Exists) di.Create();

            string fileName = di.ToString() + "\\" + str + ".rcp";

            // 기존 파일 삭제
            FileInfo fileDel = new FileInfo(fileName);
            if (fileDel.Exists) fileDel.Delete(); // 없어도 에러안남

            // 새로 저장
            StreamWriter sw = new StreamWriter(fileName, true);

            string buff = tb_PreTemp_Eng.Text + "," + tb_PreHoldSec_Eng.Text + "," + tb_1Temp_Eng.Text + "," + tb_1HoldSec_Eng.Text
                    + "," + tb_2Temp_Eng.Text + "," + tb_2HoldSec_Eng.Text + "," + tb_OCDelaySec_Eng.Text + "," + tb_OCHoldSec_Eng.Text
                    + "," + tb_FianlCycle_Eng.Text;

            sw.WriteLine(buff);

            sw.Close();
            // 콤보 박스 업데이트
            SetRecipeCombobox_Test();

            MessageBox.Show("레시피를 저장하였습니다.", "레시피 저장 안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void btn_LoadRecipe_Eng_Click(object sender, EventArgs e)
        {
            // 선택한 레시피를 불러옴
            int index = cb_Recipe_Eng.SelectedIndex;    // -1 이면 입력한 것이 없음
            if (index == -1)
            {
                MessageBox.Show("레시피를 선택해 주세요.", "레시피 읽기 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            bLoadedRecipe = true;

            string str = cb_Recipe_Eng.Text;

            // 새로운 레시피 파일 저장
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(Application.StartupPath + @"\Data");
            if (!di.Exists) di.Create();

            string fileName = di.ToString() + "\\" + str + ".rcp";

            string[] lines = File.ReadAllLines(fileName);

            string temp = "";
            temp = lines[0]; // 1줄 밖에 없음

            char[] sep = { ',' };

            string[] result = temp.Split(sep);

            tb_PreTemp_Eng.Text = result[0];
            tb_PreHoldSec_Eng.Text = result[1];
            tb_1Temp_Eng.Text = result[2];
            tb_1HoldSec_Eng.Text = result[3];
            tb_2Temp_Eng.Text = result[4];
            tb_2HoldSec_Eng.Text = result[5];
            tb_OCDelaySec_Eng.Text = result[6];
            tb_OCHoldSec_Eng.Text = result[7];
            tb_FianlCycle_Eng.Text = result[8]; 
        }

        private void btn_MCURead_Eng_Click(object sender, EventArgs e)
        {
            // MCU와 통신하여 설정된 값을 가져와서 보여줌
            string[] result = { "1", "2", "3", "4", "5", "6", "7", "8", "9"};

            tb_PreTempMCU_Eng.Text = result[0];
            tb_PreHoldSecMCU_Eng.Text = result[1];
            tb_1TempMCU_Eng.Text = result[2];
            tb_1HoldSecMCU_Eng.Text = result[3];
            tb_2TempMCU_Eng.Text = result[4];
            tb_2HoldSecMCU_Eng.Text = result[5];
            tb_OCDelaySecMCU_Eng.Text = result[6];
            tb_OCHoldSecMCU_Eng.Text = result[7];
            tb_FianlCycleMCU_Eng.Text = result[8];
        }

        private void btn_ApplyAll_Eng_Click(object sender, EventArgs e)
        {
            if (!bLoadedRecipe)
            {
                MessageBox.Show("전송할 레시피를 먼저 읽은 후 전송이 가능합니다.", "레시피 전송 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; //  레시피를 읽지 않았다면 리턴
            }
            if (DialogResult.OK == MessageBox.Show("레시피를 MCU에 전송하겠습니까?", "레시피 전송 안내", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
            {
                // MCU와 통신하여 현재 설정값을 전달함


                MessageBox.Show("레시피를 MCU에 전송하였습니다.", "레시피 전송 안내", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // 전달한 후 MCU 값을 업데이트함
            btn_MCURead_Eng_Click(this, null);
        }

        private void tb_PW_Main_KeyUp(object sender, KeyEventArgs e)
        {
            // 엔터키 누를 때 로그인 버튼 클릭
            if (e.KeyCode == Keys.Enter && tb_PW_Main.Text!="") {
                btn_Login_Main_Click(this, null);
            }
        }

        private void btn_Print_Click(object sender, EventArgs e)
        {
            reportDlg.ShowDialog();
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void btn_PreTemp_Eng_Click(object sender, EventArgs e)
        {

        }

        private void btn_PreHoldSec_Eng_Click(object sender, EventArgs e)
        {

        }

        private void btn_1Temp_Eng_Click(object sender, EventArgs e)
        {

        }

        private void btn_2Temp_Eng_Click(object sender, EventArgs e)
        {

        }

        private void btn_FianlCycle_Eng_Click(object sender, EventArgs e)
        {

        }

        private void btn_1HoldSec_Eng_Click(object sender, EventArgs e)
        {

        }

        private void btn_2HoldSec_Eng_Click(object sender, EventArgs e)
        {

        }

        private void btn_OCDelaySec_Eng_Click(object sender, EventArgs e)
        {

        }

        private void btn_OCHoldSec_Eng_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btn_Test11_Eng_Click(object sender, EventArgs e)
        {

        }

        private void btn_Test12_Eng_Click(object sender, EventArgs e)
        {

        }

        private void btn_Test10_Eng_Click(object sender, EventArgs e)
        {

        }

        private void btn_Test9_Eng_Click(object sender, EventArgs e)
        {

        }

        private void btn_Test8_Eng_Click(object sender, EventArgs e)
        {

        }

        private void btn_Test7_Eng_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }

}
