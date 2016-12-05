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
    public partial class dxform : Form
    {
        public dxform()
        {
            InitializeComponent();
        }
        private static dxform _danli = null;
        public static dxform CreateForm()
        {
            if (_danli == null)
            {
                _danli = new dxform();
            }
            return _danli;
        }
        private void dxform_Load(object sender, EventArgs e)
        {

        }

        private void dxform_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }
    }
}
