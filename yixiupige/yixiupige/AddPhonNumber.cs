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
    public partial class AddPhonNumber : Form
    {
        public AddPhonNumber()
        {
            InitializeComponent();
        }
        public delegate void AddNumber(string str);
        public static AddNumber databind;
        private static AddPhonNumber _danli = null;
        public static AddPhonNumber CreateForm(AddNumber bind)
        {
            databind = bind;
            if (_danli == null)
            {
                _danli = new AddPhonNumber();
            }
            return _danli;
        }
        private void AddPhonNumber_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            databind(textBox1.Text);
            this.Close();
        }
    }
}
