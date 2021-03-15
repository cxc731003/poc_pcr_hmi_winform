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
    public partial class ucTestStart : UserControl
    {
        public event EventHandler btnTestStart_Event;
        public ucTestStart()
        {
            InitializeComponent();
            btnTestStart.Click += btnTestStart_Click_Event;
        }

        public void btnTestStart_Click_Event(object sender, EventArgs e)
        {
            if (this.btnTestStart_Event != null)
                btnTestStart_Event(sender, e);
        }
    
    }
}
