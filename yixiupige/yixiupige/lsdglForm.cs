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
    public partial class lsdglForm : Form
    {
        public lsdglForm()
        {
            InitializeComponent();
        }
        DPInfoBLL dpbll = new DPInfoBLL();
        private static lsdglForm lsdgl;
        //单例模式
        public static lsdglForm Create()
        {
            if (lsdgl == null)
            {
                lsdgl = new lsdglForm();
            }
            return lsdgl;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lsdzjForm lsdzj = lsdzjForm.Create(databind);
            lsdzj.Show();
            lsdzj.Focus();
        }

        private void lsdglForm_Load(object sender, EventArgs e)
        {
            databind();
            label2.Text="店铺记录有"+dataGridView1.RowCount+"条";
        }
        public void databind()
        {
            List<DianPu> list = new List<DianPu>();
            list = dpbll.selectAllList();
            dataGridView1.DataSource = list;
        }
        private void lsdglForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            lsdgl = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一条数据！");
                return;
            }
            DianPu model = new DianPu();
            model = (DianPu)dataGridView1.SelectedRows[0].DataBoundItem;
            DPUpdateFrom lsdzj = DPUpdateFrom.Create(databind, model);
            lsdzj.Show();
            lsdzj.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一条数据！");
                return;
            }
            var btnresult = MessageBox.Show("确认删除？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
            if (btnresult == DialogResult.OK)
            {
                DianPu model = new DianPu();
                model = (DianPu)dataGridView1.SelectedRows[0].DataBoundItem;
                bool result = dpbll.deleteIteam(model.ID);
                if (result)
                {
                    MessageBox.Show("删除成功！");
                    databind();
                    return;
                }
                MessageBox.Show("删除失败！");
            }          
        }
    }
}
