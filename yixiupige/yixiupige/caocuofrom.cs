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
    public partial class caocuofrom : Form
    {
        public caocuofrom()
        {
            InitializeComponent();
        }
        private static caocuofrom _danli = null;
        public delegate void caozuoyanzheng(string pwd,string cardNo);
        public static caozuoyanzheng action1;
        public static string cardNo1;
        public static caocuofrom Create(caozuoyanzheng action,string cardNo)
        {
            action1 = action;
            cardNo1 = cardNo;
            if (_danli == null)
            {
                _danli = new caocuofrom();
            }
            return _danli;
        }
        private void caocuofrom_Load(object sender, EventArgs e)
        {

        }

        private void caocuofrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            action1(textBox1.Text.Trim(), cardNo1);
            this.Close();
        }
    }
}
