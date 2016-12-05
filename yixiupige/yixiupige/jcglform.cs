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
    public partial class jcglform : Form
    {
        public jcglform()
        {
            InitializeComponent();
        }
        private static jcglform _danli = null;
        public static jcglform CreateForm()
        {
            if (_danli == null)
            {
                _danli = new jcglform();
            }
            return _danli;
        }
        private void jcglform_Load(object sender, EventArgs e)
        {

        }

        private void jcglform_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }
    }
}
