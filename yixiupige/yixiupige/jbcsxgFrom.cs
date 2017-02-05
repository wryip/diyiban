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

namespace yixiupige
{
    public partial class jbcsxgFrom : Form
    {
        public jbcsxgFrom()
        {
            InitializeComponent();
        }
        public delegate void databind();
        public static databind bind;
        private static jbcsxgFrom jbcszj;
        public static string newnei="";
        public static string oldnei="";
        public jbcsBLL bll = new jbcsBLL();
        public static jbcsxgFrom Create(databind action,string neirong)
        {
            oldnei = neirong;
            bind = action;
            if (jbcszj == null)
            {
                jbcszj = new jbcsxgFrom();
            }
            return jbcszj;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            newnei = textBox1.Text.Trim();
            bool result = bll.updateIteam(oldnei,newnei);
            if (result)
            {
                MessageBox.Show("修改成功！");
                bind();
                this.Close();
            }
            else
            {
                MessageBox.Show("修改失败！");
            }
        }

        private void jbcsxgFrom_Load(object sender, EventArgs e)
        {
            textBox1.Text = oldnei;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void jbcsxgFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            jbcszj = null;
        }
    }
}
