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
    public partial class qzjcFrom : Form
    {
        public qzjcFrom()
        {
            InitializeComponent();
        }
        public static int id = 0;
        private static qzjcFrom _danli = null;
        JCInfoBLL bll = new JCInfoBLL();
        public delegate void databind();
        public static databind databind1;
        public static qzjcFrom CreateForm(int ID,databind bind)
        {
            id = ID;
            databind1 = bind;
            if (_danli == null)
            {
                _danli = new qzjcFrom();
            }
            return _danli;
        }
        private void qzjcFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void qzjcFrom_Load(object sender, EventArgs e)
        {
            JCInfoModel model = bll.SelectID(id);
            textBox1.Text = model.jcName;
            textBox2.Text = "未上架";
            textBox3.Text = model.jcCardNumber;
            textBox4.Text = model.jcPinPai;
            textBox5.Text = model.jcPaiNumber;
            textBox6.Text = model.jcColor;
            textBox7.Text = model.jcBeginDate;
            textBox8.Text = model.jcQMoney.Trim();
            textBox9.Text = model.jcType;
            textBox10.Text = model.jcStaff;
            textBox11.Text = model.jcRemark;
            pictureBox1.ImageLocation = model.jcImgUrl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox8.Text != "0")
            {
                MessageBox.Show("还有欠款，不能取走！");
                return;
            }
            bool result = bll.QZInfo(id);
            if (result)
            {
                databind1();
                this.Close();
            }
        }
    }
}
