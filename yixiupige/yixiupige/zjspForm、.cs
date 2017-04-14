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
            jbcsBLL jbcsbll = new jbcsBLL();
            List<jbcs> list=jbcsbll.selectList(4);
            foreach(var iteam in list)
            {
                typetextBox.Items.Add(iteam.AllType);
            }            
            GoodInfo gd=null;
            string numno = (1 + gdbll.getNumber()).ToString();
            int lenth = numno.Length;
            for (int i = 0; i < (4 - lenth); i++)
            {
                numno = "0" + numno;
            }
            notextBox.Text = numno;
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
                this.Close();
            }
            else {
                MessageBox.Show("插入失败！");
            }

        }
        private void loadevent()
        {
            jbcsBLL jbcsbll = new jbcsBLL();
            typetextBox.DataSource = jbcsbll.selectList(4);
        }
      
        private void zjbutton_Click(object sender, EventArgs e)
        {
            jbcsForm jbcs = jbcsForm.Create();
            //jbcs.Loadevent += loadevent;
            jbcs.Show();
            jbcs.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void typetextBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
