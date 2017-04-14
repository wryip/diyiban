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
    public partial class addQtFuWu : Form
    {
        public addQtFuWu()
        {
            InitializeComponent();
        }
        public delegate void databind();
        public static databind bind1;
        QtFuWuBLL bll = new QtFuWuBLL();
        private static addQtFuWu qt;
        public static addQtFuWu Create(databind bind)
        {
            bind1 = bind;
            if (qt == null)
            {
                qt = new addQtFuWu();
            }
            return qt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addQtFuWu_FormClosing(object sender, FormClosingEventArgs e)
        {
            qt = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            qtFuWuModel model = new qtFuWuModel();
            model.QtName = textBox1.Text.Trim();
            try
            {
                //money = Convert.ToInt32(textBox2.Text.Trim());
                //if (money > 100 || money < 0)
                //{
                //    MessageBox.Show("请输入合理的提成！");
                //    return;
                //}
                //model.QtTc = money;
                bool result = bll.AddModel(model);
                if (result)
                {
                    MessageBox.Show("添加成功！");
                    bind1();
                    this.Close();
                    return;
                }
                MessageBox.Show("错误！请稍后再试！");
            }
            catch
            {
                MessageBox.Show("提成请输入数字！");
            }
        }
    }
}
