namespace Thornton.Scheduler
{
    partial class SchedulesList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchedulesList));
            this.grdSchedules = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.specialButton1 = new Office2007Button.SpecialButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.specialButton8 = new Office2007Button.SpecialButton();
            this.specialButton7 = new Office2007Button.SpecialButton();
            this.specialButton6 = new Office2007Button.SpecialButton();
            this.btnForceStart = new Office2007Button.SpecialButton();
            this.specialButton4 = new Office2007Button.SpecialButton();
            this.specialButton3 = new Office2007Button.SpecialButton();
            this.specialButton2 = new Office2007Button.SpecialButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdSchedules)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdSchedules
            // 
            this.grdSchedules.AllowUserToAddRows = false;
            this.grdSchedules.AllowUserToDeleteRows = false;
            this.grdSchedules.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdSchedules.BackgroundColor = System.Drawing.Color.Ivory;
            this.grdSchedules.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdSchedules.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSchedules.Location = new System.Drawing.Point(0, 117);
            this.grdSchedules.Margin = new System.Windows.Forms.Padding(4);
            this.grdSchedules.MultiSelect = false;
            this.grdSchedules.Name = "grdSchedules";
            this.grdSchedules.ReadOnly = true;
            this.grdSchedules.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSchedules.Size = new System.Drawing.Size(989, 408);
            this.grdSchedules.TabIndex = 1;
            this.grdSchedules.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSchedules_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(989, 119);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkOrange;
            this.label1.Location = new System.Drawing.Point(88, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(678, 93);
            this.label1.TabIndex = 1;
            this.label1.Text = "RADIO TRANSFER";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Thornton.Scheduler.Properties.Resources._63960_orangeradiotowericon_clipart;
            this.pictureBox1.Location = new System.Drawing.Point(19, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 98);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // specialButton1
            // 
            this.specialButton1.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.specialButton1.BackColor = System.Drawing.Color.Transparent;
            this.specialButton1.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialButton1.Location = new System.Drawing.Point(12, 15);
            this.specialButton1.Name = "specialButton1";
            this.specialButton1.PressedButton = false;
            this.specialButton1.Size = new System.Drawing.Size(95, 56);
            this.specialButton1.TabIndex = 5;
            this.specialButton1.Text = "Add item";
            this.specialButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.specialButton1.Click += new System.EventHandler(this.addScheduleToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.panel2.Controls.Add(this.specialButton8);
            this.panel2.Controls.Add(this.specialButton7);
            this.panel2.Controls.Add(this.specialButton6);
            this.panel2.Controls.Add(this.btnForceStart);
            this.panel2.Controls.Add(this.specialButton4);
            this.panel2.Controls.Add(this.specialButton3);
            this.panel2.Controls.Add(this.specialButton2);
            this.panel2.Controls.Add(this.specialButton1);
            this.panel2.Location = new System.Drawing.Point(0, 525);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(989, 83);
            this.panel2.TabIndex = 6;
            // 
            // specialButton8
            // 
            this.specialButton8.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.specialButton8.BackColor = System.Drawing.Color.Transparent;
            this.specialButton8.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialButton8.Location = new System.Drawing.Point(332, 15);
            this.specialButton8.Name = "specialButton8";
            this.specialButton8.PressedButton = false;
            this.specialButton8.Size = new System.Drawing.Size(103, 56);
            this.specialButton8.TabIndex = 12;
            this.specialButton8.Text = "Delete item";
            this.specialButton8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.specialButton8.Click += new System.EventHandler(this.specialButton8_Click);
            // 
            // specialButton7
            // 
            this.specialButton7.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.specialButton7.BackColor = System.Drawing.Color.Silver;
            this.specialButton7.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialButton7.Location = new System.Drawing.Point(918, 15);
            this.specialButton7.Name = "specialButton7";
            this.specialButton7.PressedButton = false;
            this.specialButton7.Size = new System.Drawing.Size(60, 56);
            this.specialButton7.TabIndex = 11;
            this.specialButton7.Text = "Quit";
            this.specialButton7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.specialButton7.Click += new System.EventHandler(this.specialButton7_Click);
            // 
            // specialButton6
            // 
            this.specialButton6.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.specialButton6.BackColor = System.Drawing.Color.Transparent;
            this.specialButton6.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialButton6.Location = new System.Drawing.Point(795, 15);
            this.specialButton6.Name = "specialButton6";
            this.specialButton6.PressedButton = false;
            this.specialButton6.Size = new System.Drawing.Size(114, 56);
            this.specialButton6.TabIndex = 10;
            this.specialButton6.Text = "Show History";
            this.specialButton6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.specialButton6.Click += new System.EventHandler(this.specialButton6_Click);
            // 
            // btnForceStart
            // 
            this.btnForceStart.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.btnForceStart.BackColor = System.Drawing.Color.Transparent;
            this.btnForceStart.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnForceStart.Location = new System.Drawing.Point(638, 15);
            this.btnForceStart.Name = "btnForceStart";
            this.btnForceStart.PressedButton = false;
            this.btnForceStart.Size = new System.Drawing.Size(149, 56);
            this.btnForceStart.TabIndex = 9;
            this.btnForceStart.Text = "Force Start item";
            this.btnForceStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnForceStart.Click += new System.EventHandler(this.specialButton5_Click);
            // 
            // specialButton4
            // 
            this.specialButton4.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.specialButton4.BackColor = System.Drawing.Color.Transparent;
            this.specialButton4.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialButton4.Location = new System.Drawing.Point(446, 15);
            this.specialButton4.Name = "specialButton4";
            this.specialButton4.PressedButton = false;
            this.specialButton4.Size = new System.Drawing.Size(183, 56);
            this.specialButton4.TabIndex = 8;
            this.specialButton4.Text = "Enable/Disable item";
            this.specialButton4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.specialButton4.Click += new System.EventHandler(this.specialButton4_Click);
            // 
            // specialButton3
            // 
            this.specialButton3.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.specialButton3.BackColor = System.Drawing.Color.Transparent;
            this.specialButton3.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialButton3.Location = new System.Drawing.Point(223, 15);
            this.specialButton3.Name = "specialButton3";
            this.specialButton3.PressedButton = false;
            this.specialButton3.Size = new System.Drawing.Size(97, 56);
            this.specialButton3.TabIndex = 7;
            this.specialButton3.Text = "Copy item";
            this.specialButton3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.specialButton3.Click += new System.EventHandler(this.specialButton3_Click);
            // 
            // specialButton2
            // 
            this.specialButton2.AdjustImageLocation = new System.Drawing.Point(0, 0);
            this.specialButton2.BackColor = System.Drawing.Color.Transparent;
            this.specialButton2.Font = new System.Drawing.Font("Trebuchet MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.specialButton2.Location = new System.Drawing.Point(118, 15);
            this.specialButton2.Name = "specialButton2";
            this.specialButton2.PressedButton = false;
            this.specialButton2.Size = new System.Drawing.Size(95, 56);
            this.specialButton2.TabIndex = 6;
            this.specialButton2.Text = "Edit item";
            this.specialButton2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.specialButton2.Click += new System.EventHandler(this.specialButton2_Click);
            // 
            // SchedulesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 607);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdSchedules);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "SchedulesList";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Radio Transfer - File Download Entries";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.specialButton7_Click);
            this.Load += new System.EventHandler(this.ConfigureSchedules_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSchedules)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView grdSchedules;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private Office2007Button.SpecialButton specialButton1;
        private System.Windows.Forms.Panel panel2;
        private Office2007Button.SpecialButton specialButton2;
        private Office2007Button.SpecialButton specialButton3;
        private Office2007Button.SpecialButton specialButton7;
        private Office2007Button.SpecialButton specialButton6;
        private Office2007Button.SpecialButton btnForceStart;
        private Office2007Button.SpecialButton specialButton4;
        private Office2007Button.SpecialButton specialButton8;
    }
}