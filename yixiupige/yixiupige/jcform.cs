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
    public partial class jcform : Form
    {
        public jcform()
        {
            InitializeComponent();
        }
        private static jcform _danli = null;
        public static jcform CreateForm()
        {
            if (_danli == null)
            {
                _danli = new jcform();
            }
            return _danli;
        }
        private void jcform_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void jcform_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }
    }
}
