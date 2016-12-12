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
    public partial class hyflglfwForm : Form
    {
        public hyflglfwForm()
        {
            InitializeComponent();
        }
        private static hyflglfwForm hyfl;
        public static hyflglfwForm Create()
        {
            if (hyfl==null)
            {
                hyfl = new hyflglfwForm();
            }
            return hyfl;
        }
        private void tcbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hyflglfwForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hyfl = null;
        }

        private void zjhylbbutton_Click(object sender, EventArgs e)
        {
            zjhyflForm zjhyfl = zjhyflForm.Create();
            zjhyfl.Show();
            zjhyfl.Focus();
        }

        private void zjfwbutton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
