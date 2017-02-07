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
    public partial class spSalesFrom : Form
    {
        public spSalesFrom()
        {
            InitializeComponent();
        }
        private static spSalesFrom _danli = null;
        public static spSalesFrom CreateForm()
        {
            if (_danli == null)
            {
                _danli = new spSalesFrom();
            }
            return _danli;
        }
        private void spSalesFrom_Load(object sender, EventArgs e)
        {

        }

        private void spSalesFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }
    }
}
