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
    public partial class hyczForm : Form
    {
        public hyczForm()
        {
            InitializeComponent();
        }
        private static hyczForm hycz;
        public static hyczForm Create()
        {
            if (hycz==null)
            {
                hycz = new hyczForm();
            }
            return hycz;
        }
        private void hyczForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hycz = null;
        }

        private void tcbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
