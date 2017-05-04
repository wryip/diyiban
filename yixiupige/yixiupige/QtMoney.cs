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
    public partial class QtMoney : Form
    {
        public QtMoney()
        {
            InitializeComponent();
        }
        public delegate void tagbind(string name);
        public static tagbind tagbi;
        private static QtMoney _danli = null;
        public static QtMoney CreateForm(tagbind tbi)
        {
            tagbi = tbi;
            if (_danli == null)
            {
                _danli = new QtMoney();
            }
            return _danli;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int money = Convert.ToInt32(textBox1.Text.Trim());
                tagbi(textBox1.Text.Trim());
                this.Close();
            }
            catch
            {
                MessageBox.Show("失败！请输入数字！");
            }
        }

        private void QtMoney_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
