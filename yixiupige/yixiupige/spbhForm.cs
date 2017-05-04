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
using Commond;
namespace yixiupige
{
    public partial class spbhForm : Form
    {
        public spbhForm()
        {
            InitializeComponent();
        }
        TJBBBLL tjbbbll = new TJBBBLL();
        private static spbhForm spbh;
        public static spbhForm Create()
        {
            if (spbh == null)
            {
                spbh = new spbhForm();
            }
            return spbh;
        }
        private void spbhForm_Load(object sender, EventArgs e)
        {
             
        }
        GoodInfoBLL gdbll = new GoodInfoBLL();
        public void Add(GoodInfo gd)
        {
           List<GoodInfo> list=gdbll.Getlist(gd);
           GoodInfo gds = list[0];
            nametextBox.Text = gds.Gname.ToString().Trim();
            notextBox.Text = gds.Gno.ToString().Trim();
            pricetextBox.Text = gds.Gprice.ToString().Trim();
            bidtextBox.Text = gds.Gbid.ToString().Trim();
            remarktextBox.Text = gds.Gremark.ToString().Trim();
            typetextBox.Text = gds.Gtype.ToString().Trim();
            //目前剩余的库存
            sumtextBox.Text = gds.Gstock.ToString().Trim();
            label9.Text = gds.Gsum.ToString().Trim();
        }
        spform sp = new spform();
        public event Action Loadevent;
      
        private void spbhForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            spbh = null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
            GoodInfo gd = new GoodInfo()
            {
                Gname = nametextBox.Text.ToString(),
                Gno = notextBox.Text.ToString(),
                Gprice = Convert.ToDecimal(pricetextBox.Text),
                Gbid = Convert.ToDecimal(bidtextBox.Text),
                Gremark = remarktextBox.Text.ToString(),
                Gtype = typetextBox.Text.ToString(),
                //目前剩余的商品数量
                Gstock = Convert.ToInt32(sumtextBox.Text),
                Gsum=Convert.ToInt32(label9.Text.Trim())

            };
            if (gdbll.Adds(Convert.ToInt32(addtextBox.Text), gd))
            {
                sp._load();
                Loadevent();
                InHuoTJ jinhuo = new InHuoTJ()
                {
                    HuoCount = addtextBox.Text.Trim(),
                    HuoDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                    HuoDianName = FilterClass.DianPu1.UserName.Trim(),
                    HuoMoney = bidtextBox.Text.Trim(),
                    HuoName = nametextBox.Text.ToString().Trim(),
                    HuoNumber = notextBox.Text.ToString().Trim(),
                    HuoSale = FilterClass.DianPu1.LoginName.Trim(),
                    HuoSum = sumtextBox.Text.Trim(),
                    HuoType = typetextBox.Text.ToString().Trim()
                };
                tjbbbll.AddIteam(jinhuo);
                MessageBox.Show("补货成功！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
