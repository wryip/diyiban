using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace yixiupige
{
    public partial class jbcszjForm : Form
    {
        public jbcszjForm()
        {
            InitializeComponent();
        }
        public delegate void databind();
        public static databind bind;
       
        //设置单例模式
        private static jbcszjForm jbcszj;
        public static jbcszjForm Create(databind action)
        {
            bind = action;
            if (jbcszj==null)
            {
                jbcszj = new jbcszjForm();
            }
            return jbcszj;
        }
        private void jbcszjForm_Load(object sender, EventArgs e)
        {

        }

        private void jbcszjForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            jbcszj = null;
        }

        private void TCbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        jbcsBLL bll = new jbcsBLL();
        
        private void TJbutton_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                
                bool result = bll.addIteam(textBox1.Text.Trim(),this.Text);
                if (result)
                {
                    MessageBox.Show("添加成功！");
                    
                    this.Close();
                  
                    bind();
                   
                    return;
                }
                MessageBox.Show("添加失败！");
                return;
            }
            MessageBox.Show("请填写信息！");
        }
    }
}
