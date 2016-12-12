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
    public partial class zjhyflForm : Form
    {
        public zjhyflForm()
        {
            InitializeComponent();
        }
        private static zjhyflForm zjhyfl;
        public static zjhyflForm Create()
        {
            if (zjhyfl==null)
            {
                zjhyfl = new zjhyflForm();
            }
            return zjhyfl;
        }
        private void zjhyflForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            zjhyfl = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
