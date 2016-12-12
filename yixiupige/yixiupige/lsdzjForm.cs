using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace yixiupige
{
    public partial class lsdzjForm : Form
    {
        public lsdzjForm()
        {
            InitializeComponent();
        }
        private static lsdzjForm lsdzj;
        public static lsdzjForm Create()
        {
            if (lsdzj==null)
            {
                lsdzj = new lsdzjForm();
            }
            return lsdzj;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        //退出程序
        private void tcbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //调入图片
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            od.Title = "请选择文件";
            od.Multiselect = false;
            od.Filter = "图片问价|*.jpg";
            od.ShowDialog();
            string path = od.FileName;
            if (path == "")
            {
                return;
            }
            pictureBox1.ImageLocation = path;
            

        }

        private void lsdzjForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            lsdzj = null;
        }
    }
}
