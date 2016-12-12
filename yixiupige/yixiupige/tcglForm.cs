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
    public partial class tcglForm : Form
    {
        public tcglForm()
        {
            InitializeComponent();
        }
        private static tcglForm tcgl;
        public static tcglForm Create()
        {
            if (tcgl==null)
            {
                tcgl = new tcglForm();
            }
            return tcgl;
        }
     
        private void tcglForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            tcgl = null;
        }
    }
}
