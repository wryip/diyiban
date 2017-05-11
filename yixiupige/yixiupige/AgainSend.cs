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
    public partial class AgainSend : Form
    {
        public AgainSend()
        {
            InitializeComponent();
        }
        TJBBBLL tjbb = new TJBBBLL();
        JCInfoBLL bll = new JCInfoBLL();
        private static AgainSend _danli = null;
        public static AgainSend CreateForm()
        {
            if (_danli == null)
            {
                _danli = new AgainSend();
            }
            return _danli;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "全选")
            {
                button1.Text = "取消";
                foreach (DataGridViewRow iteam in dataGridView3.Rows)
                {
                    iteam.Cells["XZ"].Value = true;
                }
            }
            else
            {
                button1.Text = "全选";
                foreach (DataGridViewRow iteam in dataGridView3.Rows)
                {
                    iteam.Cells["XZ"].Value = false;
                }
            }
            numberAdd();
        }
        private void numberAdd()
        {
            int count = 0;
            foreach (DataGridViewRow iteam in dataGridView3.Rows)
            {
                if (Convert.ToBoolean(iteam.Cells["XZ"].Value))
                {
                    count++;
                }
            }
            label1.Text = count.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
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
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string tmnum = textBox1.Text.Trim();
            if (tmnum == "")
            {
                MessageBox.Show("请输入数据！");
                return;
            }
            List<JCInfoModel> list = new List<JCInfoModel>();
            list = bll.SelectTM(tmnum);
            if (list.Count > 0)
            {
                //此处添加提示音效
                SuccessInfo.Success();
                datagr1add(list);
            }
            else
            {
                MessageBox.Show("失败！");
            }
            textBox1.Text = "";
        }
        private void datagr1add(List<JCInfoModel> list)
        {
            if (dataGridView3.Rows.Count == 0)
            {
                dataGridView3.DataSource = list;
            }
            else
            {
                foreach (DataGridViewRow iteam in dataGridView3.Rows)
                {
                    list.Add((JCInfoModel)iteam.DataBoundItem);
                }
                dataGridView3.DataSource = list;
            }
        }

        private void AgainSend_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !Convert.ToBoolean(dataGridView3.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);
                numberAdd();
            }
        }
    }
}
