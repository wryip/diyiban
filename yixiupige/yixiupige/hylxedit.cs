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
    public partial class hylxedit : Form
    {
        public delegate void editup();
        public static editup editsuccess;
        public static memberType edit1 = new memberType();
        public hylxedit()
        {
            InitializeComponent();
        }
        private static hylxedit hyfl;
        public static hylxedit Create(memberType edit,editup ss)
        {
            edit1 = edit;
            editsuccess = ss;
            if (hyfl == null)
            {
                hyfl = new hylxedit();
            }
            return hyfl;
        }
        private void hylxedit_Load(object sender, EventArgs e)
        {
            hymctextBox.Text = edit1.memberName.Trim();
            hymctextBox.ReadOnly = true;
            if (edit1.memberTypechild.Trim() == "计次卡")
            {
                splxcomboBox.SelectedIndex = 0;
                spzktextBox.Text = "100";
                spzktextBox.ReadOnly = true;
            }
            else if (edit1.memberTypechild.Trim() == "折扣卡")
            {
                splxcomboBox.SelectedIndex = 1;
                spzktextBox.ReadOnly = false;
                spzktextBox.Text = edit1.memberRebate.Trim();
            }
            else 
            {
                splxcomboBox.SelectedIndex = 2;
                spzktextBox.ReadOnly = false;
                spzktextBox.Text = edit1.memberRebate.Trim();
            }
            bkjetextBox.Text = edit1.memberCardMoney.Trim();
            czcstextBox.Text = edit1.memberTopUp.Trim();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hylxedit_FormClosed(object sender, FormClosedEventArgs e)
        {
            hyfl = null;
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
            memberType user = new memberType();
            user.memberName = hymctextBox.Text.Trim();
            user.memberTypechild = splxcomboBox.SelectedItem.ToString();
            user.memberCardMoney = bkjetextBox.Text.Trim();
            user.memberRebate = spzktextBox.Text.Trim();
            user.memberTopUp = czcstextBox.Text.Trim();
            memberTypeCURD memberType = new memberTypeCURD();
            bool result = memberType.EditMemberUp(user);
            if (result)
            {
                MessageBox.Show("修改成功！");
                editsuccess();
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败！");
                editsuccess();
                this.Close();
            }
        }
    }
}
