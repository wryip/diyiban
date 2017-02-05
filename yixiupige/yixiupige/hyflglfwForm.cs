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
    public partial class hyflglfwForm : Form
    {
        public hyflglfwForm()
        {
            InitializeComponent();
        }
        fuwuBLL bll = new fuwuBLL();
        private static hyflglfwForm hyfl;
        public static hyflglfwForm Create()
        {
            if (hyfl==null)
            {
                hyfl = new hyflglfwForm();
            }
            return hyfl;
        }
        private void tcbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void hyflglfwForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            hyfl = null;
        }

        private void zjhylbbutton_Click(object sender, EventArgs e)
        {
            zjhyflForm zjhyfl = zjhyflForm.Create(gridbind);
            zjhyfl.Show();
            zjhyfl.Focus();
        }

        private void zjfwbutton_Click(object sender, EventArgs e)
        {
            AddFuWuType addfuwu = AddFuWuType.Create(gridbind);
            addfuwu.Show();
            addfuwu.Focus();
        }

        private void xgfwbutton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedColumns.Count != 1)
            {
                MessageBox.Show("请选择要编辑的一列！");
                return;
            }
            string name = dataGridView1.SelectedColumns[0].HeaderText;
            fuwuModel model = bll.selectIteam(name);
            if (model == null)
            {
                MessageBox.Show("请选择有效列！");
                return;
            }
            fuwuEdit fuwu = fuwuEdit.Create(gridbind,name);
            fuwu.Show();
            fuwu.Focus();
        }

        private void hylbscbutton_Click(object sender, EventArgs e)
        {
            var rows = dataGridView1.SelectedRows;
            if (rows.Count != 1)
            {
                MessageBox.Show("请选择一条数据");
                return;
            }
            string name = rows[0].Cells[0].Value.ToString();
            DialogResult result= MessageBox.Show("确定删除？","提示",MessageBoxButtons.OKCancel);
            if (result.ToString() == "OK")
            {
                memberTypeCURD memberbll = new memberTypeCURD();
                bool res=memberbll.deleteinfo(name);
                if (res)
                {
                    gridbind();
                }               
            }
            
        }

        private void hylbxgbutton_Click(object sender, EventArgs e)
        {
            var rows = dataGridView1.SelectedRows;
            if (rows.Count != 1)
            {
                MessageBox.Show("请选择一条数据");
                return;
            }
            string name = rows[0].Cells[0].Value.ToString();
            memberTypeCURD memberbll = new memberTypeCURD();
            memberType edit = memberbll.EditMember(name);
            hylxedit zjhyfl = hylxedit.Create(edit,gridbind);
            zjhyfl.Show();
            zjhyfl.Focus();
        }

        private void hyflglfwForm_Load(object sender, EventArgs e)
        {           
            // TODO:  这行代码将数据加载到表“kinyaoo123456DataSet.memberType”中。您可以根据需要移动或删除它。
            gridbind();

        }
        public void gridbind()
        {
            
            this.memberTypeTableAdapter.Fill(this.kinyaoo123456DataSet.memberType);
            //DataGridViewColumn colum=new DataGridViewColumn();            
            int count = dataGridView1.Columns.Count;
            for (int co = 5; co < count; co++)
            {
                dataGridView1.Columns.RemoveAt(5);
            }
            List<fuwuModel> list = new List<fuwuModel>();
            list = bll.selectAllList();
            foreach (var iteam in list)
            {
                DataGridViewTextBoxColumn coulm = new DataGridViewTextBoxColumn();
                coulm.HeaderText = iteam.Name;
                coulm.Name = iteam.Name;
                coulm.SortMode = DataGridViewColumnSortMode.Programmatic;
                //coulm.CellType=Type.
                dataGridView1.Columns.Add(coulm);
                string str=iteam.neirong;
                string[] ss = str.Split(new char[]{';'},StringSplitOptions.RemoveEmptyEntries);
                foreach (var ite in ss)
                {
                    int number=dataGridView1.Columns.Count;
                    string[] neiss = ite.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries);
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[0].Value.ToString().Trim() == neiss[0].Trim())
                        {
                            row.Cells[number - 1].Value = neiss[1].Trim();
                            continue;
                        }                        
                    }
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
            dataGridView1.Columns[e.ColumnIndex].Selected = true;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
            dataGridView1.Rows[e.RowIndex].Selected = true;
        }

        private void scfwbutton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedColumns.Count != 1)
            {
                MessageBox.Show("请选择要编辑的一列！");
                return;
            }
            string name = dataGridView1.SelectedColumns[0].HeaderText;
            fuwuModel model = bll.selectIteam(name);
            if (model == null)
            {
                MessageBox.Show("请选择有效列！");
                return;
            }
            bool result = bll.deleteIteam(name);
            if (result)
            {
                MessageBox.Show("删除成功！");
                gridbind();
                return;
            }
            MessageBox.Show("删除失败！");
        }
    }
}
