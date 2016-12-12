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
    public partial class jhglForm : Form
    {
        public jhglForm()
        {
            InitializeComponent();
        }
        private static jhglForm jhgl;
        public static jhglForm Create()
        {
            if (jhgl==null)
            {
                jhgl = new jhglForm(); 
            }
            return jhgl;
        }
        private void jhglForm_Load(object sender, EventArgs e)
        {
            qstextBox.Focus();
        }

      

        private void jhglForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            jhgl = null;
        }
    }
}
