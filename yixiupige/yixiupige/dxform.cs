using BLL;
using MODEL;
using Commond;
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
    public partial class dxform : Form
    {
        public dxform()
        {
            InitializeComponent();
        }
        DXSendBLL dxsendbll = new DXSendBLL();
        memberInfoBLL infobll = new memberInfoBLL();
        private static dxform _danli = null;
        public static dxform CreateForm()
        {
            if (_danli == null)
            {
                _danli = new dxform();
            }
            return _danli;
        }
        private void dxform_Load(object sender, EventArgs e)
        {
            List<DXmemberModel> list = new List<DXmemberModel>();
            list = infobll.SelectDXList();
            databind(list);
        }
        public void databind(List<DXmemberModel> list)
        {            
            dataGridView1.DataSource = list;
        }
        private void dxform_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                dataGridView1.Rows[i].Cells[4].Value = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int count = dataGridView1.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                dataGridView1.Rows[i].Cells[4].Value = !Convert.ToBoolean(dataGridView1.Rows[i].Cells[4].Value);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddPhonNumber addinfo = AddPhonNumber.CreateForm(NumberAdd);
            addinfo.Show();
            addinfo.Focus();
        }
        public void NumberAdd(string numbers)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text += numbers;
                return;
            }
            textBox2.Text += "\r\n"+numbers;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox2.SelectedText = "";
            string[] str = textBox2.Text.Split(new string[]{"\r\n"},StringSplitOptions.RemoveEmptyEntries);
            string text = "";
            for (int i = 0; i < str.Length; i++)
            {
                text += str[i] + (i == str.Length - 1 ? "" : "\r\n"); 
            }
            textBox2.Text = text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int j=0;
            string[] stringArray = textBox2.Lines;
            string[] sourceData = stringArray;
            List<string> listString = new List<string>();
            Array.Sort(stringArray);//排序数组
            int MaxLine = stringArray.Length;
            #region 单独计算第一个
            //if (sourceData[0] != stringArray[1])
            //{
                listString.Add(stringArray[0]);
            //}
            #endregion
            for (int i = 1; i < MaxLine; i++)
            {
                if (sourceData[i] != stringArray[i - 1])
                {
                    listString.Add(stringArray[i]);
                }
            }
            string str = "";
            foreach (var iteam in listString)
            {
                str += iteam + (j == listString.Count - 1 ? "" : "\r\n");
                j++;
            }
                textBox2.Text=str;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string[] sourse;
            DXmemberModel model;
            List<DXmemberModel> list1 = new List<DXmemberModel>();
            List<string> listr = new List<string>();
            List<DXmemberModel> list = (List<DXmemberModel>)dataGridView1.DataSource;
            foreach (var iteam in list)
            {
                if (iteam.SendInfo)
                {
                    list1.Add(iteam);
                    listr.Add(iteam.TelPhone);
                }
            }
            string[] stringArray1 = listr.ToArray<string>();
            string[] stringArray = textBox2.Lines;
            if (stringArray1.Length != 0)
            {
                sourse = stringArray.Concat<string>(stringArray1).ToArray<string>();
            }
            else
            {
                sourse = stringArray;
            }
            bool result = Commond.SendInfo.Send(sourse, textBox1.Text.Trim());
            if (result)
            {
                MessageBox.Show("发送成功！");
                foreach (var iteam in sourse)
                {
                    model = new DXmemberModel();
                    model.TelPhone = iteam.Trim();
                    list1.Add(model);
                }
                dxsendbll.AddList(list1, textBox1.Text.Trim());
            }
            else
            {
                MessageBox.Show("发送失败！");
            }
        }
    }
}
