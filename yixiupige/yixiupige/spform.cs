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
    public partial class spform : Form
    {
        public spform()
        {
            InitializeComponent();
        }
        private static spform _danli = null;
        public static spform CreateForm()
        {
            if (_danli == null)
            {
                _danli = new spform();
            }
            return _danli;
        }
        private void spform_Load(object sender, EventArgs e)
        {

        }

        private void spform_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }
    }
}
