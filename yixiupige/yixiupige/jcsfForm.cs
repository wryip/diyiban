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
    public partial class jcsfForm : Form
    {
        public jcsfForm()
        {
            InitializeComponent();
        }

        private static jcsfForm jcs;
        public static jcsfForm Create()
        {
            if (jcs==null)
            {
                jcs = new jcsfForm();
            }
            return jcs;
        }
        private void jcsfForm_Load(object sender, EventArgs e)
        {

        }

        private void jcsfForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            jcs = null;
        }
    }
}
