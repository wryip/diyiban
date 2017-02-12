namespace yixiupige
{
    partial class DPUpdateFrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.bzxxBox = new System.Windows.Forms.TextBox();
            this.dpdztBox = new System.Windows.Forms.TextBox();
            this.lxdhBox = new System.Windows.Forms.TextBox();
            this.lxrBox = new System.Windows.Forms.TextBox();
            this.dpmcBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tcbutton = new System.Windows.Forms.Button();
            this.bcbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(473, 357);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(257, 23);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // bzxxBox
            // 
            this.bzxxBox.Location = new System.Drawing.Point(103, 159);
            this.bzxxBox.Margin = new System.Windows.Forms.Padding(4);
            this.bzxxBox.Multiline = true;
            this.bzxxBox.Name = "bzxxBox";
            this.bzxxBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.bzxxBox.Size = new System.Drawing.Size(611, 142);
            this.bzxxBox.TabIndex = 9;
            // 
            // dpdztBox
            // 
            this.dpdztBox.Location = new System.Drawing.Point(103, 121);
            this.dpdztBox.Margin = new System.Windows.Forms.Padding(4);
            this.dpdztBox.Name = "dpdztBox";
            this.dpdztBox.Size = new System.Drawing.Size(611, 25);
            this.dpdztBox.TabIndex = 8;
            // 
            // lxdhBox
            // 
            this.lxdhBox.Location = new System.Drawing.Point(103, 88);
            this.lxdhBox.Margin = new System.Windows.Forms.Padding(4);
            this.lxdhBox.Name = "lxdhBox";
            this.lxdhBox.Size = new System.Drawing.Size(611, 25);
            this.lxdhBox.TabIndex = 7;
            // 
            // lxrBox
            // 
            this.lxrBox.Location = new System.Drawing.Point(103, 54);
            this.lxrBox.Margin = new System.Windows.Forms.Padding(4);
            this.lxrBox.Name = "lxrBox";
            this.lxrBox.Size = new System.Drawing.Size(611, 25);
            this.lxrBox.TabIndex = 6;
            // 
            // dpmcBox
            // 
            this.dpmcBox.Location = new System.Drawing.Point(103, 16);
            this.dpmcBox.Margin = new System.Windows.Forms.Padding(4);
            this.dpmcBox.Name = "dpmcBox";
            this.dpmcBox.Size = new System.Drawing.Size(611, 25);
            this.dpmcBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 159);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "备注信息：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "店铺地址：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "联系电话：";
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoSourcePlayer1.Location = new System.Drawing.Point(11, 20);
            this.videoSourcePlayer1.Margin = new System.Windows.Forms.Padding(4);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(236, 182);
            this.videoSourcePlayer1.TabIndex = 1;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.videoSourcePlayer1);
            this.groupBox5.Location = new System.Drawing.Point(387, 387);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox5.Size = new System.Drawing.Size(247, 210);
            this.groupBox5.TabIndex = 12;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "设置摄像头";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Location = new System.Drawing.Point(16, 330);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(361, 266);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "打印设置";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Location = new System.Drawing.Point(11, 26);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox6.Size = new System.Drawing.Size(343, 232);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "打印结尾内容";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 25);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(325, 199);
            this.textBox1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "联 系 人：";
            // 
            // tcbutton
            // 
            this.tcbutton.Location = new System.Drawing.Point(640, 511);
            this.tcbutton.Margin = new System.Windows.Forms.Padding(4);
            this.tcbutton.Name = "tcbutton";
            this.tcbutton.Size = new System.Drawing.Size(100, 29);
            this.tcbutton.TabIndex = 14;
            this.tcbutton.Text = "退出";
            this.tcbutton.UseVisualStyleBackColor = true;
            this.tcbutton.Click += new System.EventHandler(this.tcbutton_Click);
            // 
            // bcbutton
            // 
            this.bcbutton.Location = new System.Drawing.Point(640, 457);
            this.bcbutton.Margin = new System.Windows.Forms.Padding(4);
            this.bcbutton.Name = "bcbutton";
            this.bcbutton.Size = new System.Drawing.Size(100, 29);
            this.bcbutton.TabIndex = 13;
            this.bcbutton.Text = "保存";
            this.bcbutton.UseVisualStyleBackColor = true;
            this.bcbutton.Click += new System.EventHandler(this.bcbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "店铺名称：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(384, 360);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "选择摄像头";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bzxxBox);
            this.groupBox1.Controls.Add(this.dpdztBox);
            this.groupBox1.Controls.Add(this.lxdhBox);
            this.groupBox1.Controls.Add(this.lxrBox);
            this.groupBox1.Controls.Add(this.dpmcBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(739, 309);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本设置";
            // 
            // DPUpdateFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 610);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tcbutton);
            this.Controls.Add(this.bcbutton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Name = "DPUpdateFrom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改店铺信息";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DPUpdateFrom_FormClosing);
            this.Load += new System.EventHandler(this.DPUpdateFrom_Load);
            this.groupBox5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox bzxxBox;
        private System.Windows.Forms.TextBox dpdztBox;
        private System.Windows.Forms.TextBox lxdhBox;
        private System.Windows.Forms.TextBox lxrBox;
        private System.Windows.Forms.TextBox dpmcBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button tcbutton;
        private System.Windows.Forms.Button bcbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}