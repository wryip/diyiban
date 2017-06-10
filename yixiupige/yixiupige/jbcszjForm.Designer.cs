namespace yixiupige
{
    partial class jbcszjForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(jbcszjForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TJbutton = new System.Windows.Forms.Button();
            this.TCbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(94, 17);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 23);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(59, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "名称";
            // 
            // TJbutton
            // 
            this.TJbutton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TJbutton.Location = new System.Drawing.Point(41, 72);
            this.TJbutton.Margin = new System.Windows.Forms.Padding(4);
            this.TJbutton.Name = "TJbutton";
            this.TJbutton.Size = new System.Drawing.Size(100, 33);
            this.TJbutton.TabIndex = 2;
            this.TJbutton.Text = "添加";
            this.TJbutton.UseVisualStyleBackColor = true;
            this.TJbutton.Click += new System.EventHandler(this.TJbutton_Click);
            // 
            // TCbutton
            // 
            this.TCbutton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TCbutton.Location = new System.Drawing.Point(199, 72);
            this.TCbutton.Margin = new System.Windows.Forms.Padding(4);
            this.TCbutton.Name = "TCbutton";
            this.TCbutton.Size = new System.Drawing.Size(100, 33);
            this.TCbutton.TabIndex = 3;
            this.TCbutton.Text = "退出";
            this.TCbutton.UseVisualStyleBackColor = true;
            this.TCbutton.Click += new System.EventHandler(this.TCbutton_Click);
            // 
            // jbcszjForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(244)))));
            this.ClientSize = new System.Drawing.Size(352, 122);
            this.Controls.Add(this.TCbutton);
            this.Controls.Add(this.TJbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "jbcszjForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " 增加";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.jbcszjForm_FormClosed);
            this.Load += new System.EventHandler(this.jbcszjForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TJbutton;
        private System.Windows.Forms.Button TCbutton;
    }
}