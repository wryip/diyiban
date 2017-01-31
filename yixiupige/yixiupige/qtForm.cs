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
    public partial class qtForm : Form
    {
        public qtForm()
        {
            InitializeComponent();
        }
        QtFuWuBLL bll = new QtFuWuBLL();
        private static qtForm qt;
        public static qtForm Create()
        {
            if (qt==null)
            {
                qt = new qtForm();
            }
            return qt;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void qtForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            qt = null;
        }

        private void qtForm_Load(object sender, EventArgs e)
        {
            databind();
        }
        public void databind()
        {
            List<qtFuWuModel> list = new List<qtFuWuModel>();
            list = bll.SelectAllList();
            dataGridView1.DataSource = list;
            groupBox1.Text = "其他服务列表-有" + dataGridView1.Rows.Count + "条";
        }

        private void zjbutton_Click(object sender, EventArgs e)
        {
            addQtFuWu addqt = addQtFuWu.Create(databind);
            addqt.Show();
            addqt.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一条数据！");
                return;
            }
            qtFuWuModel model = (qtFuWuModel)dataGridView1.SelectedRows[0].DataBoundItem;
            EditQtFuWu qtedit = EditQtFuWu.Create(databind, model);
            qtedit.Show();
            qtedit.Focus();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一条数据！");
                return;
            }
            bool result=bll.deleteModel(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            if (result)
            {
                MessageBox.Show("删除成功！");
                databind();
                return;
            }
            MessageBox.Show("错误！请稍后再试！");
        }
    }
}
