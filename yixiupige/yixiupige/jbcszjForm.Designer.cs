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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TJbutton = new System.Windows.Forms.Button();
            this.TCbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 21);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "名称";
            // 
            // TJbutton
            // 
            this.TJbutton.Location = new System.Drawing.Point(31, 51);
            this.TJbutton.Name = "TJbutton";
            this.TJbutton.Size = new System.Drawing.Size(75, 23);
            this.TJbutton.TabIndex = 2;
            this.TJbutton.Text = "添加";
            this.TJbutton.UseVisualStyleBackColor = true;
            // 
            // TCbutton
            // 
            this.TCbutton.Location = new System.Drawing.Point(149, 51);
            this.TCbutton.Name = "TCbutton";
            this.TCbutton.Size = new System.Drawing.Size(75, 23);
            this.TCbutton.TabIndex = 3;
            this.TCbutton.Text = "退出";
            this.TCbutton.UseVisualStyleBackColor = true;
            this.TCbutton.Click += new System.EventHandler(this.TCbutton_Click);
            // 
            // jbcszjForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(264, 86);
            this.Controls.Add(this.TCbutton);
            this.Controls.Add(this.TJbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.MaximizeBox = false;
            this.Name = "jbcszjForm";
            this.Text = " ";
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