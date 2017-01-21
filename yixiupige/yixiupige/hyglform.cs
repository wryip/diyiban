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
        public static int id=-1;
        List<memberInfoModel> list;
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
            list = infobll.selectInfoCollect(cardTepe);
            dataGridView1.DataSource = list;
            int i = dataGridView1.Rows.Count;
            if (e.Button == MouseButtons.Right)
            {
                for (int j = 0; j < i; j++)
                {
                    dataGridView1.Rows[j].ContextMenuStrip = null;
                }
            }
        }
            //int i = dataGridView1.Rows.Count;
            //if (e.Button == MouseButtons.Right)
            //{
            //    for (int j = 0; j < i; j++)
            //    {
            //        dataGridView1.Rows[j].Selected = false;
            //        //dataGridView1.Rows[j].ContextMenuStrip = null;
            //    }
            //    dataGridView1.Rows[e.RowIndex].Selected = true;
            //    //dataGridView1.Rows[e.RowIndex].ContextMenuStrip = contextMenuStrip1;
            //    //Point point = new Point(e.X + (e.ColumnIndex) * 130, e.Y + (e.RowIndex+1) * 23);
            //    //MessageBox.Show((e.X + (e.ColumnIndex) * 130).ToString(), (e.Y + (e.RowIndex + 1) * 23).ToString());
            //    //dataGridView1.Rows[e.RowIndex].ContextMenuStrip.Show(dataGridView1, e.X + (e.ColumnIndex) * (dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed)), e.Y + (e.RowIndex+1) * (dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Displayed)));
            //}
        public void bindData()
        {
            string cardTepe = treeView1.SelectedNode.Text;
            List<memberInfoModel> list111 = infobll.selectInfoCollect(cardTepe);
            dataGridView1.DataSource = list111;
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == -1)
            {
                MessageBox.Show("请选择会员!");
                return;
            }
            memberInfoModel model = list[id];
            xiugaimember xiugais = xiugaimember.Create(model, bindData);
            xiugais.Show();
            xiugais.Focus();
            id = -1;
        }
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Right)
            {
                //if (this.ContextMenuStrip != null && this.ContextMenuStripNeeded != null)
                //{
                    //int rowIndex = this.GetRowIndexAt(e.Location);  // 计算行号  
                    //int colIndex = this.GetColIndexAt(e.Location);  // 计算列号  this.ContextMenuStrip, rowIndex, colIndex
                    DataGridViewRowContextMenuStripNeededEventArgs ee;  // 事件参数  
                    ee = new DataGridViewRowContextMenuStripNeededEventArgs(1);
                    this.dataGridView1_RowContextMenuStripNeeded(e.Location,ee);  // 引发自定义事件，执行事件方法  
                //}

            }
        }

        private void dataGridView1_RowContextMenuStripNeeded(object sendel, DataGridViewRowContextMenuStripNeededEventArgs e)
        {
            int i = dataGridView1.Rows.Count;
            for (int j = 0; j < i; j++)
            {
                dataGridView1.Rows[j].Selected = false;
                //dataGridView1.Rows[j].ContextMenuStrip = null;
            }
            try 
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                id = e.RowIndex;
            }
            catch
            {
                return;
            }
        }

        private void 会员充值ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == -1)
            {
                MessageBox.Show("请选择会员!");
                return;
            }
            memberInfoModel model = list[id];
            hyczck chongzhi = hyczck.Create(model);
            chongzhi.Show();
            chongzhi.Focus();
            id = -1;
        }

        private void 会员信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == -1)
            {
                MessageBox.Show("请选择会员!");
                return;
            }
            memberInfoModel model = list[id];
            hyInfoZhanShi chongzhi = hyInfoZhanShi.Create(model);
            chongzhi.Show();
            chongzhi.Focus();
            id = -1;
        }

        private void 删除会员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (id == -1)
            {
                MessageBox.Show("请选择会员!");
                return;
            }
            memberInfoModel model = list[id];
            caocuofrom chongzhi = caocuofrom.Create(deletePassword, model.memberCardNo.Trim());
            chongzhi.Show();
            chongzhi.Focus();
            id = -1;
        }
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

        
    }
}
