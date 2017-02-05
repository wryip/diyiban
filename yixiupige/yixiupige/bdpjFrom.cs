using BLL;
using MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yixiupige
{
    public partial class bdpjFrom : Form
    {
        public bdpjFrom()
        {
            InitializeComponent();
        }
        private static bdpjFrom zjhyfl;
        //public static string cardNo;
        LSConsumptionBLL lsbll = new LSConsumptionBLL();
        public static bdpjFrom Create()
        {
            //cardNo = cardno;
            if (zjhyfl == null)
            {
                zjhyfl = new bdpjFrom();
            }
            return zjhyfl;
        }
        private void bdpjFrom_Load(object sender, EventArgs e)
        {
            List<bdpjModel> list = new List<bdpjModel>();
            list = lsbll.selectBDPJ();
            dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bdpjFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            zjhyfl = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }
    }
}
