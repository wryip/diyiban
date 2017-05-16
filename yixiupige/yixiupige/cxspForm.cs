using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using MODEL;
namespace yixiupige
{
    public partial class cxspForm : Form
    {
        public cxspForm()
        {
            InitializeComponent();
        }
        private static cxspForm cx;
        public static cxspForm Create()
        {
            if (cx==null)
            {
                cx = new cxspForm();
            }
            return cx;
        }
        GoodInfoBLL gdbll = new GoodInfoBLL();
      
        public delegate void loadd(GoodInfo gd);
        public event loadd loaddd;
        spform sp = new spform();
        private void button1_Click(object sender, EventArgs e)
        {
            GoodInfo gd = new GoodInfo();
            if (comboBox1.Text=="库号")
            {
                gd.Gno = textBox1.Text;
            }
            if (comboBox1.Text=="名称")
            {
                gd.Gname = textBox1.Text;
            }
            sp.load(gd);
            loaddd(gd);
            
           
        }

        private void cxspForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cxspForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            cx = null;
        }
    }
}
