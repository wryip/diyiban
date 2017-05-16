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
    public partial class jbfuCheckBoxFrom : Form
    {
        public jbfuCheckBoxFrom()
        {
            InitializeComponent();
        }
        fuwuBLL fuwubl = new fuwuBLL();
        public delegate void TiJiao(string model);
        public static TiJiao action;
        private static jbfuCheckBoxFrom _danli = null;
        public static jbfuCheckBoxFrom CreateForm(TiJiao action1)
        {
            action = action1;
            if (_danli == null)
            {
                _danli = new jbfuCheckBoxFrom();
            }
            return _danli;
        }
        private void jbfuCheckBoxFrom_Load(object sender, EventArgs e)
        {
            List<fuwuModel> list = new List<fuwuModel>();
            list = fuwubl.selectAllList();
            tableLayoutPanel1.Height = (list.Count + 1) * 40;
            //double rows = Math.Ceiling(list.Count*1.0/4);
            //int row = Convert.ToInt32(rows);
            CheckBox chek;
            RowStyle rowsty = new RowStyle(SizeType.Absolute, 40); 
            //for (int i = 0; i < row; i++)
            //{
                int jishu=0;               
                foreach (var iteam in list)
                {
                    chek = new CheckBox();
                    chek.Text = iteam.Name;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jbfuCheckBoxFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            hyflglfwForm hyflgl = hyflglfwForm.Create();
            hyflgl.Show();
            hyflgl.Focus();
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
            action(name);
            this.Close();
        }
    }
}
