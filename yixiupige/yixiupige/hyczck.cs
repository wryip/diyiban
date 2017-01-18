﻿using BLL;
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
    public partial class hyczck : Form
    {
        public hyczck()
        {
            InitializeComponent();
        }
        private static hyczck _danli = null;
        public static memberInfoModel model1;
        public static hyczck Create(memberInfoModel model)
        {
            model1 = model;
            if (_danli == null)
            {
                _danli = new hyczck();
            }
            return _danli;
        }
        private void hyczck_Load(object sender, EventArgs e)
        {
            if (model1.cardType == "计次卡")
            {
                label2.Text = "剩余次数";
                label3.Text = "充值次数";
            }
            textBox1.Text = model1.memberName;
            textBox2.Text = model1.toUpMoney;
            textBox3.Text = model1.cardMoney;
            textBox4.Text = model1.memberCardNo;
            textBox5.Text = model1.fuwuBate;
            textBox6.Text = model1.cardMoney;
            textBox7.Text = model1.memberTel;
            textBox8.Text = model1.rebate;
            textBox9.Text = model1.cardType;
            textBox10.Text = model1.cardDate;
            textBox11.Text = model1.remark;
            textBox12.Text = model1.memberType;
            comboBox1.Text = model1.saleMan;
            dataBind();
        }

        private void hyczck_FormClosed(object sender, FormClosedEventArgs e)
        {
            _danli = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        memberCZMoneyBLL bll1 = new memberCZMoneyBLL();
        private void button2_Click(object sender, EventArgs e)
        {
            memberInfoBLL bll = new memberInfoBLL();            
            memberToUpModel model = new memberToUpModel();
            bool result=false;
            bool result1 = false;
            if (textBox9.Text.Trim() == "计次卡")
            {
                model.czMoney = "0";
                model.czyMoney = "0";
                model.czCount = textBox3.Text.Trim();
                model.czyCount = textBox2.Text.Trim();
            }
            else if (textBox9.Text.Trim() == "储值卡")
            {
                model.czCount = "0";
                model.czyCount = "0";
                model.czMoney = textBox3.Text.Trim();
                model.czyMoney = textBox2.Text.Trim();
            }
            model.czNo = textBox4.Text.Trim();
            model.czName = textBox1.Text;
            model.czType = textBox12.Text;
            model.czDate = DateTime.Now.ToString();
            model.czSaleman = comboBox1.Text;
            int m1 = Convert.ToInt32(textBox3.Text.Trim());
            int m2 = Convert.ToInt32(textBox2.Text.Trim());
            int m3 = m1 + m2;
            result = bll.hyczMoney(textBox4.Text.Trim(), m3);
            result1 = bll1.addModel(model);
            if (result1 && result1)
            {
                MessageBox.Show("充值成功！");
                this.Close();
            }
            else 
            {
                MessageBox.Show("出现错误！");
            }
        }
        public void dataBind()
        {
            dataGridView1.DataSource = bll1.selectAllList(textBox4.Text.Trim());
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (model1.cardType == "计次卡")
            {
                textBox3.Text = (Convert.ToInt32(textBox6.Text) * Convert.ToInt32(model1.cardMoney) / Convert.ToInt32(model1.toUpMoney)).ToString();
            }
            else
            {
                textBox3.Text = textBox6.Text;
            }            
        }
    }
}
