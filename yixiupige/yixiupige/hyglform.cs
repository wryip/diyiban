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
        public static int id=-1;
        List<memberInfoModel> list;
        public int PageCount { get; set; }
        //一共多少页
        public string pageType { get; set; }
        //当前页
        public int indexPage { get; set; }
        //一页300条
        public memberInfoBLL infobll = new memberInfoBLL();
        private void hyglform_Load(object sender, EventArgs e)
        {            
            TreeNode child;
            memberTypeCURD bll = new memberTypeCURD();
            //List<string> list = bll.selectNodes();
            List<string> list1 = bll.selectNodesAddCount();
            int count = infobll.selectAllCount();
            TreeNode parent = treeView1.Nodes[0];
            //TreeNode parent=new TreeNode();
            //parent.Text = "全部";
            parent.Text += "[" + count + "]";
            //treeView1.Nodes.Add(parent);           
            foreach (var i in list1)
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
         public void PageLoad(string name, int pageindex)
        {
            int i = 1;
            int count;
            List<memberInfoModel> list = infobll.selectInfoCollect(name.Split(new char []{'['},StringSplitOptions.RemoveEmptyEntries)[0], pageindex, out count);
            PageCount = count;
            foreach (var iteam in list)
            {
                iteam.idbh = i++;
            }
            label3.Text = "共" + count + "条";
            dataGridView1.DataSource = list;
        }
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string cardTepe=e.Node.Text;
            pageType = cardTepe;
            indexPage = 1;
            PageLoad(cardTepe, 1);
            textBox1.Text = indexPage.ToString();
            //dataGridView1.DataSource = list;
            //int i = dataGridView1.Rows.Count;
            //if (e.Button == MouseButtons.Right)
            //{
            //    for (int j = 0; j < i; j++)
            //    {
            //        dataGridView1.Rows[j].ContextMenuStrip = null;
            //    }
            //}
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
            PageLoad("全部", 1);
        }
        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择会员!");
                return;
            }
            //memberInfoModel model = list[id];
            memberInfoModel model = (memberInfoModel)dataGridView1.SelectedRows[0].DataBoundItem;
            xiugaimember xiugais = xiugaimember.Create(model, bindData);
            xiugais.Show();
            xiugais.Focus();
            //id = -1;
        }
        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    base.OnMouseDown(e);
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        //if (this.ContextMenuStrip != null && this.ContextMenuStripNeeded != null)
        //        //{
        //            //int rowIndex = this.GetRowIndexAt(e.Location);  // 计算行号  
        //            //int colIndex = this.GetColIndexAt(e.Location);  // 计算列号  this.ContextMenuStrip, rowIndex, colIndex
        //            DataGridViewRowContextMenuStripNeededEventArgs ee;  // 事件参数  
        //            ee = new DataGridViewRowContextMenuStripNeededEventArgs(1);
        //            this.dataGridView1_RowContextMenuStripNeeded(e.Location,ee);  // 引发自定义事件，执行事件方法  
        //        //}

        //    }
        //}

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
        }

        private void 删除会员ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择会员!");
                return;
            }
            memberInfoModel model = (memberInfoModel)dataGridView1.SelectedRows[0].DataBoundItem;
            caocuofrom chongzhi = caocuofrom.Create(deletePassword, model.ID.ToString().Trim());
            chongzhi.Show();
            chongzhi.Focus();
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

        private void treeView1_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void 打印预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("确定退卡？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (DialogResult.Cancel == result)
            {
                return;
            }
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一条记录！");
                return;
            }
            memberInfoModel model = dataGridView1.SelectedRows[0].DataBoundItem as memberInfoModel;
            ExitCard fromcard = ExitCard.CreateForm(model, bindData);
            fromcard.Show();
            fromcard.Focus();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string type = treeView1.SelectedNode.Text;
            List<memberInfoModel> list = infobll.selectAll(type.Split(new char []{'['},StringSplitOptions.RemoveEmptyEntries)[0]);
            bool resu = NPOIHelper.PrintDocument(list, type + "-会员信息");
            if (resu)
            {
                MessageBox.Show("导出成功！");
                return;
            }
            MessageBox.Show("导出失败！");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (indexPage == 1)
            {
                return;
            }
            PageLoad(pageType, 1);
            indexPage = 1;
            textBox1.Text = "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (indexPage == 1)
            {
                return;
            }
            PageLoad(pageType, indexPage--);
            textBox1.Text = indexPage.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double page = PageCount * 1.0 / 300.0;
            int i = Convert.ToInt32(Math.Ceiling(page));
            if (indexPage >= i)
            {
                return;
            }
            PageLoad(pageType, indexPage++);
            textBox1.Text = indexPage.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double page = PageCount * 1.0 / 300.0;
            int i = Convert.ToInt32(Math.Ceiling(page));
            if (indexPage == i)
            {
                return;
            }
            PageLoad(pageType, i);
            indexPage = i;
            textBox1.Text = indexPage.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            double page = PageCount * 1.0 / 300.0;
            int i = Convert.ToInt32(Math.Ceiling(page));
            int index;
            if (int.TryParse(textBox1.Text, out index))
            {
                if (index > 0 && index < i)
                {
                    PageLoad(pageType, index);
                    indexPage = index;
                }
            }
            else
            {
                MessageBox.Show("请输入数字！");
            }
        }
    }
}
