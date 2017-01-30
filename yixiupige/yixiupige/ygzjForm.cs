using BLL;
using MODEL;
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
    public partial class ygzjForm : Form
    {
        public ygzjForm()
        {
            InitializeComponent();
        }
        private static ygzjForm ygzj;
        public jbcsBLL jbbll = new jbcsBLL();
        public delegate void databind();
        public static databind bind;
        staffInfoBLL staffbll = new staffInfoBLL();
        public static ygzjForm Create(databind bind1)
        {
            bind=bind1;
            if (ygzj==null)
            {
                ygzj = new ygzjForm();
            }
            return ygzj;
        }
        private void ygzjForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ygzj = null;
        }

        private void tcbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ygzjForm_Load(object sender, EventArgs e)
        {
            List<jbcs> list = jbbll.selectList(6);
            ygxbcomboBox.SelectedIndex = 0;
            foreach (var iteam in list)
            {
                zwgzcomboBox.Items.Add(iteam.AllType);
            }
        }

        private void zjbutton_Click(object sender, EventArgs e)
        {
            if (ygxmtextBox.Text.Trim() == "" || zwgzcomboBox.Text.Trim() == "")
            {
                MessageBox.Show("请将信息填写完全！");
                return;
            }
            staffTable model = new staffTable();
            model.stName = ygxmtextBox.Text.Trim();
            model.stType = zwgzcomboBox.Text.Trim();
            model.stSex = ygxbcomboBox.Text.Trim();
            model.stDocument = sfzhtextBox.Text.Trim() == "" ? "0" : sfzhtextBox.Text.Trim();
            model.stTel = lxdhtextBox.Text.Trim() == "" ? "0" : lxdhtextBox.Text.Trim();
            model.stAdd = jtzztextBox.Text.Trim() == "" ? "0" : jtzztextBox.Text.Trim();
            model.stRemark = bzxxtextBox.Text.Trim() == "" ? "0" : bzxxtextBox.Text.Trim();
            bool result = staffbll.AddInfoModel(model);
            if (result)
            {
                MessageBox.Show("添加成功！");
                bind();
                this.Close();
            }
            else
            {
                MessageBox.Show("添加失败！");
            }
        }
    }
}
