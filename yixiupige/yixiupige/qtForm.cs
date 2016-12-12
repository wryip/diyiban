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
    public partial class qtForm : Form
    {
        public qtForm()
        {
            InitializeComponent();
        }
        private static qtForm qt;
        public static qtForm Create()
        {
            if (qt==null)
            {
                qt = new qtForm();
            }
            return qt;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void qtForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            qt = null;
        }

        private void qtForm_Load(object sender, EventArgs e)
        {
            groupBox1.Text = "其他服务列表-有" + dataGridView1.ColumnCount + "条";
        }
    }
}
