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
    public partial class xgspFrom : Form
    {
        public xgspFrom()
        {
            InitializeComponent();
        }

        private static xgspFrom xg;
        public static xgspFrom Create()
        {
            
            if (xg == null)
            {
                xg = new xgspFrom();
            }
            return xg;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        GoodInfoBLL gdbll = new GoodInfoBLL();
        public  void Add(GoodInfo gd)
        {

            List<GoodInfo> list = gdbll.Getlist(gd);
            GoodInfo gds = list[0];
            nametextBox.Text = gds.Gname.ToString();
            notextBox.Text = gds.Gno.ToString();
            pricetextBox.Text = gds.Gprice.ToString();
            bidtextBox.Text = gds.Gbid.ToString();
            remarktextBox.Text = gds.Gremark.ToString();
            typetextBox.Text = gds.Gtype.ToString();
        }
        spform sp = new spform();
        public event Action Loadevent;
        private void button1_Click(object sender, EventArgs e)
        {
          
            GoodInfo gd = new GoodInfo()
            {
               
                Gno = notextBox.Text.ToString(),
               Gname=nametextBox.Text.ToString(),
               Gbid=Convert.ToDecimal(bidtextBox.Text),
               Gprice=Convert.ToDecimal(pricetextBox.Text),
               Gtype=typetextBox.Text.ToString(),
               Gremark=remarktextBox.Text.ToString()
               

            };
            if (gdbll.Alter(gd))
            {
                sp._load();
                Loadevent();
                MessageBox.Show("修改成功！");
            }
        }

        private void xgspFrom_Load(object sender, EventArgs e)
        {
            GoodTypeInfoBll gtbll=new GoodTypeInfoBll();
            typetextBox.DataSource = gtbll.SelecNode();
        }

        private void xgspFrom_FormClosed(object sender, FormClosedEventArgs e)
        {
            xg =null;
        }
    }
}
