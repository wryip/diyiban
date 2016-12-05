namespace yixiupige
{
    partial class jcglform
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("皮衣");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("皮鞋");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("皮包");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("全部", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.glNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glTiaoMa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glCardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glQianKuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glDemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glDanNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "会员信息";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(82, 72);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "会员余额：";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(82, 45);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "会员姓名：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(82, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员卡号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Location = new System.Drawing.Point(13, 120);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 167);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图片预览";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.treeView1);
            this.groupBox3.Location = new System.Drawing.Point(13, 294);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 255);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "寄存分类";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(7, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "treePiYi";
            treeNode1.Text = "皮衣";
            treeNode2.Name = "treePiXie";
            treeNode2.Text = "皮鞋";
            treeNode3.Name = "treePiBao";
            treeNode3.Text = "皮包";
            treeNode4.Name = "treeAll";
            treeNode4.Text = "全部";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(187, 237);
            this.treeView1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Controls.Add(this.comboBox1);
            this.groupBox4.Controls.Add(this.textBox4);
            this.groupBox4.Controls.Add(this.checkBox1);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.button2);
            this.groupBox4.Controls.Add(this.button1);
            this.groupBox4.Location = new System.Drawing.Point(220, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1152, 536);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "寄存信息";
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
            this.glNo,
            this.glTiaoMa,
            this.glCardNo,
            this.glName,
            this.glQianKuan,
            this.glNumber,
            this.glDate,
            this.glDemo,
            this.glMark,
            this.glQuestion,
            this.glTel,
            this.glType,
            this.glColor,
            this.glClass,
            this.glDanNo});
            this.dataGridView1.Location = new System.Drawing.Point(7, 61);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView1.Size = new System.Drawing.Size(1139, 469);
            this.dataGridView1.TabIndex = 4;
            // 
            // glNo
            // 
            this.glNo.HeaderText = "编号";
            this.glNo.Name = "glNo";
            this.glNo.ReadOnly = true;
            // 
            // glTiaoMa
            // 
            this.glTiaoMa.HeaderText = "条码";
            this.glTiaoMa.Name = "glTiaoMa";
            this.glTiaoMa.ReadOnly = true;
            // 
            // glCardNo
            // 
            this.glCardNo.HeaderText = "卡号";
            this.glCardNo.Name = "glCardNo";
            this.glCardNo.ReadOnly = true;
            // 
            // glName
            // 
            this.glName.HeaderText = "姓名";
            this.glName.Name = "glName";
            this.glName.ReadOnly = true;
            // 
            // glQianKuan
            // 
            this.glQianKuan.HeaderText = "欠款";
            this.glQianKuan.Name = "glQianKuan";
            this.glQianKuan.ReadOnly = true;
            // 
            // glNumber
            // 
            this.glNumber.HeaderText = "架号";
            this.glNumber.Name = "glNumber";
            this.glNumber.ReadOnly = true;
            // 
            // glDate
            // 
            this.glDate.HeaderText = "寄存时间";
            this.glDate.Name = "glDate";
            this.glDate.ReadOnly = true;
            // 
            // glDemo
            // 
            this.glDemo.HeaderText = "服务项目";
            this.glDemo.Name = "glDemo";
            this.glDemo.ReadOnly = true;
            // 
            // glMark
            // 
            this.glMark.HeaderText = "备注";
            this.glMark.Name = "glMark";
            this.glMark.ReadOnly = true;
            // 
            // glQuestion
            // 
            this.glQuestion.HeaderText = "问题";
            this.glQuestion.Name = "glQuestion";
            this.glQuestion.ReadOnly = true;
            // 
            // glTel
            // 
            this.glTel.HeaderText = "电话";
            this.glTel.Name = "glTel";
            this.glTel.ReadOnly = true;
            // 
            // glType
            // 
            this.glType.HeaderText = "品牌";
            this.glType.Name = "glType";
            this.glType.ReadOnly = true;
            // 
            // glColor
            // 
            this.glColor.HeaderText = "颜色";
            this.glColor.Name = "glColor";
            this.glColor.ReadOnly = true;
            // 
            // glClass
            // 
            this.glClass.HeaderText = "类别";
            this.glClass.Name = "glClass";
            this.glClass.ReadOnly = true;
            // 
            // glDanNo
            // 
            this.glDanNo.HeaderText = "单号";
            this.glDanNo.Name = "glDanNo";
            this.glDanNo.ReadOnly = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "姓名",
            "卡号",
            "电话",
            "条码",
            "架号",
            "品牌",
            "颜色",
            "单号"});
            this.comboBox1.Location = new System.Drawing.Point(712, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 3;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(495, 26);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(179, 21);
            this.textBox4.TabIndex = 2;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(373, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "打印小票";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(262, 21);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 30);
            this.button3.TabIndex = 0;
            this.button3.Text = "取走";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(158, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 30);
            this.button2.TabIndex = 0;
            this.button2.Text = "全选";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(55, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 0;
            this.button1.Text = "反选";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // jcglform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 561);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "jcglform";
            this.Text = "寄存管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.jcglform_FormClosing);
            this.Load += new System.EventHandler(this.jcglform_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn glNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn glTiaoMa;
        private System.Windows.Forms.DataGridViewTextBoxColumn glCardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn glName;
        private System.Windows.Forms.DataGridViewTextBoxColumn glQianKuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn glNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn glDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn glDemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn glMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn glQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn glTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn glType;
        private System.Windows.Forms.DataGridViewTextBoxColumn glColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn glClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn glDanNo;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}