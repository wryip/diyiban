using BLL;
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
    public partial class jbcsForm : Form
    {
        public jbcsForm()
        {
            InitializeComponent();
        }

        private static jbcsForm jbcs;
        public jbcsBLL bll = new jbcsBLL();
        public static jbcsForm Create()
        {
            if (jbcs==null)
            {
                jbcs = new jbcsForm();
            }
            return jbcs;
        }
        private void button1_Click(object sender, EventArgs e)
        {

            jbcszjForm jbcszj = jbcszjForm.Create(dataBind);
            jbcszj.Text = listBox1.SelectedItem.ToString();
            jbcszj.Show();
            jbcszj.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jbcsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            jbcs = null;
        }

        private void jbcsForm_Load(object sender, EventArgs e)
        {
            listBox1.SelectedIndex = 0;
            //int index = listBox1.SelectedIndex;
            dataBind();
        }
        public void dataBind()
        {
            dataGridView1.DataSource = bll.selectList(listBox1.SelectedIndex+1);
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataBind();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string neirong="";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show("请选择一条数据！");
                    return;
                }
                neirong = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
            }
            else if (dataGridView1.SelectedCells.Count > 0)
            {
                if (dataGridView1.SelectedCells.Count != 1)
                {
                    MessageBox.Show("请选择一条数据！");
                    return;
                }
                neirong = dataGridView1.SelectedCells[0].Value.ToString();
            }
            else
            {
                MessageBox.Show("请选择要修改的数据！");
                return;
            }
            jbcsxgFrom jbcsxg = jbcsxgFrom.Create(dataBind,neirong);
            jbcsxg.Text = listBox1.SelectedItem.ToString();
            jbcsxg.Show();
            jbcsxg.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string neirong = "";
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (dataGridView1.SelectedRows.Count != 1)
                {
                    MessageBox.Show("请选择一条数据！");
                    return;
                }
                neirong = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
            }
            else if (dataGridView1.SelectedCells.Count > 0)
            {
                if (dataGridView1.SelectedCells.Count != 1)
                {
                    MessageBox.Show("请选择一条数据！");
                    return;
                }
                neirong = dataGridView1.SelectedCells[0].Value.ToString();
            }
            else
            {
                MessageBox.Show("请选择要修改的数据！");
                return;
            }
            bool result = bll.seleteIteam(neirong);
        }
       
       
    }
}
