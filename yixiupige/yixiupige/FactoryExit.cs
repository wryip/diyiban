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
    public partial class FactoryExit : Form
    {
        public FactoryExit()
        {
            InitializeComponent();
        }
        JCInfoBLL jcbll = new JCInfoBLL();
        private static FactoryExit _danli = null;
        public static FactoryExit CreateForm()
        {
            if (_danli == null)
            {
                _danli = new FactoryExit();
            }
            return _danli;
        }
        private void FactoryExit_Load(object sender, EventArgs e)
        {
            BindData();
        }

        private void FactoryExit_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }
        private void BindData()
        {
            List<JCInfoModel> list = new List<JCInfoModel>();
            string dpname = FilterClass.DianPu1.UserName.Trim();
            list = jcbll.FactoryExit(dpname);
            dataGridView3.DataSource = list.OrderByDescending(a => a.jcBeginDate).ToList();
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
            bool result = jcbll.UpdateEndSend(list);
            if (result)
            {
                MessageBox.Show("成功！");
                BindData();
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
            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                if (row.Cells["jcPaiNumber"].Value.ToString().Trim() == tmnum)
                {
                    row.Cells["XZ"].Value = true;
                    textBox1.Text = "";
                    //此处添加提示音效
                    SuccessInfo.Success();
                    //该表lable中的数量信息
                    numberAdd();
                    return;
                }
            }
            textBox1.Text = "";
            MessageBox.Show("失败,没有此数据！");
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
