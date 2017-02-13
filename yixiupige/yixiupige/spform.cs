using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODEL;
using BLL;
namespace yixiupige
{
    public partial class spform : Form
    {
        public spform()
        {
            InitializeComponent();
        }
        private static spform _danli = null;
        public static spform CreateForm()
        {
            if (_danli == null)
            {
                _danli = new spform();
            }
            return _danli;
        }
        private void loadevent()
        {
            _load();
        }
        private void eventload(GoodInfo gd)
        {
            load(gd);
        }
        GoodInfoBLL gdbll = new GoodInfoBLL();
        public  void _load()
        {
            GoodInfo gd=new GoodInfo();
            gd = null;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = gdbll.Getlist(gd);
        }
        public void load(GoodInfo gd)
        {
           
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = gdbll.Getlist(gd);
        }
        jbcsBLL jbcsbll = new jbcsBLL();
        private void spform_Load(object sender, EventArgs e)
        {
            TreeNode child;


            List<jbcs> list = jbcsbll.selectList(4);
            TreeNode parent = treeView1.Nodes[0];
            //TreeNode parent=new TreeNode();
            //parent.Text = "全部";
            //treeView1.Nodes.Add(parent);           
            foreach (var i in list)
            {
                child = new TreeNode();
                child.Text =i.AllType;
                parent.Nodes.Add(child);
            }
            _load();
            
        }

        private void spform_FormClosing(object sender, FormClosingEventArgs e)
        {
            _danli = null;
        }

      

        private void 增加商品ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            zjspForm_ zjsp = zjspForm_.Create();
            zjsp.Loadevent +=loadevent;
            zjsp.Show();
            zjsp.Focus();
        }

        private void 修改商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoodInfo gd = new GoodInfo();
            if (dataGridView1.SelectedRows.Count<=0)
            {
                MessageBox.Show("请选择要修改的商品！");
            }
            else {
                var row = dataGridView1.SelectedRows[0];
               
                gd.Gno = row.Cells[1].Value.ToString();
              
                xgspFrom xg = xgspFrom.Create();
                xg.Add(gd);
                xg.Loadevent += loadevent;
                xg.Show();
                xg.Focus();
            
            }
          
            
            
           
        }

        private void 删除商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cell = dataGridView1.SelectedCells;
            GoodInfo gd = new GoodInfo();
            gd.Gid = Convert.ToInt32(cell[0].Value);
            DialogResult result = MessageBox.Show("确定删除？", "提示", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                if (gdbll.Move(gd.Gid))
                {
                    _load();
                    loadevent();
                }
                else { MessageBox.Show("删除失败，请稍后再试！"); }
            }
            else
            {
                MessageBox.Show("删除失败，请稍后再试！");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void 商品补货ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoodInfo gd = new GoodInfo();
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请选择要补货的商品！");
            }
            else
            {
                var row = dataGridView1.SelectedRows[0];
                gd.Gno = row.Cells[1].Value.ToString();
                spbhForm spbh = new spbhForm();
                spbh.Add(gd);
                spbh.Loadevent += loadevent;
                spbh.Show();
                spbh.Focus();
                //xgspFrom xg = xgspFrom.Create();
                //xg.Add(gd);
                //xg.Loadevent += loadevent;
                //xg.Show();
                //xg.Focus();

            }
          
        }

        private void 查看商品ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cxspForm cx = cxspForm.Create();
            cx.loaddd += eventload;

            cx.Show();
            cx.Focus();
        }

        private void treeView1_Click(object sender, EventArgs e)
        {

            //_load();
            
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string cardTepe = e.Node.Text;
            GoodInfo gd = new GoodInfo()
            {
                Gtype=cardTepe
            };
            List<GoodInfo> list = gdbll.Getlist(gd);
            
            dataGridView1.DataSource = gdbll.Getlist(gd);
           
        }

      
    }
}
