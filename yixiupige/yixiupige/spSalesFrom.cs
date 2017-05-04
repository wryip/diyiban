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
    public partial class spSalesFrom : Form
    {
        public spSalesFrom()
        {
            InitializeComponent();
        }
        public delegate void AddSpModel(shInfoList model,bool result);
        public static AddSpModel dataBind;
        GoodInfoBLL goodbll = new GoodInfoBLL();
        private static spSalesFrom _danli = null;
        public static spSalesFrom CreateForm(AddSpModel databind1)
        {
            dataBind = databind1;
            if (_danli == null)
            {
                _danli = new spSalesFrom();
            }
            return _danli;
        }
        private void spSalesFrom_Load(object sender, EventArgs e)
        {
            jbcsBLL jbcsbll = new jbcsBLL();
            List<jbcs> list = jbcsbll.selectList(4);
            comboBox1.Items.Add("全部");
            foreach (var iteam in list)
            {
                comboBox1.Items.Add(iteam.AllType);
            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            databinds("全部");
        }
        public void databinds(string name)
        {
            List<GoodInfo> list = new List<GoodInfo>();
            GoodInfo gd=new GoodInfo();
            gd.Gtype=name;
            list = goodbll.Getlist(gd);
            dataGridView1.DataSource = list;
        }
        private void spSalesFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            databinds(comboBox1.Text.Trim());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                List<GoodInfo> list;
                GoodInfo gd = new GoodInfo();
                if (comboBox2.Text.Trim() == "名称")
                {
                    gd.Gname = textBox1.Text.Trim();
                }
                else
                {
                    gd.Gno = textBox1.Text.Trim();
                }
                list = goodbll.Getlist(gd);
                dataGridView1.DataSource = list;
            }
            else
            {
                List<GoodInfo> list;
                GoodInfo gd = new GoodInfo();
                if (comboBox2.Text.Trim() == "名称")
                {
                    gd.Gname = textBox1.Text.Trim();
                }
                else
                {
                    gd.Gno = textBox1.Text.Trim();
                }
                list = goodbll.GetlistJQ(gd);
                dataGridView1.DataSource = list;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //dataBind
            bool IsHuaKa = false;
            shInfoList model = new shInfoList();
            double money = 0;
            if (radioButton1.Checked)
            {
                DialogResult result = MessageBox.Show("确认赠送", "提示信息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.Cancel)
                {
                    return;
                }                
                model.CountMoney = money;            
                //赠送
            }
            else if (radioButton2.Checked)
            {
                try
                {
                    //指定单价
                    double mm = Convert.ToDouble(textBox2.Text.Trim());
                    money = Convert.ToDouble(numericUpDown2.Value) * mm;
                    model.CountMoney = money;
                }
                catch
                {
                    MessageBox.Show("单价请输入数字！");
                    return;
                }
            }
            else if (radioButton3.Checked)
            {
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show("请选择一条数据！");
                    return;
                }
                double price = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["spPrice"].Value);
                //指定折扣spPrice
                try
                {
                    int zk = Convert.ToInt32(numericUpDown1.Value);
                    money = price * Convert.ToInt32(numericUpDown2.Value) * zk / 100;
                    model.CountMoney = money;
                }
                catch
                {
                    MessageBox.Show("信息错误！");
                    return;
                }
            }
            else//直接以指定价格出售
            {
                try
                {
                    double price = Convert.ToDouble(dataGridView1.SelectedRows[0].Cells["spPrice"].Value);
                    //指定单价
                    //double mm = Convert.ToDouble(textBox2.Text.Trim());
                    money = Convert.ToDouble(numericUpDown2.Value) * price;
                    model.CountMoney = money;
                }
                catch
                {
                    MessageBox.Show("单价请输入数字！");
                    return;
                }
            }
            model.JiCun = false;
            model.FuWuName = "购买商品[" + dataGridView1.SelectedRows[0].Cells["spName"].Value.ToString().Trim() + "]";
            model.YMoney = 0;
            model.FuKuan = false;
            model.Count = Convert.ToInt32(numericUpDown2.Value);
            model.Type = dataGridView1.SelectedRows[0].Cells["spType"].Value.ToString();
            model.CiCount = 0;
            model.PaiNumber = "";
            model.CJQuestion = "";
            model.Remark = "";
            model.PinPai = "";
            model.Color = "";
            model.ImgUrl = dataGridView1.SelectedRows[0].Cells["Gid"].Value.ToString();
            model.YMPerson = "";
            //model.TCMoney = Convert.ToDouble(textBox3.Text.Trim() == "" ? "0" : textBox3.Text.Trim());
            if (radioButton1.Checked)
            {
                //赠送
            }
            else 
            {
                DialogResult huaka = MessageBox.Show("是否划卡？（划卡即消费用户的卡里的余额，否则用户支付现金。）", "提示信息", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                IsHuaKa = true;
                if (huaka == DialogResult.No)
                {
                    model.YMoney = money;
                    IsHuaKa = false;
                }
                else if (huaka == DialogResult.Cancel)
                {
                    return;
                }
            }
            dataBind(model, IsHuaKa);
            this.Close();
        }
    }
}
