﻿namespace yixiupige
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
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("全部");
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.glNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glCardNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glQianKuan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glClass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glDemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glMark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glTel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.glDanNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcImgUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1820, 676);
            this.panel1.TabIndex = 0;
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
            this.glCardNo,
            this.glName,
            this.glQianKuan,
            this.glClass,
            this.glType,
            this.glColor,
            this.glDemo,
            this.glDate,
            this.glMark,
            this.glQuestion,
            this.glTel,
            this.glDanNo,
            this.jcImgUrl});
            this.dataGridView1.Location = new System.Drawing.Point(8, 26);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1468, 615);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.dataGridView1);
            this.groupBox4.Location = new System.Drawing.Point(304, 16);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(1498, 649);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "寄存信息";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(11, 24);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4);
            this.treeView1.Name = "treeView1";
            treeNode10.Name = "treeAll";
            treeNode10.Text = "全部";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10});
            this.treeView1.Size = new System.Drawing.Size(248, 374);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.treeView1);
            this.groupBox3.Location = new System.Drawing.Point(29, 16);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(267, 406);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "寄存分类";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Location = new System.Drawing.Point(29, 430);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(267, 235);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "图片预览";
            // 
            // glNo
            // 
            this.glNo.DataPropertyName = "jcNo";
            this.glNo.HeaderText = "编号";
            this.glNo.Name = "glNo";
            this.glNo.ReadOnly = true;
            this.glNo.Width = 111;
            // 
            // glCardNo
            // 
            this.glCardNo.DataPropertyName = "jcCardNumber";
            this.glCardNo.HeaderText = "卡号";
            this.glCardNo.Name = "glCardNo";
            this.glCardNo.ReadOnly = true;
            this.glCardNo.Width = 110;
            // 
            // glName
            // 
            this.glName.DataPropertyName = "jcName";
            this.glName.HeaderText = "姓名";
            this.glName.Name = "glName";
            this.glName.ReadOnly = true;
            this.glName.Width = 111;
            // 
            // glQianKuan
            // 
            this.glQianKuan.DataPropertyName = "jcQMoney";
            this.glQianKuan.HeaderText = "欠款";
            this.glQianKuan.Name = "glQianKuan";
            this.glQianKuan.ReadOnly = true;
            this.glQianKuan.Width = 111;
            // 
            // glClass
            // 
            this.glClass.DataPropertyName = "jcType";
            this.glClass.HeaderText = "类别";
            this.glClass.Name = "glClass";
            this.glClass.ReadOnly = true;
            this.glClass.Width = 110;
            // 
            // glType
            // 
            this.glType.DataPropertyName = "jcPinPai";
            this.glType.HeaderText = "品牌";
            this.glType.Name = "glType";
            this.glType.ReadOnly = true;
            this.glType.Width = 111;
            // 
            // glColor
            // 
            this.glColor.DataPropertyName = "jcColor";
            this.glColor.HeaderText = "颜色";
            this.glColor.Name = "glColor";
            this.glColor.ReadOnly = true;
            this.glColor.Width = 111;
            // 
            // glDemo
            // 
            this.glDemo.DataPropertyName = "jcStaff";
            this.glDemo.HeaderText = "服务项目";
            this.glDemo.Name = "glDemo";
            this.glDemo.ReadOnly = true;
            this.glDemo.Width = 111;
            // 
            // glDate
            // 
            this.glDate.DataPropertyName = "jcBeginDate";
            this.glDate.HeaderText = "寄存时间";
            this.glDate.Name = "glDate";
            this.glDate.ReadOnly = true;
            this.glDate.Width = 110;
            // 
            // glMark
            // 
            this.glMark.DataPropertyName = "jcEndDate";
            this.glMark.HeaderText = "取走时间";
            this.glMark.Name = "glMark";
            this.glMark.ReadOnly = true;
            this.glMark.Width = 111;
            // 
            // glQuestion
            // 
            this.glQuestion.DataPropertyName = "jcZT";
            this.glQuestion.HeaderText = "状态";
            this.glQuestion.Name = "glQuestion";
            this.glQuestion.ReadOnly = true;
            this.glQuestion.Width = 111;
            // 
            // glTel
            // 
            this.glTel.DataPropertyName = "jcAddress";
            this.glTel.HeaderText = "物品位置";
            this.glTel.Name = "glTel";
            this.glTel.ReadOnly = true;
            this.glTel.Width = 110;
            // 
            // glDanNo
            // 
            this.glDanNo.DataPropertyName = "jcID";
            this.glDanNo.HeaderText = "物品ID";
            this.glDanNo.Name = "glDanNo";
            this.glDanNo.ReadOnly = true;
            this.glDanNo.Width = 111;
            // 
            // jcImgUrl
            // 
            this.jcImgUrl.DataPropertyName = "jcImgUrl";
            this.jcImgUrl.HeaderText = "图片路径";
            this.jcImgUrl.Name = "jcImgUrl";
            this.jcImgUrl.ReadOnly = true;
            this.jcImgUrl.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(249, 201);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // jcglform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1843, 701);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "jcglform";
            this.Text = "寄存管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.jcglform_FormClosing);
            this.Load += new System.EventHandler(this.jcglform_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn glNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn glCardNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn glName;
        private System.Windows.Forms.DataGridViewTextBoxColumn glQianKuan;
        private System.Windows.Forms.DataGridViewTextBoxColumn glClass;
        private System.Windows.Forms.DataGridViewTextBoxColumn glType;
        private System.Windows.Forms.DataGridViewTextBoxColumn glColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn glDemo;
        private System.Windows.Forms.DataGridViewTextBoxColumn glDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn glMark;
        private System.Windows.Forms.DataGridViewTextBoxColumn glQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn glTel;
        private System.Windows.Forms.DataGridViewTextBoxColumn glDanNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcImgUrl;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}