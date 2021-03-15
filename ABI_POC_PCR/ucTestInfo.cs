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
    public partial class ucTestInfo : UserControl
    {
        public event EventHandler btnTestInfoNext_Event;

        DataGridView dgv_TestInfo = new DataGridView();
        public ucTestInfo()
        {
            InitializeComponent();
            picBox_TestInfoNext.Click += btnTestInfoNext_Click_Event;
            
        }

        public void btnTestInfoNext_Click_Event(object sender, EventArgs e)
        {
            if (this.btnTestInfoNext_Event != null)
                btnTestInfoNext_Event(sender, e);
        }

        private void ucTestInfo_Load(object sender, EventArgs e)
        {
            //SetupDataGridView(dgv_TestInfo);
            //PopulateDataGridView(dgv_TestInfo);
        }


        private void SetupDataGridView(DataGridView dgv)
        {
            this.Controls.Add(dgv);

            dgv.ColumnCount = 5;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font =
                new Font(dgv.Font, FontStyle.Bold);

            dgv.Name = "songsDataGridView";
            dgv.Location = new Point(8, 8);
            dgv.Size = new Size(300, 150);
            dgv.AutoSizeRowsMode =
                DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            dgv.ColumnHeadersBorderStyle =
                DataGridViewHeaderBorderStyle.Single;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            dgv.GridColor = Color.Black;
            dgv.RowHeadersVisible = false;

            dgv.Columns[0].Name = "Release Date";
            dgv.Columns[1].Name = "Track";
            dgv.Columns[2].Name = "Title";
            dgv.Columns[3].Name = "Artist";
            dgv.Columns[4].Name = "Album";
            dgv.Columns[4].DefaultCellStyle.Font =
                new Font(dgv.DefaultCellStyle.Font, FontStyle.Italic);

            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.Dock = DockStyle.Fill;          
        }

        private void PopulateDataGridView(DataGridView dgv)
        {

            string[] row0 = { "11/22/1968", "29", "Revolution 9",
            "Beatles", "The Beatles [White Album]" };
            string[] row1 = { "1960", "6", "Fools Rush In",
            "Frank Sinatra", "Nice 'N' Easy" };
            string[] row2 = { "11/11/1971", "1", "One of These Days",
            "Pink Floyd", "Meddle" };
            string[] row3 = { "1988", "7", "Where Is My Mind?",
            "Pixies", "Surfer Rosa" };
            string[] row4 = { "5/1981", "9", "Can't Find My Mind",
            "Cramps", "Psychedelic Jungle" };
            string[] row5 = { "6/10/2003", "13",
            "Scatterbrain. (As Dead As Leaves.)",
            "Radiohead", "Hail to the Thief" };
            string[] row6 = { "6/30/1992", "3", "Dress", "P J Harvey", "Dry" };

            dgv.Rows.Add(row0);
            dgv.Rows.Add(row1);
            dgv.Rows.Add(row2);
            dgv.Rows.Add(row3);
            dgv.Rows.Add(row4);
            dgv.Rows.Add(row5);
            dgv.Rows.Add(row6);

            dgv.Columns[0].DisplayIndex = 3;
            dgv.Columns[1].DisplayIndex = 4;
            dgv.Columns[2].DisplayIndex = 0;
            dgv.Columns[3].DisplayIndex = 1;
            dgv.Columns[4].DisplayIndex = 2;
        }
    }
}
