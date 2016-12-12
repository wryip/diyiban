namespace yixiupige
{
    partial class lsdglForm
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
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lxr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lxdh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dxzd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dxnr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zjdy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yldy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dynr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcsj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button4
            // 
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Image = global::yixiupige.Properties.Resources._4505;
            this.button4.Location = new System.Drawing.Point(332, 4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(56, 86);
            this.button4.TabIndex = 3;
            this.button4.Text = "\r\n退出";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Image = global::yixiupige.Properties.Resources._532579;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.Location = new System.Drawing.Point(221, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 86);
            this.button3.TabIndex = 2;
            this.button3.Text = "\r\n删除";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Image = global::yixiupige.Properties.Resources._556807;
            this.button2.Location = new System.Drawing.Point(118, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 86);
            this.button2.TabIndex = 1;
            this.button2.Text = "\r\n修改";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Image = global::yixiupige.Properties.Resources._1166404;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.Location = new System.Drawing.Point(15, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(65, 78);
            this.button1.TabIndex = 0;
            this.button1.Text = "\r\n增加";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(12, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(629, 352);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.mc,
            this.lxr,
            this.lxdh,
            this.dz,
            this.dxzd,
            this.dxnr,
            this.dy,
            this.zjdy,
            this.yldy,
            this.dynr,
            this.spid,
            this.jcsj,
            this.bz});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(623, 332);
            this.dataGridView1.TabIndex = 0;
            // 
            // mc
            // 
            this.mc.HeaderText = "名称";
            this.mc.Name = "mc";
            this.mc.ReadOnly = true;
            // 
            // lxr
            // 
            this.lxr.HeaderText = "联系人";
            this.lxr.Name = "lxr";
            this.lxr.ReadOnly = true;
            // 
            // lxdh
            // 
            this.lxdh.HeaderText = "联系电话";
            this.lxdh.Name = "lxdh";
            this.lxdh.ReadOnly = true;
            // 
            // dz
            // 
            this.dz.HeaderText = "地址";
            this.dz.Name = "dz";
            this.dz.ReadOnly = true;
            // 
            // dxzd
            // 
            this.dxzd.HeaderText = "短信自动";
            this.dxzd.Name = "dxzd";
            this.dxzd.ReadOnly = true;
            // 
            // dxnr
            // 
            this.dxnr.HeaderText = "短信内容";
            this.dxnr.Name = "dxnr";
            this.dxnr.ReadOnly = true;
            // 
            // dy
            // 
            this.dy.HeaderText = "打印";
            this.dy.Name = "dy";
            this.dy.ReadOnly = true;
            // 
            // zjdy
            // 
            this.zjdy.HeaderText = "直接打印";
            this.zjdy.Name = "zjdy";
            this.zjdy.ReadOnly = true;
            // 
            // yldy
            // 
            this.yldy.HeaderText = "预览打印";
            this.yldy.Name = "yldy";
            this.yldy.ReadOnly = true;
            // 
            // dynr
            // 
            this.dynr.HeaderText = "打印内容";
            this.dynr.Name = "dynr";
            this.dynr.ReadOnly = true;
            // 
            // spid
            // 
            this.spid.HeaderText = "视频ID";
            this.spid.Name = "spid";
            this.spid.ReadOnly = true;
            // 
            // jcsj
            // 
            this.jcsj.HeaderText = "寄存时间";
            this.jcsj.Name = "jcsj";
            this.jcsj.ReadOnly = true;
            // 
            // bz
            // 
            this.bz.HeaderText = "备注";
            this.bz.Name = "bz";
            this.bz.ReadOnly = true;
            // 
            // lsdglForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(653, 464);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MaximizeBox = false;
            this.Name = "lsdglForm";
            this.Text = "连锁店管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.lsdglForm_FormClosed);
            this.Load += new System.EventHandler(this.lsdglForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn mc;
        private System.Windows.Forms.DataGridViewTextBoxColumn lxr;
        private System.Windows.Forms.DataGridViewTextBoxColumn lxdh;
        private System.Windows.Forms.DataGridViewTextBoxColumn dz;
        private System.Windows.Forms.DataGridViewTextBoxColumn dxzd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dxnr;
        private System.Windows.Forms.DataGridViewTextBoxColumn dy;
        private System.Windows.Forms.DataGridViewTextBoxColumn zjdy;
        private System.Windows.Forms.DataGridViewTextBoxColumn yldy;
        private System.Windows.Forms.DataGridViewTextBoxColumn dynr;
        private System.Windows.Forms.DataGridViewTextBoxColumn spid;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcsj;
        private System.Windows.Forms.DataGridViewTextBoxColumn bz;
    }
}