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
    public partial class HYXFPassword : Form
    {
        public HYXFPassword()
        {
            InitializeComponent();
        }
        private static HYXFPassword _danli = null;
        public delegate void databind(string pwd);
        public static databind bind1;
        public static HYXFPassword CreateForm(databind bind)
        {
            bind1 = bind;
            if (_danli == null)
            {
                _danli = new HYXFPassword();
            }
            return _danli;
        }
        private void HYXFPassword_Load(object sender, EventArgs e)
        {

        }

        private void HYXFPassword_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bind1(textBox1.Text.Trim());
            this.Close();
        }
    }
}
