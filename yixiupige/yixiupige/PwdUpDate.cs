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
    public partial class PwdUpDate : Form
    {
        public PwdUpDate()
        {
            InitializeComponent();
        }
        private static PwdUpDate hyzj;
        public delegate void binddata(string pwd);
        public static binddata databind1;
        public static string OldPwd;
        public static PwdUpDate Create(string pwd,binddata binddata)
        {
            OldPwd = pwd;
            databind1 = binddata;
            if (hyzj == null)
            {
                hyzj = new PwdUpDate();
            }
            return hyzj;
        }
        private void PwdUpDate_Load(object sender, EventArgs e)
        {

        }

        private void PwdUpDate_FormClosing(object sender, FormClosingEventArgs e)
        {
            hyzj = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox1.Text.Trim() == "" || textBox1.Text.Trim() == "")
            {
                MessageBox.Show("请将数据填写完整！");
                return;
            }
            if (textBox1.Text.Trim() != OldPwd.Trim())
            {
                MessageBox.Show("原密码不正确!");
                return;
            }
            if (textBox2.Text.Trim() != textBox3.Text.Trim())
            {
                MessageBox.Show("两次密码输入不长一致！");
                return;
            }
            databind1(textBox2.Text.Trim());
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
