using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABI_POC_PCR
{
    public partial class InfoDialog : Form
    {
        public int retBtn = 0; // 취소

        public InfoDialog()
        {
            InitializeComponent();
            this.CenterToParent();

            //pb_SampeImage.Image = System.Drawing.Image.FromFile("data\\_sample.bmp"); 
        }

        private void btn_OK_InfoDlg_Click(object sender, EventArgs e)
        {
            retBtn = 1; // 확인
            Close();
        }

        private void btn_Cancle_InfoDlg_Click(object sender, EventArgs e)
        {
            retBtn = 0; // 취소
            Close();
        }
    }
}
