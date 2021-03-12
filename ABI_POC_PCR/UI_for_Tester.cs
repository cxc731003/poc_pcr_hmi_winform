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
    public partial class UI_for_Tester : Form
    {
        
        

        ucFirstScreen firstScreen = new ucFirstScreen();
        ucTestInfo userControlTestInfo = new ucTestInfo();

        public UI_for_Tester()
        {
            InitializeComponent();
           
        }

        private void btnNewTest_Click(object sender, EventArgs e)
        {
            
        }


        private void UI_for_Tester_Load(object sender, EventArgs e)
        {
            panel_ui.Controls.Add(firstScreen);
            panel_ui.Visible = true;
        }

        private void btnPreviousTest_Click(object sender, EventArgs e)
        {

        }

        public void showTestInfo()
        {
            panel_ui.Controls.Add(userControlTestInfo);
            userControlTestInfo.Visible = true;
            firstScreen.Visible = false;
        }
    }
}
