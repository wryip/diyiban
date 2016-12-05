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
    public partial class tjform : Form
    {
        public tjform()
        {
            InitializeComponent();
        }
        private static tjform _danli = null;
        public static tjform CreateForm()
        {
            if (_danli == null)
            {
                _danli = new tjform();
            }
            return _danli;
        }
        private void tjform_Load(object sender, EventArgs e)
        {

        }

        private void tjform_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }
    }
}
