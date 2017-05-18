namespace yixiupige
{
    partial class ygglForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sfzh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lxdh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jtzz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button4 = new System.Windows.Forms.Button();
            this.scbutton = new System.Windows.Forms.Button();
            this.xgbutton = new System.Windows.Forms.Button();
            this.zjbutton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(636, 337);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.xm,
            this.gz,
            this.sfzh,
            this.xb,
            this.lxdh,
            this.jtzz,
            this.bz});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 19);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(630, 315);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "序号";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // xm
            // 
            this.xm.DataPropertyName = "stName";
            this.xm.HeaderText = "姓名";
            this.xm.Name = "xm";
            this.xm.ReadOnly = true;
            // 
            // gz
            // 
            this.gz.DataPropertyName = "stType";
            this.gz.HeaderText = "工种";
            this.gz.Name = "gz";
            this.gz.ReadOnly = true;
            // 
            // sfzh
            // 
            this.sfzh.DataPropertyName = "stDocument";
            this.sfzh.HeaderText = "身份证号";
            this.sfzh.Name = "sfzh";
            this.sfzh.ReadOnly = true;
            // 
            // xb
            // 
            this.xb.DataPropertyName = "stSex";
            this.xb.HeaderText = "性别";
            this.xb.Name = "xb";
            this.xb.ReadOnly = true;
            // 
            // lxdh
            // 
            this.lxdh.DataPropertyName = "stTel";
            this.lxdh.HeaderText = "联系电话";
            this.lxdh.Name = "lxdh";
            this.lxdh.ReadOnly = true;
            // 
            // jtzz
            // 
            this.jtzz.DataPropertyName = "stAdd";
            this.jtzz.HeaderText = "家庭住址";
            this.jtzz.Name = "jtzz";
            this.jtzz.ReadOnly = true;
            // 
            // bz
            // 
            this.bz.DataPropertyName = "stRemark";
            this.bz.HeaderText = "备注";
            this.bz.Name = "bz";
            this.bz.ReadOnly = true;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Image = global::yixiupige.Properties.Resources._4505;
            this.button4.Location = new System.Drawing.Point(258, 9);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 76);
            this.button4.TabIndex = 3;
            this.button4.Text = "\r\n退出";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // scbutton
            // 
            this.scbutton.BackColor = System.Drawing.Color.Transparent;
            this.scbutton.FlatAppearance.BorderSize = 0;
            this.scbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.scbutton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scbutton.Image = global::yixiupige.Properties.Resources._6962;
            this.scbutton.Location = new System.Drawing.Point(177, 9);
            this.scbutton.Name = "scbutton";
            this.scbutton.Size = new System.Drawing.Size(75, 76);
            this.scbutton.TabIndex = 2;
            this.scbutton.Text = "\r\n删除\r\n";
            this.scbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.scbutton.UseVisualStyleBackColor = false;
            this.scbutton.Click += new System.EventHandler(this.scbutton_Click);
            // 
            // xgbutton
            // 
            this.xgbutton.BackColor = System.Drawing.Color.Transparent;
            this.xgbutton.FlatAppearance.BorderSize = 0;
            this.xgbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.xgbutton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.xgbutton.Image = global::yixiupige.Properties.Resources._1631;
            this.xgbutton.Location = new System.Drawing.Point(96, 13);
            this.xgbutton.Name = "xgbutton";
            this.xgbutton.Size = new System.Drawing.Size(75, 71);
            this.xgbutton.TabIndex = 1;
            this.xgbutton.Text = "\r\n修改";
            this.xgbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.xgbutton.UseVisualStyleBackColor = false;
            this.xgbutton.Click += new System.EventHandler(this.xgbutton_Click);
            // 
            // zjbutton
            // 
            this.zjbutton.BackColor = System.Drawing.Color.Transparent;
            this.zjbutton.FlatAppearance.BorderSize = 0;
            this.zjbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.zjbutton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zjbutton.Image = global::yixiupige.Properties.Resources._1133944;
            this.zjbutton.Location = new System.Drawing.Point(15, 12);
            this.zjbutton.Name = "zjbutton";
            this.zjbutton.Size = new System.Drawing.Size(75, 71);
            this.zjbutton.TabIndex = 0;
            this.zjbutton.Text = "\r\n增加";
            this.zjbutton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.zjbutton.UseVisualStyleBackColor = false;
            this.zjbutton.Click += new System.EventHandler(this.zjbutton_Click);
            // 
            // ygglForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.BackgroundImage = global::yixiupige.Properties.Resources._1;
            this.ClientSize = new System.Drawing.Size(660, 438);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.scbutton);
            this.Controls.Add(this.xgbutton);
            this.Controls.Add(this.zjbutton);
            this.MinimizeBox = false;
            this.Name = "ygglForm";
            this.Text = "员工管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ygglForm_FormClosed);
            this.Load += new System.EventHandler(this.ygglForm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button zjbutton;
        private System.Windows.Forms.Button xgbutton;
        private System.Windows.Forms.Button scbutton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn xm;
        private System.Windows.Forms.DataGridViewTextBoxColumn gz;
        private System.Windows.Forms.DataGridViewTextBoxColumn sfzh;
        private System.Windows.Forms.DataGridViewTextBoxColumn xb;
        private System.Windows.Forms.DataGridViewTextBoxColumn lxdh;
        private System.Windows.Forms.DataGridViewTextBoxColumn jtzz;
        private System.Windows.Forms.DataGridViewTextBoxColumn bz;
    }
}