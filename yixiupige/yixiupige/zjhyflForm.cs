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
        public delegate void zhixingbind();
        public static zhixingbind fangfa;
        public zjhyflForm()
        {
            InitializeComponent();
        }
        private static zjhyflForm zjhyfl;
        public static zjhyflForm Create(zhixingbind fangfa1)
        {
            fangfa = fangfa1;
            if (zjhyfl==null)
            {
                zjhyfl = new zjhyflForm();
            }
            return zjhyfl;
        }
        private void zjhyflForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            fangfa();
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
                user.memberName = hymctextBox.Text.Trim();
                user.memberTypechild = splxcomboBox.SelectedItem.ToString();
                user.memberCardMoney = bkjetextBox.Text.Trim();
                user.memberRebate = spzktextBox.Text.Trim();
                user.memberTopUp = czcstextBox.Text.Trim();
                user.memberSend = Convert.ToDouble(Convert.ToDouble(bkjetextBox.Text.Trim()) / Convert.ToInt32(czcstextBox.Text.Trim()));
                memberTypeCURD memberType = new memberTypeCURD();
                bool result=memberType.AddMember(user);
                if (result)
                {
                    MessageBox.Show("添加成功！");
                    this.Close();
                }
            }
        }

        private void zjhyflForm_Load(object sender, EventArgs e)
        {
            splxcomboBox.SelectedItem = "计次卡";
            label5.Text = "充值次数：";
        }
    }
}
