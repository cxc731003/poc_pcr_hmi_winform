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
    public partial class ucTestPreparation : UserControl
    {
        public event EventHandler btnTestPreparationNext_Event;
        public ucTestPreparation()
        {
            InitializeComponent();
            picBox_TestPreparationNext.Click += btnTestPreparationNext_Click_Event;
            
        }

        public void btnTestPreparationNext_Click_Event(object sender, EventArgs e)
        {
            if (this.btnTestPreparationNext_Event != null)
                btnTestPreparationNext_Event(sender, e);
        }
    }
}
