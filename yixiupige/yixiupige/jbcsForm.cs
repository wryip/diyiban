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
    public partial class jbcsForm : Form
    {
        public jbcsForm()
        {
            InitializeComponent();
        }

        private static jbcsForm jbcs;
        public static jbcsForm Create()
        {
            if (jbcs==null)
            {
                jbcs = new jbcsForm();
            }
            return jbcs;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            jbcszjForm jbcszj = jbcszjForm.Create();
            jbcszj.Text = listBox1.SelectedItem.ToString();
            jbcszj.Show();
            jbcszj.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jbcsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            jbcs = null;
        }

        private void jbcsForm_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
        }
       
       
    }
}
