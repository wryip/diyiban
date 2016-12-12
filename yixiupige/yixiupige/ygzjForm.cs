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
    public partial class ygzjForm : Form
    {
        public ygzjForm()
        {
            InitializeComponent();
        }
        private static ygzjForm ygzj;
        public static ygzjForm Create()
        {
            if (ygzj==null)
            {
                ygzj = new ygzjForm();
            }
            return ygzj;
        }
        private void ygzjForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ygzj = null;
        }
    }
}
