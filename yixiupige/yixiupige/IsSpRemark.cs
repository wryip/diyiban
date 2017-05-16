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
    public partial class IsSpRemark : Form
    {
        public IsSpRemark()
        {
            InitializeComponent();
        }
        public delegate void DataBind(string remark);
        static DataBind bind1; 
        private static IsSpRemark _danli = null;
        public static IsSpRemark CreateForm(DataBind bind)
        {
            bind1 = bind;
            if (_danli == null)
            {
                _danli = new IsSpRemark();
            }
            return _danli;
        }
        private void IsSpRemark_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                DialogResult result= MessageBox.Show("备注确认为空？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    return;
                }                
            }
            bind1(textBox1.Text.Trim());
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IsSpRemark_Load(object sender, EventArgs e)
        {

        }
    }
}
