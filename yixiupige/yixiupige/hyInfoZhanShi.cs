using BLL;
using Commond;
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
    public partial class hyInfoZhanShi : Form
    {
        public hyInfoZhanShi()
        {
            InitializeComponent();
        }
        LSConsumptionBLL lsbll = new LSConsumptionBLL();
        public static memberInfoModel model1;
        private static hyInfoZhanShi _danli = null;
        memberCZMoneyBLL bll1 = new memberCZMoneyBLL();
        public static hyInfoZhanShi Create(memberInfoModel model)
        {
            model1 = model;
            if (_danli == null)
            {
                _danli = new hyInfoZhanShi();
            }
            return _danli;
        }
        private void hyInfoZhanShi_Load(object sender, EventArgs e)
        {
            textBox1.Text = model1.memberName;
            textBox2.Text = model1.memberCardNo;
            textBox3.Text = model1.memberTel;
            textBox4.Text = model1.memberDocument;
            textBox5.Text = model1.birDate;
            textBox6.Text = model1.memberSex;
            textBox7.Text = model1.cardDate;
            textBox8.Text = model1.endDate;
            textBox9.Text = model1.zhuangtai;
            textBox10.Text = model1.cardType;
            textBox11.Text = model1.memberType;
            textBox12.Text = model1.toUpMoney;
            textBox13.Text = model1.dianName;
            textBox14.Text = model1.fuwuBate;
            textBox15.Text = model1.rebate;
            textBox16.Text = model1.address;
            textBox17.Text = model1.remark;
            pictureBox1.ImageLocation = model1.imageUrl;
            if (textBox10.Text.Trim() == "计次卡")
            {
                label12.Text = "剩余次数";
            }
            dataBind();
            string name = FilterClass.DianPu1.UserName;
            dataGridView1.DataSource = lsbll.selectAllList(textBox2.Text.Trim(), name);
        }
        public void dataBind()
        {
            dataGridView2.DataSource = bll1.selectAllList(textBox2.Text.Trim()).OrderByDescending(a=>a.czDate);
        }
        private void hyInfoZhanShi_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void dataGridView1_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            int i = dataGridView1.Rows.Count;
            for (int j = 0; j < i; j++)
            {
                dataGridView1.Rows[j].Selected = false;
            }
            try
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
            catch
            {
                return;
            }
        }

        private void dataGridView2_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            int i = dataGridView2.Rows.Count;
            for (int j = 0; j < i; j++)
            {
                dataGridView2.Rows[j].Selected = false;
            }
            try
            {
                dataGridView2.Rows[e.RowIndex].Selected = true;
            }
            catch
            {
                return;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridViewRowContextMenuStripNeededEventArgs ee;
                ee = new DataGridViewRowContextMenuStripNeededEventArgs(e.RowIndex);
                this.dataGridView1_RowContextMenuStripNeeded(e.Location,ee);
            }
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridViewRowContextMenuStripNeededEventArgs ee;
                ee = new DataGridViewRowContextMenuStripNeededEventArgs(e.RowIndex);
                this.dataGridView2_RowContextMenuStripNeeded(e.Location, ee);
            }
        }
    }
}
