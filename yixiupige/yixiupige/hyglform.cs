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
    public partial class hyglform : Form
    {
        public hyglform()
        {
            InitializeComponent();
        }
        private static hyglform _danli = null;
        public static hyglform CreateForm()
        {
            if (_danli == null)
            {
                _danli = new hyglform();
            }
            return _danli;
        }
        private void hyglform_Load(object sender, EventArgs e)
        {

        }

        private void hyglform_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }
    }
}
