﻿using BLL;
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
    public partial class jcSelectFrom : Form
    {
        public jcSelectFrom()
        {
            InitializeComponent();
        }
        JCInfoBLL jcbll = new JCInfoBLL();
        public delegate void databind(List<JCInfoModel> list);
        public static databind databind1;
        private static jcSelectFrom _danli = null;
        public static jcSelectFrom CreateForm(databind bind)
        {
            databind1 = bind;
            if (_danli == null)
            {
                _danli = new jcSelectFrom();
            }
            return _danli;
        }
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox3.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                radioButton1.Enabled = false;
                radioButton2.Enabled = false;
                return;
            }
            dateTimePicker1.Enabled = true;
            dateTimePicker2.Enabled = true;
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton1.Checked = true;
        }

        private void jcSelectFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void jcSelectFrom_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            //初始化日期查找内的选项均不可用
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //判断是日期查找还是普通查找
            List<JCInfoModel> list = new List<JCInfoModel>();
            if (checkBox3.Checked)
            {
                //日期查找
                string date = "";
                string date1 = "";
                bool BeginOrEnd = false;//判断是寄存日期还是取走日期默认false为寄存日期的查找
                if (radioButton1.Checked)//选择为寄存日期
                {
                    BeginOrEnd = false;
                    date = TimeGuiGe.TimePicterBegin(dateTimePicker1.Text);
                    date1 = TimeGuiGe.TimePicterEng(dateTimePicker1.Text);
                    list = jcbll.jcDateSelect(date,date1, BeginOrEnd);
                    databind1(list);
                    this.Close();
                    return;
                }
                BeginOrEnd = true;
                date = TimeGuiGe.TimePicterBegin(dateTimePicker2.Text);
                date1 = TimeGuiGe.TimePicterEng(dateTimePicker2.Text);
                list = jcbll.jcDateSelect(date,date1, BeginOrEnd);
                databind1(list);
                this.Close();
                return;
            }
            //普通查找
            bool mohu = checkBox4.Checked;
            bool jc = checkBox1.Checked;
            bool qz = checkBox2.Checked;
            string type = comboBox1.Text.ToString().Trim(); ;
            string neirong = textBox1.Text.Trim();
            list = jcbll.jcContentSelect(mohu,jc,qz,type,neirong);
            databind1(list);
            this.Close();
        }
    }
}
