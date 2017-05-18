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
    public partial class ygglForm : Form
    {
        public ygglForm()
        {
            InitializeComponent();
        }
        staffInfoBLL staffbll = new staffInfoBLL();
        private static ygglForm yggl;
        public static ygglForm Create()
        {
            if (yggl==null)
            {
                yggl = new ygglForm();
            }
            return yggl;
        }
       

        private void ygglForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            yggl = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zjbutton_Click(object sender, EventArgs e)
        {
            ygzjForm zjhy = ygzjForm.Create(databind);
            zjhy.Show();
            zjhy.Focus();
        }
        public void databind()
        {
            dataGridView1.DataSource = staffbll.selectAllList();
        }

        private void ygglForm_Load(object sender, EventArgs e)
        {
            databind();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                dataGridView1.Rows[i].Selected = false;
            }
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void xgbutton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一条数据！");
                return;
            }
            staffTable model = (staffTable)dataGridView1.SelectedRows[0].DataBoundItem;
            hyxgFrom hyxg = hyxgFrom.Create(model, databind);
            hyxg.Show();
            hyxg.Focus();
        }

        private void scbutton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一条数据！");
                return;
            }
            staffTable model = (staffTable)dataGridView1.SelectedRows[0].DataBoundItem;
            bool result = staffbll.deleteIteam(model.Id);
            if (result)
            {
                MessageBox.Show("删除成功！");
                databind();
                return;
            }
            MessageBox.Show("删除失败！");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
