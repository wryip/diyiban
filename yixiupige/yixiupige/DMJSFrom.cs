using BLL;
using Commond;
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
    public partial class DMJSFrom : Form
    {
        public DMJSFrom()
        {
            InitializeComponent();
        }
        TJBBBLL tjbb = new TJBBBLL();
        JCInfoBLL bll = new JCInfoBLL();
        private static DMJSFrom _danli = null;
        public static DMJSFrom CreateForm()
        {
            if (_danli == null)
            {
                _danli = new DMJSFrom();
            }
            return _danli;
        }
        private void DMJSFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void DMJSFrom_Load(object sender, EventArgs e)
        {
            datagridviewbind();
        }

        private void datagridviewbind()
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            list = bll.selectFinishJC(FilterClass.DianPu1.UserName);
            dataGridView3.DataSource = list;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !Convert.ToBoolean(dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            datagridviewbind();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow iteam in dataGridView3.Rows)
            {
                iteam.Cells["XZ"].Value = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<JCInfoModel> jclist = new List<JCInfoModel>();
            List<int> list = new List<int>();
            foreach (DataGridViewRow iteam in dataGridView3.Rows)
            {
                if (Convert.ToBoolean(iteam.Cells["XZ"].Value))
                {
                    list.Add(Convert.ToInt32(iteam.Cells["jcID"].Value));
                    jclist.Add(iteam.DataBoundItem as JCInfoModel);
                }
            }
            if (list.Count <= 0)
            {
                MessageBox.Show("请选择数据！");
                return;
            }
            bool result = bll.UpdateEnd(list);
            if (result)
            {
                tjbb.InDP(list);
                MessageBox.Show("成功！");
                datagridviewbind();
                PirentDocumentClass.SendWuLiu(jclist, "店面接收");
                return;
            }
            MessageBox.Show("失败，请稍后再试！！");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "")
            {
                //请输入数据
                MessageBox.Show("请输入数据！");
                return;
            }
            List<JCInfoModel> list = new List<JCInfoModel>();
            list = bll.SelectTM(textBox1.Text.Trim());
            dataGridView3.DataSource = list;
            if (dataGridView3.Rows.Count == 1)
            {
                dataGridView3.Rows[0].Cells["XZ"].Value = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<int> list = new List<int>();
            foreach (DataGridViewRow iteam in dataGridView3.Rows)
            {
                if (Convert.ToBoolean(iteam.Cells["XZ"].Value))
                {
                    list.Add(Convert.ToInt32(iteam.Cells["jcID"].Value));
                }
            }
            if (list.Count <= 0)
            {
                MessageBox.Show("请选择数据！");
                return;
            }
            bool result = bll.UpdateEndSend(list);
            if (result)
            {
                tjbb.AgainSend(list);
                MessageBox.Show("成功！");
                datagridviewbind();
                return;
            }
            MessageBox.Show("失败，请稍后再试！！");
        }
    }
}
