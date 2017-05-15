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
    public partial class tcglForm : Form
    {
        public tcglForm()
        {
            InitializeComponent();
        }
        private static tcglForm tcgl;
        public static tcglForm Create()
        {
            if (tcgl==null)
            {
                tcgl = new tcglForm();
            }
            return tcgl;
        }
     
        private void tcglForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tcgl = null;
        }

        private void tcglForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tcjsbutton_Click(object sender, EventArgs e)
        {

        }

        private void tjbutton_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void wjsradioButton_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void yjsradioButton_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
