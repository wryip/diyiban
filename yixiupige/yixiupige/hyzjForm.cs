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
    public partial class hyzjForm : Form
    {
        public hyzjForm()
        {
            InitializeComponent();
        }
        private static hyzjForm hyzj;
        public static hyzjForm Create()
        {
            if (hyzj==null)
            {
                hyzj = new hyzjForm();
            }
            return hyzj;
        }
     

        private void hyzjForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hyzj = null;
        }

        private void tcbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
