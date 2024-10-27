namespace TestApp
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.testmode = new System.Windows.Forms.CheckBox();
            this.webfriendly = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 47);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(932, 667);
            this.listBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // testmode
            // 
            this.testmode.AutoSize = true;
            this.testmode.Location = new System.Drawing.Point(867, 16);
            this.testmode.Name = "testmode";
            this.testmode.Size = new System.Drawing.Size(77, 17);
            this.testmode.TabIndex = 2;
            this.testmode.Text = "Test Mode";
            this.testmode.UseVisualStyleBackColor = true;
            // 
            // webfriendly
            // 
            this.webfriendly.AutoSize = true;
            this.webfriendly.Location = new System.Drawing.Point(125, 16);
            this.webfriendly.Name = "webfriendly";
            this.webfriendly.Size = new System.Drawing.Size(143, 17);
            this.webfriendly.TabIndex = 3;
            this.webfriendly.Text = "Add File as Web Friendly";
            this.webfriendly.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 728);
            this.Controls.Add(this.webfriendly);
            this.Controls.Add(this.testmode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox testmode;
        private System.Windows.Forms.CheckBox webfriendly;
    }
}

