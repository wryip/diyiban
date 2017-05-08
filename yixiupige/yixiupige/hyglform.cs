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
    public partial class hyglform : Form
    {
        public hyglform()
        {
            InitializeComponent();
        }
        private static hyglform _danli = null;
        public static hyglform CreateForm()
        {
            if (_danli == null)
            {
                _danli = new hyglform();
            }
            return _danli;
        }
        //public static int id=-1;
        //List<memberInfoModel> list;
        public memberInfoBLL infobll = new memberInfoBLL();
        private void hyglform_Load(object sender, EventArgs e)
        {            
            TreeNode child;
            memberTypeCURD bll = new memberTypeCURD();
            List<string> list = bll.selectNodes();
            TreeNode parent = treeView1.Nodes[0];
            //TreeNode parent=new TreeNode();
            //parent.Text = "全部";
            //treeView1.Nodes.Add(parent);           
            foreach (var i in list)
            {
                child = new TreeNode();
                child.Text = i;
                parent.Nodes.Add(child);
            }
                
        }

        private void hyglform_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

        private void 查找会员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hyczForm hycz = hyczForm.Create(czdataBind);
            hycz.Show();
            hycz.Focus();
        }
        public void czdataBind(List<memberInfoModel> czmodel)
        {
            dataGridView1.DataSource = czmodel;
        }
        private void 增加会员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hyzjForm hyzj = hyzjForm.Create();
            hyzj.Show();
            hyzj.Focus();
            bindData();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string cardTepe=e.Node.Text;
            List<memberInfoModel>  list = infobll.selectInfoCollect(cardTepe);
            dataGridView1.DataSource = list;
        }
        public void bindData()
        {
            string cardTepe = treeView1.SelectedNode.Text;
            List<memberInfoModel> list111 = infobll.selectInfoCollect(cardTepe);
            dataGridView1.DataSource = list111;
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择会员!");
                return;
            }
            memberInfoModel model = (memberInfoModel)dataGridView1.SelectedRows[0].DataBoundItem;
            xiugaimember xiugais = xiugaimember.Create(model, bindData);
            xiugais.Show();
            xiugais.Focus();
            //id = -1;
        }

        private void dataGridView1_RowContextMenuStripNeeded(object sendel, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
                dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void 会员充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择会员!");
                return;
            }
            memberInfoModel model = (memberInfoModel)dataGridView1.SelectedRows[0].DataBoundItem;
            hyczck chongzhi = hyczck.Create(model, bindData);
            chongzhi.Show();
            chongzhi.Focus();
            //id = -1;
        }

        private void 会员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择会员!");
                return;
            }
            memberInfoModel model = (memberInfoModel)dataGridView1.SelectedRows[0].DataBoundItem;
            hyInfoZhanShi chongzhi = hyInfoZhanShi.Create(model);
            chongzhi.Show();
            chongzhi.Focus();
            //id = -1;
        }

        private void 删除会员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count==0)
            {
                MessageBox.Show("请选择会员!");
                return;
            }
            memberInfoModel model = (memberInfoModel)dataGridView1.SelectedRows[0].DataBoundItem;
            caocuofrom chongzhi = caocuofrom.Create(deletePassword, model.ID.ToString().Trim());
            chongzhi.Show();
            chongzhi.Focus();
            //id = -1;
        }
        /// <summary>
        /// 此处的cardno已经改为唯一ID
        /// </summary>
        /// <param name="pas"></param>
        /// <param name="cardNo"></param>
        public void deletePassword(string pas,string cardNo)
        {
            if (pas.Trim() == "admin888")
            {
                //删除该会员
                bool result = infobll.deleteInfoModel(cardNo);
                if (result)
                {
                    MessageBox.Show("删除成功！");
                    bindData();
                }
            }
            else
            {
                MessageBox.Show("密码错误，删除失败！");
            }
        }

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定退卡？","提示",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            if (DialogResult.Cancel == result)
            {
                return;
            }
            if(dataGridView1.SelectedRows.Count!=1)
            {
                MessageBox.Show("请选择一条记录！");
                return ;
            }
            memberInfoModel model = dataGridView1.SelectedRows[0].DataBoundItem as memberInfoModel;
            ExitCard fromcard = ExitCard.CreateForm(model, bindData);
            fromcard.Show();
            fromcard.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string type = treeView1.SelectedNode.Text;
            List<memberInfoModel> list = (List<memberInfoModel>)dataGridView1.DataSource;
            bool resu=NPOIHelper.PrintDocument(list, type + "-会员信息");
            if (resu)
            {
                MessageBox.Show("导出成功！");
                return;
            }
            MessageBox.Show("导出失败！");
        }

        
    }
}
