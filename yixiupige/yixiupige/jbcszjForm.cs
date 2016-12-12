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
    public partial class jbcszjForm : Form
    {
        public jbcszjForm()
        {
            InitializeComponent();
        }
        private static jbcszjForm jbcszj;
        //设置单例模式
        public static jbcszjForm Create()
        {
            if (jbcszj==null)
            {
                jbcszj = new jbcszjForm();
            }
            return jbcszj;
        }
        private void jbcszjForm_Load(object sender, EventArgs e)
        {

        }

        private void jbcszjForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            jbcszj = null;
        }

        private void TCbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
