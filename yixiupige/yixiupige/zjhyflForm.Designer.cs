namespace yixiupige
{
    partial class zjhyflForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.hymctextBox = new System.Windows.Forms.TextBox();
            this.splxcomboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.bkjetextBox = new System.Windows.Forms.TextBox();
            this.czcstextBox = new System.Windows.Forms.TextBox();
            this.spzktextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "会员名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "办卡类型：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "商品折扣：";
            // 
            // hymctextBox
            // 
            this.hymctextBox.Location = new System.Drawing.Point(124, 35);
            this.hymctextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hymctextBox.Name = "hymctextBox";
            this.hymctextBox.Size = new System.Drawing.Size(323, 25);
            this.hymctextBox.TabIndex = 3;
            // 
            // splxcomboBox
            // 
            this.splxcomboBox.FormattingEnabled = true;
            this.splxcomboBox.Items.AddRange(new object[] {
            "计次卡",
            "折扣卡",
            "储值卡"});
            this.splxcomboBox.Location = new System.Drawing.Point(124, 72);
            this.splxcomboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splxcomboBox.Name = "splxcomboBox";
            this.splxcomboBox.Size = new System.Drawing.Size(75, 23);
            this.splxcomboBox.TabIndex = 4;
            this.splxcomboBox.SelectedIndexChanged += new System.EventHandler(this.splxcomboBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(220, 79);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "办卡金额：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(220, 114);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "充值次数：";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(139, 154);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "增加";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(283, 154);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 29);
            this.button2.TabIndex = 8;
            this.button2.Text = "退出";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // bkjetextBox
            // 
            this.bkjetextBox.Location = new System.Drawing.Point(315, 75);
            this.bkjetextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bkjetextBox.Name = "bkjetextBox";
            this.bkjetextBox.Size = new System.Drawing.Size(132, 25);
            this.bkjetextBox.TabIndex = 9;
            // 
            // czcstextBox
            // 
            this.czcstextBox.Location = new System.Drawing.Point(315, 108);
            this.czcstextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.czcstextBox.Name = "czcstextBox";
            this.czcstextBox.Size = new System.Drawing.Size(132, 25);
            this.czcstextBox.TabIndex = 10;
            // 
            // spzktextBox
            // 
            this.spzktextBox.Location = new System.Drawing.Point(124, 106);
            this.spzktextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.spzktextBox.Name = "spzktextBox";
            this.spzktextBox.ReadOnly = true;
            this.spzktextBox.Size = new System.Drawing.Size(75, 25);
            this.spzktextBox.TabIndex = 11;
            this.spzktextBox.Text = "100";
            // 
            // zjhyflForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 216);
            this.Controls.Add(this.spzktextBox);
            this.Controls.Add(this.czcstextBox);
            this.Controls.Add(this.bkjetextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.splxcomboBox);
            this.Controls.Add(this.hymctextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "zjhyflForm";
            this.Text = "增加会员分类";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.zjhyflForm_FormClosed);
            this.Load += new System.EventHandler(this.zjhyflForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox hymctextBox;
        private System.Windows.Forms.ComboBox splxcomboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox bkjetextBox;
        private System.Windows.Forms.TextBox czcstextBox;
        private System.Windows.Forms.TextBox spzktextBox;
    }
}