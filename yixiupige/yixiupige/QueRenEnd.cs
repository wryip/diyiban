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
    public partial class QueRenEnd : Form
    {
        public QueRenEnd()
        {
            InitializeComponent();
        }
        public delegate void binddata(string name, string tel, int id, string dannumbe);
        public delegate void bindsx();
        public static bindsx binsx;
        public static binddata bind1;
        private static QueRenEnd _danli = null;
        public static int ID;
        public static string dannum;
        public static QueRenEnd CreateForm(binddata bind,int id,string dannumber,bindsx bdsx)
        {
            binsx = bdsx;
            dannum = dannumber;
            ID = id;
            bind1 = bind;
            if (_danli == null)
            {
                _danli = new QueRenEnd();
            }
            return _danli;
        }
        private void QueRenEnd_Load(object sender, EventArgs e)
        {

        }

        private void QueRenEnd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Trim() == "")
            {
                MessageBox.Show("请将信息填写完整！");
                return;
            }
            bind1(textBox1.Text.Trim(), textBox2.Text.Trim(), ID, dannum);
            binsx();
            this.Close();
        }
    }
}
