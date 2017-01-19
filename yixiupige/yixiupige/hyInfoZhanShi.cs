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
    public partial class hyInfoZhanShi : Form
    {
        public hyInfoZhanShi()
        {
            InitializeComponent();
        }
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
        }
        public void dataBind()
        {
            dataGridView2.DataSource = bll1.selectAllList(textBox2.Text.Trim());
        }
        private void hyInfoZhanShi_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }
    }
}
