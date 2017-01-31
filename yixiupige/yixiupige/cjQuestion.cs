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
    public partial class cjQuestion : Form
    {
        public cjQuestion()
        {
            InitializeComponent();
        }
        public delegate void datatext(string name);
        public static datatext action1;
        jbcsBLL fuwubl = new jbcsBLL();
        private static cjQuestion _danli = null;
        public static cjQuestion CreateForm(datatext act)
        {
            action1 = act;
            if (_danli == null)
            {
                _danli = new cjQuestion();
            }
            return _danli;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            jbcsForm jbcs = jbcsForm.Create();
            jbcs.Show();
            jbcs.Focus();
        }

        private void cjQuestion_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void cjQuestion_Load(object sender, EventArgs e)
        {
            List<jbcs> list = new List<jbcs>();
            list = fuwubl.selectList(3);
            tableLayoutPanel1.Height = (list.Count + 1) * 40;
            //double rows = Math.Ceiling(list.Count*1.0/4);
            //int row = Convert.ToInt32(rows);
            CheckBox chek;
            RowStyle rowsty = new RowStyle(SizeType.Absolute, 40); ;
            //for (int i = 0; i < row; i++)
            //{
            int jishu = 0;
            foreach (var iteam in list)
            {
                chek = new CheckBox();
                //chek.CheckedChanged += new EventHandler(CheckedChanged);
                chek.Text = iteam.AllType;
                rowsty = new RowStyle(SizeType.Absolute, 40);
                tableLayoutPanel1.Controls.Add(chek, jishu, tableLayoutPanel1.RowStyles.Count - 1);
                jishu++;
                if (jishu == 4)
                {
                    tableLayoutPanel1.RowStyles.Add(rowsty);
                    jishu = 0;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //tb = tableLayoutPanel1.GetControlFromPosition(1, i) as TextBox;
            int rows = tableLayoutPanel1.RowStyles.Count;
            CheckBox check;
            string name = "";
            for (int i = 0; i < rows; i++)
            {
                //int jishu = 0;
                for (int j = 0; i < 4; j++)
                {
                    check = tableLayoutPanel1.GetControlFromPosition(j, i) as CheckBox;
                    if (check == null)
                    {
                        break;
                    }
                    if (check.Checked == true)
                    {
                        name += check.Text.Trim() + ",";
                    }
                }
            }
            if (name == "")
            {
                MessageBox.Show("请选择服务！");
                return;
            }
            action1(name);
            this.Close();
        }
    }
}
