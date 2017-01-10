using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODEL;
using BLL;

namespace yixiupige
{
    public partial class zjhyflForm : Form
    {
        public zjhyflForm()
        {
            InitializeComponent();
        }
        private static zjhyflForm zjhyfl;
        public static zjhyflForm Create()
        {
            if (zjhyfl==null)
            {
                zjhyfl = new zjhyflForm();
            }
            return zjhyfl;
        }
        private void zjhyflForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            zjhyfl = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void splxcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (splxcomboBox.SelectedItem.ToString() == "计次卡")
            {
                label5.Text = "充值次数：";
                spzktextBox.Text = "100";
                spzktextBox.ReadOnly = true;
            }
            else if (splxcomboBox.SelectedItem.ToString() == "折扣卡")
            {
                label5.Text = "充值金额：";
                spzktextBox.Text = "100";
                spzktextBox.ReadOnly = false;
            }
            else
            {
                label5.Text = "充值金额：";
                spzktextBox.Text = "100";
                spzktextBox.ReadOnly = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hymctextBox.Text == "" || bkjetextBox.Text == "" || spzktextBox.Text == "" || czcstextBox.Text == "")
            {
                MessageBox.Show("信息不能为空！");
            }
            else
            {
                memberType user = new memberType();
                user.Name = hymctextBox.Text.Trim();
                user.Type = splxcomboBox.SelectedItem.ToString();
                user.CardMoney = bkjetextBox.Text.Trim();
                user.Rebate = spzktextBox.Text.Trim();
                user.TopUp = czcstextBox.Text.Trim();
                memberTypeCURD memberType = new memberTypeCURD();
                bool result=memberType.AddMember(user);
            }
        }

        private void zjhyflForm_Load(object sender, EventArgs e)
        {
            splxcomboBox.SelectedItem = "计次卡";
            label5.Text = "充值次数：";
            spzktextBox.Text = "100";
            spzktextBox.ReadOnly = true;
        }
    }
}
