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
    public partial class jcglform : Form
    {
        public jcglform()
        {
            InitializeComponent();
        }
        JCInfoBLL jcinfobll = new JCInfoBLL();
        private static jcglform _danli = null;
        public static jcglform CreateForm()
        {
            if (_danli == null)
            {
                _danli = new jcglform();
            }
            return _danli;
        }
        private void jcglform_Load(object sender, EventArgs e)
        {
            TreeNode child;
            jbcsBLL bll = new jbcsBLL();
            List<jbcs> list = bll.selectList(5);
            TreeNode parent = treeView1.Nodes[0];
            //TreeNode parent=new TreeNode();
            //parent.Text = "全部";
            //treeView1.Nodes.Add(parent);           
            foreach (var i in list)
            {
                child = new TreeNode();
                child.Text = i.AllType;
                parent.Nodes.Add(child);
            }
        }

        private void jcglform_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string cardTepe = e.Node.Text;
            List<JCInfoModel> list = new List<JCInfoModel>();
            list = jcinfobll.selectAllList(cardTepe);
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    dataGridView1.Rows[i].Selected = false;
            //}
            //dataGridView1.Rows[e.RowIndex].Selected = true;
            pictureBox1.ImageLocation = dataGridView1.Rows[e.RowIndex].Cells["jcImgUrl"].Value.ToString();
        }

        private void dataGridView1_RowContextMenuStripNeeded(object sender, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void 查找寄存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            jcSelectFrom jcselect = jcSelectFrom.CreateForm(dataviewBind);
            jcselect.Show();
            jcselect.Focus();
        }
        public void dataviewBind(List<JCInfoModel> list)
        {
            dataGridView1.DataSource=list;
        }
        //刷新数据
        public void dataviewBind1()
        {
            List<JCInfoModel> list = jcinfobll.selectAllList("全部");
            dataGridView1.DataSource = list;
        }
        private void 寄存取走ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[0].Cells["glDanNo"].Value);
            qzjcFrom qzjc = qzjcFrom.CreateForm(id, dataviewBind1);
            qzjc.Show();
            qzjc.Focus();
        }

        private void 修改寄存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.Rows[0].Cells["glDanNo"].Value);
            UpdatejcFrom qzjc = UpdatejcFrom.CreateForm(id, dataviewBind1);
            qzjc.Show();
            qzjc.Focus();
        }

        private void 增加寄存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddjcFrom addjc = AddjcFrom.CreateForm();
            addjc.Show();
            addjc.Focus();
        }

        private void 删除寄存ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JCInfoModel model = (JCInfoModel)dataGridView1.SelectedRows[0].DataBoundItem;
            caocuofrom caozuo = caocuofrom.Create(deletePassword, model.jcID.ToString());
            caozuo.Show();
        }
        public void deletePassword(string pas, string cardNo)
        {
            if (pas.Trim() == "admin888")
            {
                //删除该会员
                bool result = jcinfobll.deleteIDIteam(cardNo);
                if (result)
                {
                    MessageBox.Show("删除成功！");
                    dataviewBind1();
                }
                else
                {
                    MessageBox.Show("删除失败！");
                }
            }
            else
            {
                MessageBox.Show("密码错误，删除失败！");
            }
        }

        private void 取消取走ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JCInfoModel model = (JCInfoModel)dataGridView1.SelectedRows[0].DataBoundItem;
            if (model.jcZT == "未取走")
            {
                MessageBox.Show("该物品并未取走，不能执行此操作！");
                return;
            }
            caocuofrom caozuo = caocuofrom.Create(updateZT, model.jcID.ToString());
            caozuo.Show();
        }
        public void updateZT(string pas, string cardNo)
        {
            if (pas.Trim() == "admin888")
            {
                //取消取走
                bool result = jcinfobll.UpdateIDIteam(cardNo);
                if (result)
                {
                    MessageBox.Show("修改成功！");
                    dataviewBind1();
                }
                else
                {
                    MessageBox.Show("修改失败！");
                }
            }
            else
            {
                MessageBox.Show("密码错误，修改失败！");
            }
        }
    }
}
