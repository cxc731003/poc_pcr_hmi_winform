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
        
        

        ucFirstPage firstScreen = new ucFirstPage();
        ucTestInfo testInfo = new ucTestInfo();
        ucTestPreparation testPreparation = new ucTestPreparation();
        ucTestStart testStart = new ucTestStart();
        ucRunning running = new ucRunning();


        public UI_for_Tester()
        {
            InitializeComponent();

            firstScreen.btnNewTest_Event += btnNewTest_Click;
            firstScreen.btnPrevious_Event += btnPreviousTest_Click;

            testInfo.btnTestInfoNext_Event += btnTestInfoNext_Click;
            testPreparation.btnTestPreparationNext_Event += btnTestPreparationNext_Click;

            testStart.btnTestStart_Event += btnStartTest_Click;
        }
        
        private void UI_for_Tester_Load(object sender, EventArgs e)
        {
            panel_ui.Controls.Add(firstScreen);
            panel_ui.Controls.Add(testInfo);
            panel_ui.Controls.Add(testPreparation);
            panel_ui.Controls.Add(testStart);
            panel_ui.Controls.Add(running);
            panel_ui.Visible = true;
        }

        /// <summary>
        /// First page of UI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnNewTest_Click(object sender, EventArgs e)
        {
            //panel_ui
            firstScreen.Visible = false;
            testInfo.Visible = true;
            testPreparation.Visible = false;
            testStart.Visible = false;
        }
        private void btnPreviousTest_Click(object sender, EventArgs e)
        {

        }
        
        /// <summary>
        /// Test Information page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestInfoNext_Click(object sender, EventArgs e)
        {
            firstScreen.Visible = false;
            testInfo.Visible = false;
            testPreparation.Visible = true;
            testStart.Visible = false;
        }

        /// <summary>
        /// Test preparation page 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTestPreparationNext_Click(object sender, EventArgs e)
        {
            firstScreen.Visible = false;
            testInfo.Visible = false;
            testPreparation.Visible = false;
            running.Visible = false;

            testStart.Visible = true;            
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            //panel_ui
            firstScreen.Visible = false;
            testInfo.Visible = false;
            testPreparation.Visible = false;
            testStart.Visible = false;

            running.Visible = true;
        }




        public void showTestInfo()
        {
            //panel_ui.Controls.Add(userControlTestInfo);
            //userControlTestInfo.Visible = true;
            //firstScreen.Visible = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }
    }
}
