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
    public partial class AddFuWuType : Form
    {
        public AddFuWuType()
        {
            InitializeComponent();
        }
        public delegate void databind();
        public static databind bind1;
        fuwuBLL fuwubl = new fuwuBLL();
        private static AddFuWuType hyfl;
        memberTypeCURD bll = new memberTypeCURD();
        public static AddFuWuType Create(databind bind)
        {
            bind1 = bind;
            if (hyfl == null)
            {
                hyfl = new AddFuWuType();
            }
            return hyfl;
        }
        private void AddFuWuType_Load(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            //返回会员卡的类型的名字
            list = bll.selectNodes();
            list.Insert(0,"无卡");
            tableLayoutPanel1.Height = (list.Count + 1) * 40;
            RowStyle row ;
            Label lab1;
            TextBox teb1;
            //row = new RowStyle(SizeType.Absolute,40);
            lab1 = new Label();
            lab1.Text = "服务类别名称";
            teb1 = new TextBox();
            tableLayoutPanel1.Controls.Add(lab1, 0, 0);
            tableLayoutPanel1.Controls.Add(teb1, 1, 0);
            foreach (var i in list)
            {
                lab1 = new Label();
                lab1.Text = i;
                teb1 = new TextBox();
                row = new RowStyle(SizeType.Absolute, 40);
                
                tableLayoutPanel1.Controls.Add(lab1, 0, tableLayoutPanel1.RowStyles.Count - 1);
                tableLayoutPanel1.Controls.Add(teb1, 1, tableLayoutPanel1.RowStyles.Count - 1);
                tableLayoutPanel1.RowStyles.Add(row);
            }            
        }

        private void AddFuWuType_FormClosing(object sender, FormClosingEventArgs e)
        {
            hyfl = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fuwuModel model = new fuwuModel();
            TextBox tb;
            Label lb;
            string str = "";
            int count = tableLayoutPanel1.RowStyles.Count;
            for (int i = 0; i < count-1; i++)
            {                
                if (i == 0)
                {
                    tb = tableLayoutPanel1.GetControlFromPosition(1,i) as TextBox;
                    model.Name = tb.Text.Trim();
                    continue;
                }
                lb = tableLayoutPanel1.GetControlFromPosition(0, i) as Label;
                tb = tableLayoutPanel1.GetControlFromPosition(1, i) as TextBox;
                if (tb.Text == "")
                {
                    MessageBox.Show("信息不能为空！");
                    model.Name = "";
                    str = "";
                    return;
                }
                str += lb.Text.Trim()+","+tb.Text.Trim()+";";
            }
            model.neirong = str;
            bool result = fuwubl.AddModel(model);
            if (result)
            {
                MessageBox.Show("添加成功！");
                bind1();
                this.Close();
                return;
            }
            MessageBox.Show("添加失败！");
        }
    }
}
