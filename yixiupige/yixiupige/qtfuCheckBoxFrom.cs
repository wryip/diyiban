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
    public partial class qtfuCheckBoxFrom : Form
    {
        public qtfuCheckBoxFrom()
        {
            InitializeComponent();
        }
        public delegate void bindshuju(string name, int money,bool result);
        public static bindshuju action1;
        QtFuWuBLL fuwubl = new QtFuWuBLL();
        public static CheckBox chk;
        private static qtfuCheckBoxFrom _danli = null;
        public static qtfuCheckBoxFrom CreateForm(bindshuju act)
        {
            action1 = act;
            if (_danli == null)
            {
                _danli = new qtfuCheckBoxFrom();
            }
            return _danli;
        }
        private void qtfuCheckBoxFrom_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            list = fuwubl.selectAllName();
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
                chek.CheckedChanged += new EventHandler(CheckedChanged);
                chek.Text = iteam;
                rowsty = new RowStyle(SizeType.Absolute, 40);
                tableLayoutPanel1.Controls.Add(chek, jishu, tableLayoutPanel1.RowStyles.Count - 1);
                jishu++;
                if (jishu == 4)
                {
                    tableLayoutPanel1.RowStyles.Add(rowsty);
                    jishu = 0;
                }
            }
            //}
        }

        private void qtfuCheckBoxFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void CheckedChanged(object sender, EventArgs e)
        {
            CheckBox check = (CheckBox)sender;
            chk=check;
            if (check.Checked == true)
            {
                QtMoney qtfuwu = QtMoney.CreateForm(tragesValue);
                qtfuwu.ShowDialog();
                qtfuwu.Focus();
            }
        }
        public void tragesValue(string money)
        {
            chk.Tag = money;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            qtForm qt = qtForm.Create();
            qt.Show();
            qt.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //tb = tableLayoutPanel1.GetControlFromPosition(1, i) as TextBox;
            int rows = tableLayoutPanel1.RowStyles.Count;
            CheckBox check;
            string name = "";
            int money=0;
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
                        money += Convert.ToInt32(check.Tag);
                    }
                }
            }
            if (name == "")
            {
                MessageBox.Show("请选择服务！");
                return;
            }
            action1(name, money, checkBox1.Checked);
            this.Close();
        }
    }
}
