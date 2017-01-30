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
    public partial class hyxgFrom : Form
    {
        public hyxgFrom()
        {
            InitializeComponent();
        }
        public jbcsBLL jbbll = new jbcsBLL();
        staffInfoBLL staffbll = new staffInfoBLL();
        public static staffTable model;
        private static hyxgFrom yggl;
        public delegate void databind();
        public static databind bind;
        public static hyxgFrom Create(staffTable model11,databind bind1)
        {
            bind = bind1;
            model = model11;
            if (yggl == null)
            {
                yggl = new hyxgFrom();
            }
            return yggl;
        }
        private void hyxgFrom_Load(object sender, EventArgs e)
        {
            List<jbcs> list = jbbll.selectList(6);
            foreach (var iteam in list)
            {
                zwgzcomboBox.Items.Add(iteam.AllType);
            }
            ygxmtextBox.Text = model.stName;
            ygxbcomboBox.Text = model.stSex;
            zwgzcomboBox.Text = model.stType;
            sfzhtextBox.Text = model.stDocument;
            lxdhtextBox.Text = model.stTel;
            jtzztextBox.Text = model.stAdd;
            bzxxtextBox.Text = model.stRemark;
        }

        private void hyxgFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            yggl = null;
        }

        private void tcbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zjbutton_Click(object sender, EventArgs e)
        {
            staffTable newmodel = new staffTable();
            newmodel.Id = model.Id;
            newmodel.stName = ygxmtextBox.Text.Trim();
            newmodel.stType = zwgzcomboBox.Text.Trim();
            newmodel.stSex = ygxbcomboBox.Text.Trim();
            newmodel.stDocument = sfzhtextBox.Text.Trim() == "" ? "0" : sfzhtextBox.Text.Trim();
            newmodel.stTel = lxdhtextBox.Text.Trim() == "" ? "0" : lxdhtextBox.Text.Trim();
            newmodel.stAdd = jtzztextBox.Text.Trim() == "" ? "0" : jtzztextBox.Text.Trim();
            newmodel.stRemark = bzxxtextBox.Text.Trim() == "" ? "0" : bzxxtextBox.Text.Trim();
            bool result = staffbll.updateModel(newmodel);
            if (result)
            {
                MessageBox.Show("修改成功！");
                bind();
                this.Close();

            }
            else 
            {
                MessageBox.Show("修改失败！");
            }
        }
    }
}
