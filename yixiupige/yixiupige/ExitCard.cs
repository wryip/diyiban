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
    public partial class ExitCard : Form
    {
        public ExitCard()
        {
            InitializeComponent();
        }
        public delegate void DataBind();
        public static DataBind bind1;
        memberTypeCURD cardtype = new memberTypeCURD();
        ExitCardBLL exitbll = new ExitCardBLL();
        memberInfoBLL bll = new memberInfoBLL();
        private static ExitCard _danli = null;
        public static memberInfoModel zhanshimolde { get; set; }
        public static ExitCard CreateForm(memberInfoModel model,DataBind bind)
        {
            bind1 = bind;
            zhanshimolde = model;
            if (_danli == null)
            {
                _danli = new ExitCard();
            }
            return _danli;
        }
        private void ExitCard_Load(object sender, EventArgs e)
        {
            double bl = cardtype.selectBL(zhanshimolde.memberType.Trim());
            textBox1.Text = zhanshimolde.memberName;
            textBox2.Text = zhanshimolde.memberCardNo;
            textBox3.Text = zhanshimolde.cardMoney;
            textBox4.Text = zhanshimolde.toUpMoney;
            textBox5.Text = zhanshimolde.cardType;
            textBox6.Text = zhanshimolde.memberType;
            textBox7.Text = (Convert.ToDouble(zhanshimolde.toUpMoney.Trim()) / bl).ToString().Split(new char[]{'.'},StringSplitOptions.RemoveEmptyEntries)[0];
            
        }

        private void ExitCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            _danli = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result=bll.deleteInfoModel(zhanshimolde.ID.ToString().Trim());
            if (result)
            {
                ExitCardModel model = new ExitCardModel();
                model.CardMoney = textBox7.Text.Trim();
                model.CardType = zhanshimolde.cardType;
                model.memberName = zhanshimolde.memberName;
                model.DateTimeCard = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                model.saleMen = FilterClass.DianPu1.LoginName;
                result = exitbll.ExitCard(model);
                if (result)
                {
                    MessageBox.Show("退卡成功！");
                    bind1();
                    this.Close();
                    return;
                }
            }
            MessageBox.Show("失败，请稍后再试！");
        }
    }
}
