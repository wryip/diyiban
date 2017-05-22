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
    public partial class PictureShow : Form
    {
        public PictureShow()
        {
            InitializeComponent();
        }
        private bool canMove = false;
        private Point mousePos;
        private static PictureShow spbh;
        public static string PicUrl;
        public static PictureShow Create(string picurl)
        {
            PicUrl = picurl;
            if (spbh == null)
            {
                spbh = new PictureShow();
            }
            return spbh;
        }
        private void PictureShow_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = PicUrl;      
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            this.MouseWheel += new MouseEventHandler(PictureShow_MouseWheel);
        }
        void PictureShow_MouseWheel(object sender, MouseEventArgs e)
        {
            var size = pictureBox1.Size;
            if (e.Delta == 120)
            {
                size.Width += 20;
                size.Height += 20;
                pictureBox1.Size = size;
            }
            else if (e.Delta < 0)
            {
                size.Width -= 20;
                size.Height -= 20;
                pictureBox1.Size = size;
            }
        }

        private void PictureShow_FormClosing(object sender, FormClosingEventArgs e)
        {
            spbh = null;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.canMove = true;
            this.mousePos = new Point(e.X, e.Y); 
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.canMove)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X
                                     - mousePos.X + e.X, pictureBox1.Location.Y
                                     - mousePos.Y + e.Y);
            }  
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            this.canMove = false;  
        }
    }
}
