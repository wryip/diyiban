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
    public partial class hyczForm : Form
    {
        public hyczForm()
        {
            InitializeComponent();
        }
        public memberInfoBLL bll=new memberInfoBLL();
        private static hyczForm hycz;
        public delegate void cabinddta(List<memberInfoModel> czmodel);
        public static cabinddta cabinddtacz;
        public static hyczForm Create(cabinddta model)
        {
            cabinddtacz = model;
            if (hycz==null)
            {
                hycz = new hyczForm();
            }
            return hycz;
        }
        private void hyczForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hycz = null;
        }

        private void tcbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hyczForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void qdbutton_Click(object sender, EventArgs e)
        {
            string tiaojian = comboBox1.Text.Trim();
            string neirong = textBox1.Text.Trim();
            int mouhu = 0;
            string xiaodate = "0";
            string dadate = "0";
            if (checkBox1.Checked == true)
            {
                mouhu = 1;
            }
            if (checkBox2.Checked == true)
            {
                xiaodate = dateTimePicker1.Text.Trim();
            }
            if (checkBox3.Checked == true)
            {
                dadate = dateTimePicker2.Text.Trim();
            } 
            List<memberInfoModel> list = bll.hyczModel(neirong, tiaojian, mouhu, xiaodate, dadate);
            if (list.Count() > 0)
            {
                cabinddtacz(list);
                this.Close();
            }
            else
            {
                MessageBox.Show("无结果！");
            }
        }
    }
}
