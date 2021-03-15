using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABI_POC_PCR
{
    public partial class ucFirstPage : UserControl
    {
        public event EventHandler btnNewTest_Event;
        public event EventHandler btnPrevious_Event;

        public ucFirstPage()
        {
            InitializeComponent();

            btnNewTest.Click += btnNewTest_Click_Event;
            btnPreviousTest.Click += btnPreviousTest_Click_Event;
        }

        public void btnNewTest_Click_Event(object sender, EventArgs e)
        {
            if (this.btnNewTest_Event != null)
                btnNewTest_Event(sender, e);
        }

        public void btnPreviousTest_Click_Event(object sender, EventArgs e)
        {
            if (this.btnPrevious_Event != null)
                btnPrevious_Event(sender, e);
        }
        
    }
}
