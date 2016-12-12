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
    public partial class ygglForm : Form
    {
        public ygglForm()
        {
            InitializeComponent();
        }
        private static ygglForm yggl;
        public static ygglForm Create()
        {
            if (yggl==null)
            {
                yggl = new ygglForm();
            }
            return yggl;
        }
       

        private void ygglForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            yggl = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zjbutton_Click(object sender, EventArgs e)
        {
            ygzjForm zjhy = ygzjForm.Create();
            zjhy.Show();
            zjhy.Focus();
        }
    }
}
