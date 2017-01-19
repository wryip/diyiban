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
    public partial class spbhForm : Form
    {
        public spbhForm()
        {
            InitializeComponent();
        }
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
            nametextBox.Text = gds.Gname.ToString();
            notextBox.Text = gds.Gno.ToString();
            pricetextBox.Text = gds.Gprice.ToString();
            bidtextBox.Text = gds.Gbid.ToString();
            remarktextBox.Text = gds.Gremark.ToString();
            typetextBox.Text = gds.Gtype.ToString();
            sumtextBox.Text = gds.Gsum.ToString();
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
                Gsum = Convert.ToInt32(sumtextBox.Text)

            };
            if (gdbll.Adds(Convert.ToInt32(addtextBox.Text), gd))
            {
                sp._load();
                Loadevent();
                MessageBox.Show("补货成功！");
            }
        }

    }
}
