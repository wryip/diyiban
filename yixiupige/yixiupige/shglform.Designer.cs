namespace yixiupige
{
    partial class shglform
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lsName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsDemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsSuperMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsCardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsTiaoMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.删除本条消费ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.补打标签ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.shNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shTiaoMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shDemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shPay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(759, 310);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "历史消费记录";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.lsName,
            this.lsTime,
            this.lsDemo,
            this.lsCount,
            this.lsMoney,
            this.lsPay,
            this.lsNumber,
            this.lsType,
            this.lsColor,
            this.lsQuestion,
            this.lsMark,
            this.lsPerson,
            this.lsSuperMark,
            this.lsNo,
            this.lsCardNo,
            this.lsTiaoMa});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.Location = new System.Drawing.Point(3, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView1.Size = new System.Drawing.Size(750, 269);
            this.dataGridView1.TabIndex = 0;
            // 
            // lsName
            // 
            this.lsName.HeaderText = "姓名";
            this.lsName.Name = "lsName";
            this.lsName.ReadOnly = true;
            // 
            // lsTime
            // 
            this.lsTime.HeaderText = "时间";
            this.lsTime.Name = "lsTime";
            this.lsTime.ReadOnly = true;
            // 
            // lsDemo
            // 
            this.lsDemo.HeaderText = "服务项目";
            this.lsDemo.Name = "lsDemo";
            this.lsDemo.ReadOnly = true;
            // 
            // lsCount
            // 
            this.lsCount.HeaderText = "点数";
            this.lsCount.Name = "lsCount";
            this.lsCount.ReadOnly = true;
            // 
            // lsMoney
            // 
            this.lsMoney.HeaderText = "金额";
            this.lsMoney.Name = "lsMoney";
            this.lsMoney.ReadOnly = true;
            // 
            // lsPay
            // 
            this.lsPay.HeaderText = "应付";
            this.lsPay.Name = "lsPay";
            this.lsPay.ReadOnly = true;
            // 
            // lsNumber
            // 
            this.lsNumber.HeaderText = "架号";
            this.lsNumber.Name = "lsNumber";
            this.lsNumber.ReadOnly = true;
            // 
            // lsType
            // 
            this.lsType.HeaderText = "品牌";
            this.lsType.Name = "lsType";
            this.lsType.ReadOnly = true;
            // 
            // lsColor
            // 
            this.lsColor.HeaderText = "颜色";
            this.lsColor.Name = "lsColor";
            this.lsColor.ReadOnly = true;
            // 
            // lsQuestion
            // 
            this.lsQuestion.HeaderText = "问题";
            this.lsQuestion.Name = "lsQuestion";
            this.lsQuestion.ReadOnly = true;
            // 
            // lsMark
            // 
            this.lsMark.HeaderText = "备注";
            this.lsMark.Name = "lsMark";
            this.lsMark.ReadOnly = true;
            // 
            // lsPerson
            // 
            this.lsPerson.HeaderText = "业务员";
            this.lsPerson.Name = "lsPerson";
            this.lsPerson.ReadOnly = true;
            // 
            // lsSuperMark
            // 
            this.lsSuperMark.HeaderText = "连锁店";
            this.lsSuperMark.Name = "lsSuperMark";
            this.lsSuperMark.ReadOnly = true;
            // 
            // lsNo
            // 
            this.lsNo.HeaderText = "单号";
            this.lsNo.Name = "lsNo";
            this.lsNo.ReadOnly = true;
            // 
            // lsCardNo
            // 
            this.lsCardNo.HeaderText = "卡号";
            this.lsCardNo.Name = "lsCardNo";
            this.lsCardNo.ReadOnly = true;
            // 
            // lsTiaoMa
            // 
            this.lsTiaoMa.HeaderText = "条码";
            this.lsTiaoMa.Name = "lsTiaoMa";
            this.lsTiaoMa.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.删除本条消费ToolStripMenuItem,
            this.补打标签ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
            // 
            // 删除本条消费ToolStripMenuItem
            // 
            this.删除本条消费ToolStripMenuItem.Name = "删除本条消费ToolStripMenuItem";
            this.删除本条消费ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.删除本条消费ToolStripMenuItem.Text = "删除本条消费";
            // 
            // 补打标签ToolStripMenuItem
            // 
            this.补打标签ToolStripMenuItem.Name = "补打标签ToolStripMenuItem";
            this.补打标签ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.补打标签ToolStripMenuItem.Text = "补打标签";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(774, 14);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(198, 100);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(190, 74);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "会员消费";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "请输入姓名，卡号，电话等回车！";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(18, 26);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(147, 21);
            this.textBox1.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(48, 6);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "模糊查找";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Controls.Add(this.textBox2);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(190, 74);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "散客消费";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(67, 42);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(67, 13);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "散客姓名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "联系电话";
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Location = new System.Drawing.Point(774, 120);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(198, 185);
            this.tabControl2.TabIndex = 2;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.videoSourcePlayer1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(190, 159);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "视频预览";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // videoSourcePlayer1
            // 
            this.videoSourcePlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoSourcePlayer1.Location = new System.Drawing.Point(7, 7);
            this.videoSourcePlayer1.Name = "videoSourcePlayer1";
            this.videoSourcePlayer1.Size = new System.Drawing.Size(177, 146);
            this.videoSourcePlayer1.TabIndex = 0;
            this.videoSourcePlayer1.Text = "videoSourcePlayer1";
            this.videoSourcePlayer1.VideoSource = null;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.pictureBox2);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(190, 159);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "图片预览";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(4, 7);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(180, 144);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Location = new System.Drawing.Point(978, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(392, 123);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "会员信息";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(978, 142);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(392, 159);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "收活信息";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(296, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.dataGridView2);
            this.groupBox4.Location = new System.Drawing.Point(15, 309);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1094, 240);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "收活信息列表";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shNo,
            this.shTiaoMa,
            this.shDemo,
            this.shCount,
            this.shMoney,
            this.shPay,
            this.shNumber,
            this.shQuestion,
            this.shMark,
            this.shType,
            this.shColor,
            this.shClass});
            this.dataGridView2.Location = new System.Drawing.Point(0, 20);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.Size = new System.Drawing.Size(1088, 241);
            this.dataGridView2.TabIndex = 0;
            // 
            // shNo
            // 
            this.shNo.HeaderText = "编号";
            this.shNo.Name = "shNo";
            this.shNo.ReadOnly = true;
            this.shNo.Width = 70;
            // 
            // shTiaoMa
            // 
            this.shTiaoMa.HeaderText = "条码";
            this.shTiaoMa.Name = "shTiaoMa";
            this.shTiaoMa.ReadOnly = true;
            // 
            // shDemo
            // 
            this.shDemo.HeaderText = "服务项目";
            this.shDemo.Name = "shDemo";
            this.shDemo.ReadOnly = true;
            // 
            // shCount
            // 
            this.shCount.HeaderText = "点数";
            this.shCount.Name = "shCount";
            this.shCount.ReadOnly = true;
            // 
            // shMoney
            // 
            this.shMoney.HeaderText = "金额";
            this.shMoney.Name = "shMoney";
            this.shMoney.ReadOnly = true;
            this.shMoney.Width = 70;
            // 
            // shPay
            // 
            this.shPay.HeaderText = "应付";
            this.shPay.Name = "shPay";
            this.shPay.ReadOnly = true;
            this.shPay.Width = 70;
            // 
            // shNumber
            // 
            this.shNumber.HeaderText = "架号";
            this.shNumber.Name = "shNumber";
            this.shNumber.ReadOnly = true;
            this.shNumber.Width = 70;
            // 
            // shQuestion
            // 
            this.shQuestion.HeaderText = "常见问题";
            this.shQuestion.Name = "shQuestion";
            this.shQuestion.ReadOnly = true;
            // 
            // shMark
            // 
            this.shMark.HeaderText = "备注信息";
            this.shMark.Name = "shMark";
            this.shMark.ReadOnly = true;
            // 
            // shType
            // 
            this.shType.HeaderText = "品牌";
            this.shType.Name = "shType";
            this.shType.ReadOnly = true;
            // 
            // shColor
            // 
            this.shColor.HeaderText = "颜色";
            this.shColor.Name = "shColor";
            this.shColor.ReadOnly = true;
            this.shColor.Width = 70;
            // 
            // shClass
            // 
            this.shClass.HeaderText = "类别";
            this.shClass.Name = "shClass";
            this.shClass.ReadOnly = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Location = new System.Drawing.Point(1115, 309);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(257, 240);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "票据";
            // 
            // shglform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 561);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1300, 600);
            this.Name = "shglform";
            this.Text = "收活管理";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.shglform_FormClosing);
            this.Load += new System.EventHandler(this.shglform_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsDemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsType;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsPerson;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsSuperMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsCardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsTiaoMa;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn shNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn shTiaoMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn shDemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn shCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn shMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn shPay;
        private System.Windows.Forms.DataGridViewTextBoxColumn shNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn shQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn shMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn shType;
        private System.Windows.Forms.DataGridViewTextBoxColumn shColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn shClass;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 删除本条消费ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 补打标签ToolStripMenuItem;
    }
}