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
    public partial class lsdglForm : Form
    {
        public lsdglForm()
        {
            InitializeComponent();
        }
        private static lsdglForm lsdgl;
        //单例模式
        public static lsdglForm Create()
        {
            if (lsdgl == null)
            {
                lsdgl = new lsdglForm();
            }
            return lsdgl;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lsdzjForm lsdzj = lsdzjForm.Create();
            lsdzj.Show();
            lsdzj.Focus();
        }

        private void lsdglForm_Load(object sender, EventArgs e)
        {
            groupBox1.Text="店铺记录有"+dataGridView1.RowCount+"条";
        }

        private void lsdglForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            lsdgl = null;
        }
    }
}
