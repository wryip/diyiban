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
    public partial class hyczck : Form
    {
        public hyczck()
        {
            InitializeComponent();
        }
        public static double InfoBL { get; set; }
        public static List<memberToUpModel> Alllist = new List<memberToUpModel>();
        private static hyczck _danli = null;
        public static memberInfoModel model1;
        memberTypeCURD typebll = new memberTypeCURD();
        public delegate void bind1();
        public static bind1 bind;
        public static hyczck Create(memberInfoModel model,bind1 datbind)
        {
            bind = datbind;
            model1 = model;
            if (_danli == null)
            {
                _danli = new hyczck();
            }
            return _danli;
        }
        private void hyczck_Load(object sender, EventArgs e)
        {
            if (model1.cardType.Trim() == "计次卡")
            {
                label2.Text = "剩余次数";
                label3.Text = "充值次数";
            }
            textBox1.Text = model1.memberName;
            textBox2.Text = model1.toUpMoney;
            //textBox3.Text = model1.cardMoney;
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
            //去拿相应卡的充值比例
            string cardtype = textBox12.Text.Trim();
            InfoBL = typebll.selectBL(cardtype);
            textBox3.Text = (Convert.ToDouble(textBox6.Text.Trim() == "" ? "1" : textBox6.Text) * InfoBL).ToString(); 
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
                model.czMoney = textBox6.Text.Trim(); ;
                model.czyMoney = "0";
                model.czCount = textBox3.Text.Trim();
                model.czyCount = textBox2.Text.Trim();
            }
            else if (textBox9.Text.Trim() == "储值卡")
            {
                model.czCount = "0";
                model.czyCount = "0";
                model.czMoney = textBox6.Text.Trim();
                model.czyMoney = textBox2.Text.Trim();
            }
            else if (textBox9.Text.Trim() == "折扣卡")
            {
                model.czCount = "0";
                model.czyCount = "0";
                model.czMoney = textBox6.Text.Trim();
                model.czyMoney = textBox2.Text.Trim();
            }
            model.czNo = textBox4.Text.Trim();
            model.czName = textBox1.Text;
            model.czType = textBox12.Text;
            model.czDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            model.czSaleman = comboBox1.Text == "" ? FilterClass.DianPu1.LoginName : comboBox1.Text;
            double m1 = Convert.ToDouble(textBox3.Text.Trim());
            double m2 = Convert.ToDouble(textBox2.Text.Trim());
            double m3 = m1 + m2;
            result = bll.hyczMoney(textBox4.Text.Trim(), m3);
            result1 = bll1.addModel(model);
            if (result1 && result1)
            {
                MessageBox.Show("充值成功！");
                bind();
                this.Close();
            }
            else 
            {
                MessageBox.Show("出现错误！");
            }
        }
        public void dataBind()
        {
            Alllist = bll1.selectAllList(textBox4.Text.Trim());
            dataGridView1.DataSource = Alllist;
        }
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = (Convert.ToDouble(textBox6.Text.Trim() == "" ? "1" : textBox6.Text) * InfoBL).ToString();           
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

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //if (this.ContextMenuStrip != null && this.ContextMenuStripNeeded != null)
                //{
                //int rowIndex = this.GetRowIndexAt(e.Location);  // 计算行号  
                //int colIndex = this.GetColIndexAt(e.Location);  // 计算列号  this.ContextMenuStrip, rowIndex, colIndex
                DataGridViewRowContextMenuStripNeededEventArgs ee;  // 事件参数  
                ee = new DataGridViewRowContextMenuStripNeededEventArgs(1);
                this.dataGridView1_RowContextMenuStripNeeded(e.Location, ee);  // 引发自定义事件，执行事件方法  
                //}

            }
        }
        public void deletePassword(string pas, string cardNo)
        {
            if (pas.Trim() == "admin888")
            {
                memberCZMoneyBLL infobll = new memberCZMoneyBLL();
                //删除该会员
                bool result = infobll.deleteInfoModel(cardNo);
                if (result)
                {
                    MessageBox.Show("删除成功！");
                    dataBind();
                }
            }
            else
            {
                MessageBox.Show("密码错误，删除失败！");
            }
        }
        private void 删除本条_Click(object sender, EventArgs e)
        {
            memberToUpModel model = Alllist[dataGridView1.SelectedRows[0].Index];
            caocuofrom caozuo = caocuofrom.Create(deletePassword,model.czId.ToString());
            caozuo.Show();
        }
    }
}
