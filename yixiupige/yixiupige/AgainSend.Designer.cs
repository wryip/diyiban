namespace yixiupige
{
    partial class AgainSend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgainSend));
            this.panel1 = new System.Windows.Forms.Panel();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.XZ = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.jcNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcCardNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcPinPai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcQMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcStaff = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcBeginDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcEndDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcZT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcImgUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcDanNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcPaiNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcQuestion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jcPression = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lsdm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(17, 17);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1157, 564);
            this.panel1.TabIndex = 0;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView3.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.XZ,
            this.jcNo,
            this.jcID,
            this.jcCardNumber,
            this.jcName,
            this.jcPinPai,
            this.jcQMoney,
            this.jcType,
            this.jcColor,
            this.jcStaff,
            this.jcBeginDate,
            this.jcEndDate,
            this.jcZT,
            this.jcAddress,
            this.jcImgUrl,
            this.jcDanNumber,
            this.jcPaiNumber,
            this.jcRemark,
            this.jcQuestion,
            this.jcPression,
            this.lsdm});
            this.dataGridView3.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView3.Location = new System.Drawing.Point(4, 24);
            this.dataGridView3.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(1126, 353);
            this.dataGridView3.TabIndex = 2;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // XZ
            // 
            this.XZ.HeaderText = "选择";
            this.XZ.Name = "XZ";
            this.XZ.ReadOnly = true;
            // 
            // jcNo
            // 
            this.jcNo.DataPropertyName = "jcNo";
            this.jcNo.HeaderText = "编号";
            this.jcNo.Name = "jcNo";
            this.jcNo.ReadOnly = true;
            // 
            // jcID
            // 
            this.jcID.DataPropertyName = "jcID";
            this.jcID.HeaderText = "ID";
            this.jcID.Name = "jcID";
            this.jcID.ReadOnly = true;
            this.jcID.Visible = false;
            // 
            // jcCardNumber
            // 
            this.jcCardNumber.DataPropertyName = "jcCardNumber";
            this.jcCardNumber.HeaderText = "卡号";
            this.jcCardNumber.Name = "jcCardNumber";
            this.jcCardNumber.ReadOnly = true;
            // 
            // jcName
            // 
            this.jcName.DataPropertyName = "jcName";
            this.jcName.HeaderText = "姓名";
            this.jcName.Name = "jcName";
            this.jcName.ReadOnly = true;
            // 
            // jcPinPai
            // 
            this.jcPinPai.DataPropertyName = "jcPinPai";
            this.jcPinPai.HeaderText = "品牌";
            this.jcPinPai.Name = "jcPinPai";
            this.jcPinPai.ReadOnly = true;
            // 
            // jcQMoney
            // 
            this.jcQMoney.DataPropertyName = "jcQMoney";
            this.jcQMoney.HeaderText = "欠款";
            this.jcQMoney.Name = "jcQMoney";
            this.jcQMoney.ReadOnly = true;
            this.jcQMoney.Visible = false;
            // 
            // jcType
            // 
            this.jcType.DataPropertyName = "jcType";
            this.jcType.HeaderText = "寄存类型";
            this.jcType.Name = "jcType";
            this.jcType.ReadOnly = true;
            // 
            // jcColor
            // 
            this.jcColor.DataPropertyName = "jcColor";
            this.jcColor.HeaderText = "颜色";
            this.jcColor.Name = "jcColor";
            this.jcColor.ReadOnly = true;
            // 
            // jcStaff
            // 
            this.jcStaff.DataPropertyName = "jcStaff";
            this.jcStaff.HeaderText = "服务项目";
            this.jcStaff.Name = "jcStaff";
            this.jcStaff.ReadOnly = true;
            // 
            // jcBeginDate
            // 
            this.jcBeginDate.DataPropertyName = "jcBeginDate";
            this.jcBeginDate.HeaderText = "寄存时间";
            this.jcBeginDate.Name = "jcBeginDate";
            this.jcBeginDate.ReadOnly = true;
            // 
            // jcEndDate
            // 
            this.jcEndDate.DataPropertyName = "jcEndDate";
            this.jcEndDate.HeaderText = "取走时间";
            this.jcEndDate.Name = "jcEndDate";
            this.jcEndDate.ReadOnly = true;
            this.jcEndDate.Visible = false;
            // 
            // jcZT
            // 
            this.jcZT.DataPropertyName = "jcZT";
            this.jcZT.HeaderText = "状态";
            this.jcZT.Name = "jcZT";
            this.jcZT.ReadOnly = true;
            this.jcZT.Visible = false;
            // 
            // jcAddress
            // 
            this.jcAddress.DataPropertyName = "jcAddress";
            this.jcAddress.HeaderText = "地址";
            this.jcAddress.Name = "jcAddress";
            this.jcAddress.ReadOnly = true;
            // 
            // jcImgUrl
            // 
            this.jcImgUrl.DataPropertyName = "jcImgUrl";
            this.jcImgUrl.HeaderText = "图片路径";
            this.jcImgUrl.Name = "jcImgUrl";
            this.jcImgUrl.ReadOnly = true;
            this.jcImgUrl.Visible = false;
            // 
            // jcDanNumber
            // 
            this.jcDanNumber.DataPropertyName = "jcDanNumber";
            this.jcDanNumber.HeaderText = "单号";
            this.jcDanNumber.Name = "jcDanNumber";
            this.jcDanNumber.ReadOnly = true;
            this.jcDanNumber.Visible = false;
            // 
            // jcPaiNumber
            // 
            this.jcPaiNumber.DataPropertyName = "jcPaiNumber";
            this.jcPaiNumber.HeaderText = "牌号";
            this.jcPaiNumber.Name = "jcPaiNumber";
            this.jcPaiNumber.ReadOnly = true;
            this.jcPaiNumber.Visible = false;
            // 
            // jcRemark
            // 
            this.jcRemark.DataPropertyName = "jcRemark";
            this.jcRemark.HeaderText = "备注";
            this.jcRemark.Name = "jcRemark";
            this.jcRemark.ReadOnly = true;
            this.jcRemark.Visible = false;
            // 
            // jcQuestion
            // 
            this.jcQuestion.DataPropertyName = "jcQuestion";
            this.jcQuestion.HeaderText = "常见问题";
            this.jcQuestion.Name = "jcQuestion";
            this.jcQuestion.ReadOnly = true;
            this.jcQuestion.Visible = false;
            // 
            // jcPression
            // 
            this.jcPression.DataPropertyName = "jcPression";
            this.jcPression.HeaderText = "业务员";
            this.jcPression.Name = "jcPression";
            this.jcPression.ReadOnly = true;
            // 
            // lsdm
            // 
            this.lsdm.DataPropertyName = "lsdm";
            this.lsdm.HeaderText = "连锁店名";
            this.lsdm.Name = "lsdm";
            this.lsdm.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(960, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "0";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("微软雅黑 Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button3.Location = new System.Drawing.Point(788, 36);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 40);
            this.button3.TabIndex = 3;
            this.button3.Text = "搜索";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(472, 41);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(255, 31);
            this.textBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑 Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button2.Location = new System.Drawing.Point(303, 34);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(124, 48);
            this.button2.TabIndex = 1;
            this.button2.Text = "送洗";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑 Light", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.button1.Location = new System.Drawing.Point(95, 33);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 49);
            this.button1.TabIndex = 0;
            this.button1.Text = "全选";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Location = new System.Drawing.Point(9, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1134, 112);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(58, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 6;
            this.label2.Text = "搜索信息";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.dataGridView3);
            this.panel3.Location = new System.Drawing.Point(9, 165);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1134, 381);
            this.panel3.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("华文中宋", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(63, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "数据显示";
            // 
            // AgainSend
            // 
            this.AcceptButton = this.button3;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1191, 597);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AgainSend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "继续送洗";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgainSend_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn XZ;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcID;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcCardNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcName;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcPinPai;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcQMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcType;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcStaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcBeginDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcEndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcZT;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcImgUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcDanNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcPaiNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcQuestion;
        private System.Windows.Forms.DataGridViewTextBoxColumn jcPression;
        private System.Windows.Forms.DataGridViewTextBoxColumn lsdm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
    }
}