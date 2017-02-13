using BLL;
using Commond;
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
        LoginUser logbll = new LoginUser();
        DPInfoBLL dpbll = new DPInfoBLL();
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
            //string name = "";
            groupBox2.Text="管理员列表-有"+dataGridView1.RowCount+"条";
            if (FilterClass.isadmin())
            {
                List<string> str = dpbll.selectDPName();
                foreach (var iteam in str)
                {
                    comboBox1.Items.Add(iteam);
                }
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.Text = FilterClass.DianPu1.UserName;
                comboBox1.Enabled = false;
            }
            databind(comboBox1.Text.Trim());
        }
        public void databind(string name)
        {
            List<MODEL.LoginUser> list = new List<MODEL.LoginUser>();
            list = logbll.selectAllList(name);
            dataGridView1.DataSource = list;
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
            glyszcheckBox.Checked = true;
            lsdszcheckBox.Checked = true;
            sjkglcheckBox.Checked = true;
            jbcscheckBox.Checked = true;
            qtcheckBox.Checked = true;
            flcheckBox.Checked = true;
            hyglcheckBox.Checked = true;
            tcglcheckBox.Checked = true;
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
           glyszcheckBox.Checked= Check(glyszcheckBox.Checked);
           lsdszcheckBox.Checked= Check(lsdszcheckBox.Checked);
          sjkglcheckBox.Checked= Check(sjkglcheckBox.Checked);
           jbcscheckBox.Checked= Check(jbcscheckBox.Checked);
           qtcheckBox.Checked= Check(qtcheckBox.Checked);
           flcheckBox.Checked= Check(flcheckBox.Checked);
           hyglcheckBox.Checked= Check(hyglcheckBox.Checked);
           tcglcheckBox.Checked= Check(tcglcheckBox.Checked);
           ygcheckBox.Checked = Check(ygcheckBox.Checked);
           hyglcheckBox.Checked = Check(hyglcheckBox.Checked);
        }

        private void glyszForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            glysz = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            databind(comboBox1.Text.Trim());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择要删除的数据！");
                return;
            }
            if (dataGridView1.SelectedRows[0].Cells["Menager"].Value.ToString().Trim() == "管理员")
            {
                MessageBox.Show("不能删除管理员！");
                return;
            }
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value);
            bool result = logbll.deleteIteam(id);
            if (result)
            {
                MessageBox.Show("删除成功！");
                databind(comboBox1.Text.Trim());
                EmptyData();
                return;
            }
            MessageBox.Show("删除失败！");
        }
        public void EmptyData()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            shglcheckBox.Checked = false;
            hyglcheckBox.Checked = false;
            jcsjcheckBox.Checked = false;
            jcglcheckBox.Checked = false;
            spglcheckBox.Checked = false;
            tjbbcheckBox.Checked = false;
            dxglcheckBox.Checked = false;
            glyszcheckBox.Checked = false;
            lsdszcheckBox.Checked = false;
            sjkglcheckBox.Checked = false;
            jbcscheckBox.Checked = false;
            qtcheckBox.Checked = false;
            flcheckBox.Checked = false;
            hyglcheckBox.Checked = false;
            tcglcheckBox.Checked = false;
            ygcheckBox.Checked = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("两次密码不一致！");
                return;
            }
            MODEL.LoginUser model = new MODEL.LoginUser();
            model.UserName = comboBox1.Text;
            model.LoginName = textBox1.Text.Trim();
            model.UserPwd = textBox2.Text.Trim();
            if (shglcheckBox.Checked)
            {
                model.shgl = true;
            }
            if (hyglcheckBox.Checked)
            {
                model.hygl = true;
            }
            if (jcsjcheckBox.Checked)
            {
                model.jcsj = true;
            }
            if (jcglcheckBox.Checked)
            {
                model.jcgl = true;
            }
            if (spglcheckBox.Checked)
            {
                model.spgl = true;
            }
            if (tjbbcheckBox.Checked)
            {
                model.tjbb = true;
            }
            if (dxglcheckBox.Checked)
            {
                model.dxgl = true;
            }
            if (tcglcheckBox.Checked)
            {
                model.tcgl = true;
            }
            if (glyszcheckBox.Checked)
            {
                model.glysz = true;
            }
            if (lsdszcheckBox.Checked)
            {
                model.lsdsz = true;
            }
            if (sjkglcheckBox.Checked)
            {
                model.sjkgl = true;
            }
            if (jbcscheckBox.Checked)
            {
                model.jbcs = true;
            }
            if (qtcheckBox.Checked)
            {
                model.qtfw = true;
            }
            if (flcheckBox.Checked)
            {
                model.flgl = true;
            }
            if (ygcheckBox.Checked)
            {
                model.yggl = true;
            }
            bool result = logbll.AddUserIteam(model);
            if (result)
            {
                MessageBox.Show("添加成功!");
                databind(comboBox1.Text.Trim());
                return;
            }
            MessageBox.Show("添加失败!");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                MODEL.LoginUser model = (MODEL.LoginUser)dataGridView1.SelectedRows[0].DataBoundItem;
                DataXS(model);
                return;
            }
            MessageBox.Show("请选择一行数据！");
        }
        public void DataXS(MODEL.LoginUser model)
        {
            textBox1.Text = model.LoginName;
            textBox2.Text = model.UserPwd;
            textBox3.Text = model.UserPwd;
            if (model.shgl)
            {
                shglcheckBox.Checked=true;
            }
            if (model.hygl)
            {
                hyglcheckBox.Checked = true;
            }
            if (model.jcsj)
            {
                jcsjcheckBox.Checked = true;
            }
            if (model.jcgl)
            {
                jcglcheckBox.Checked = true;
            }
            if (model.spgl)
            {
                spglcheckBox.Checked = true;
            }
            if (model.tjbb)
            {
                tjbbcheckBox.Checked = true;
            }
            if (model.dxgl)
            {
                dxglcheckBox.Checked = true;
            }
            if (model.tcgl)
            {
                tcglcheckBox.Checked = true;
            }
            if (model.glysz)
            {
                glyszcheckBox.Checked = true;
            }
            if (model.lsdsz)
            {
                lsdszcheckBox.Checked = true;
            }
            if (model.sjkgl)
            {
                sjkglcheckBox.Checked = true;
            }
            if (model.jbcs)
            {
                jbcscheckBox.Checked = true;
            }
            if (model.qtfw)
            {
                qtcheckBox.Checked = true;
            }
            if (model.flgl)
            {
                flcheckBox.Checked = true;
            }
            if (model.yggl)
            {
                ygcheckBox.Checked = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择一行数据！");               
                return;
            }
            MODEL.LoginUser model1 = (MODEL.LoginUser)dataGridView1.SelectedRows[0].DataBoundItem;
            int id = model1.ID;
            if (textBox2.Text != textBox3.Text)
            {
                MessageBox.Show("两次密码不一致！");
                return;
            }
            MODEL.LoginUser model = new MODEL.LoginUser();
            model.UserName = comboBox1.Text;
            model.LoginName = textBox1.Text.Trim();
            model.UserPwd = textBox2.Text.Trim();
            if (shglcheckBox.Checked)
            {
                model.shgl = true;
            }
            if (hyglcheckBox.Checked)
            {
                model.hygl = true;
            }
            if (jcsjcheckBox.Checked)
            {
                model.jcsj = true;
            }
            if (jcglcheckBox.Checked)
            {
                model.jcgl = true;
            }
            if (spglcheckBox.Checked)
            {
                model.spgl = true;
            }
            if (tjbbcheckBox.Checked)
            {
                model.tjbb = true;
            }
            if (dxglcheckBox.Checked)
            {
                model.dxgl = true;
            }
            if (tcglcheckBox.Checked)
            {
                model.tcgl = true;
            }
            if (glyszcheckBox.Checked)
            {
                model.glysz = true;
            }
            if (lsdszcheckBox.Checked)
            {
                model.lsdsz = true;
            }
            if (sjkglcheckBox.Checked)
            {
                model.sjkgl = true;
            }
            if (jbcscheckBox.Checked)
            {
                model.jbcs = true;
            }
            if (qtcheckBox.Checked)
            {
                model.qtfw = true;
            }
            if (flcheckBox.Checked)
            {
                model.flgl = true;
            }
            if (ygcheckBox.Checked)
            {
                model.yggl = true;
            }
            model.ID = id;
            bool result = logbll.UpdateIteam(model);
            if (result)
            {
                MessageBox.Show("修改成功!");
                databind(comboBox1.Text.Trim());
                return;
            }
            MessageBox.Show("修改失败!");
        }
    }
}
