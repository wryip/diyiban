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
using ZXing;
using ZXing.QrCode;

namespace yixiupige
{
    public partial class bdpjFrom : Form
    {
        QrCodeEncodingOptions option;
        BarcodeWriter writer = null; 
        public bdpjFrom()
        {
            InitializeComponent();
            option = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = 200,
                Height = 200
            };
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;//二维码
            //writer.Format = BarcodeFormat.ITF;//改变条形码条形码
            writer.Options = option;  
        }
        private static bdpjFrom zjhyfl;
        //public static string cardNo;
        LSConsumptionBLL lsbll = new LSConsumptionBLL();
        public static bdpjFrom Create()
        {
            //cardNo = cardno;
            if (zjhyfl == null)
            {
                zjhyfl = new bdpjFrom();
            }
            return zjhyfl;
        }

        private void bdpjFrom_Load(object sender, EventArgs e)
        {
            List<bdpjModel> list = new List<bdpjModel>();
            list = lsbll.selectBDPJ();
            dataGridView1.DataSource = list.OrderByDescending(a=>a.danNumber).ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bdpjFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            zjhyfl = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double hjje = 0;
            int hjcg = 0;
            double yfje = 0;
            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("请选择一条记录！");
                return;
            }
            string dnanumber = dataGridView1.SelectedRows[0].Cells["danNumber"].Value.ToString();
            string painumber = dataGridView1.SelectedRows[0].Cells["danNumber"].Value.ToString();
            string websb = "http://yhc19950315.imwork.net:28948?id=" + dnanumber;
            Bitmap bitmap = writer.Write(websb);
            List<LiShiConsumption> list = lsbll.SelectForDanNumber(dnanumber);
            foreach (var iteam in list)
            {
                hjje += Convert.ToDouble(iteam.LSMoney);
                hjcg += Convert.ToInt32(iteam.LSCount);
                yfje += Convert.ToDouble(iteam.LSYMoney);
            }
            PirentDocumentClass.PirentSH(hjje.ToString(), hjcg.ToString(), yfje.ToString(), list, bitmap, dnanumber, list[0].LSName, list[0].LSCardNumber, list[0].LSDate,"此为补打票据");
        }
    }
}
