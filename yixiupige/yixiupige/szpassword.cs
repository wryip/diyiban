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
    public partial class szpassword : Form
    {
        public szpassword()
        {
            InitializeComponent();
        }
        private static szpassword hyfl;
        public delegate void shezhipwd(string ss);
        public static shezhipwd pwd;
        public static szpassword Create(shezhipwd chuan)
        {
            pwd = chuan;
            if (hyfl == null)
            {
                hyfl = new szpassword();
            }
            return hyfl;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == textBox2.Text)&&textBox1.Text!="")
            {
                pwd(textBox1.Text);
                this.Close();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                MessageBox.Show("密码输入有误，请重新输入！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void szpassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            hyfl = null;
        }
    }
}
