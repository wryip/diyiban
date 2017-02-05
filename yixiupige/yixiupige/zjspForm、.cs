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
    public partial class zjspForm_ : Form
    {
        public zjspForm_()
        {
            InitializeComponent();
        }
        private static zjspForm_ zjsp;
        public static zjspForm_ Create()
        {
            if (zjsp == null)
            {
                zjsp = new zjspForm_();
            }
            return zjsp;
        }
        GoodInfoBLL gdbll = new GoodInfoBLL();
        spform sp = new spform();
        private void zjspForm__Load(object sender, EventArgs e)
        {
            GoodTypeInfoBll dtbll = new GoodTypeInfoBll();
            typetextBox.DataSource = dtbll.SelecNode();
            GoodInfo gd=null;
            notextBox.Text = (10000 + gdbll.Getlist(gd).Count).ToString();
        }
      
        private void zjspForm__FormClosed(object sender, FormClosedEventArgs e)
        {
            zjsp = null;
        }
        public event Action Loadevent;
        private void button1_Click(object sender, EventArgs e)
        {
            GoodInfo gd = new GoodInfo()
            {
                Gname = nametextBox.Text.ToString(),
                Gno = notextBox.Text.ToString(),
                Gprice = Convert.ToDecimal(pricetextBox.Text),
                Gbid = Convert.ToDecimal(bidtextBox.Text),
                Gremark = remarktextBox.Text.ToString(),
                Gsum = Convert.ToInt32(sumtextBox.Text),
                Gstock = Convert.ToInt32(sumtextBox.Text),
                Gtype = typetextBox.Text.ToString()
            };
            if (gdbll.Add(gd))
            {
                sp._load();
                Loadevent();
                MessageBox.Show("插入成功");
            }
            else {
                MessageBox.Show("插入失败！");
            }

        }

        private void zjbutton_Click(object sender, EventArgs e)
        {
            jbcsForm jbcs = jbcsForm.Create();
            jbcs.Show();
            jbcs.Focus();
        }
    }
}
