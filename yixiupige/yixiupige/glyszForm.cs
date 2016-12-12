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
    public partial class glyszForm : Form
    {
        public glyszForm()
        {
            InitializeComponent();
        }
        //单例模式
        private  static glyszForm glysz;
        public static glyszForm Create()
        {
            if (glysz == null)
            {
                glysz = new glyszForm();
            }
            return glysz;
        }
        //窗体加载
        private void glyszForm_Load(object sender, EventArgs e)
        {
            groupBox2.Text="管理员列表-有"+dataGridView1.RowCount+"条";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
        //全选操作
        private void button1_Click(object sender, EventArgs e)
        {
            shglcheckBox.Checked = true;
            hyglcheckBox.Checked = true;
            jcsjcheckBox.Checked = true;
            jcglcheckBox.Checked = true;
            spglcheckBox.Checked = true;
            tjbbcheckBox.Checked = true;
            dxglcheckBox.Checked = true;
            spcheckBox.Checked = true;
            glyszcheckBox.Checked = true;
            lsdszcheckBox.Checked = true;
            sjkglcheckBox.Checked = true;
            jbcscheckBox.Checked = true;
            qtcheckBox.Checked = true;
            flcheckBox.Checked = true;
            phglcheckBox.Checked = true;
            hyglcheckBox.Checked = true;
            tcglcheckBox.Checked = true;
            jhglcheckBox.Checked = true;
            ygcheckBox.Checked = true;
        }
        //反选函数
        public bool Check(bool checkbox)
        {
            if (checkbox)
            {
                checkbox = false;
            }
            else if (!checkbox)
            {
                checkbox = true;
            }
            return checkbox;
        }
        //反选操作
        private void button2_Click(object sender, EventArgs e)
        {
           shglcheckBox.Checked= Check(shglcheckBox.Checked);
           hyglcheckBox.Checked=Check(hyglcheckBox.Checked);
           jcsjcheckBox.Checked= Check(jcsjcheckBox.Checked);
           jcglcheckBox.Checked= Check(jcglcheckBox.Checked);
           spglcheckBox.Checked= Check(spglcheckBox.Checked);
           tjbbcheckBox.Checked=Check(tjbbcheckBox.Checked);
          dxglcheckBox.Checked=Check(dxglcheckBox.Checked);
           spcheckBox.Checked= Check(spcheckBox.Checked);
           glyszcheckBox.Checked= Check(glyszcheckBox.Checked);
           lsdszcheckBox.Checked= Check(lsdszcheckBox.Checked);
          sjkglcheckBox.Checked= Check(sjkglcheckBox.Checked);
           jbcscheckBox.Checked= Check(jbcscheckBox.Checked);
           qtcheckBox.Checked= Check(qtcheckBox.Checked);
           flcheckBox.Checked= Check(flcheckBox.Checked);
           phglcheckBox.Checked= Check(phglcheckBox.Checked);
           hyglcheckBox.Checked= Check(hyglcheckBox.Checked);
           tcglcheckBox.Checked= Check(tcglcheckBox.Checked);
           jhglcheckBox.Checked= Check(jhglcheckBox.Checked);
           ygcheckBox.Checked = Check(ygcheckBox.Checked);
           hyglcheckBox.Checked = Check(hyglcheckBox.Checked);
        }

        private void glyszForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            glysz = null;
        }
    }
}
