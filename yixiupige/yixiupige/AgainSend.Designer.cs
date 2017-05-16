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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(13, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(868, 423);
            this.panel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.dataGridView3);
            this.groupBox2.Location = new System.Drawing.Point(4, 126);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(861, 294);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "数据显示";
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView3.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dataGridView3.Location = new System.Drawing.Point(3, 20);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowTemplate.Height = 23;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(852, 268);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(861, 115);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户操作";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(757, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "0";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(571, 44);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(91, 39);
            this.button3.TabIndex = 3;
            this.button3.Text = "搜索";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(326, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(192, 31);
            this.textBox1.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(189, 39);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(101, 45);
            this.button2.TabIndex = 1;
            this.button2.Text = "送洗";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(36, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "全选";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AgainSend
            // 
            this.AcceptButton = this.button3;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 448);
            this.Controls.Add(this.panel1);
            this.Name = "AgainSend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "继续送洗";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AgainSend_FormClosing);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
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
    }
}