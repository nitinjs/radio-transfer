namespace Thornton.Scheduler
{
    partial class MacroBuilder
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacroBuilder));
            this.txtOutputFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstDay = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAppendType = new System.Windows.Forms.CheckBox();
            this.lstOffset = new System.Windows.Forms.ListBox();
            this.lblMacroResult = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tlMacroList = new FerretLib.WinForms.Controls.TagListControl();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tt1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblMacroExpression = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutputFileName
            // 
            this.txtOutputFileName.Location = new System.Drawing.Point(134, 12);
            this.txtOutputFileName.Multiline = true;
            this.txtOutputFileName.Name = "txtOutputFileName";
            this.txtOutputFileName.ShortcutsEnabled = false;
            this.txtOutputFileName.Size = new System.Drawing.Size(602, 22);
            this.txtOutputFileName.TabIndex = 0;
            this.txtOutputFileName.Text = "Test.txt";
            this.txtOutputFileName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtOutputFileName_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Output file name:";
            // 
            // lstDay
            // 
            this.lstDay.FormattingEnabled = true;
            this.lstDay.ItemHeight = 16;
            this.lstDay.Location = new System.Drawing.Point(21, 61);
            this.lstDay.Name = "lstDay";
            this.lstDay.Size = new System.Drawing.Size(190, 212);
            this.lstDay.TabIndex = 2;
            this.lstDay.SelectedIndexChanged += new System.EventHandler(this.tlMacroList_TagAdded);
            this.lstDay.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstDay_MouseDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Day offset:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(235, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time/Date entries:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblMacroExpression);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.chkAppendType);
            this.groupBox1.Controls.Add(this.lstOffset);
            this.groupBox1.Controls.Add(this.lblMacroResult);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tlMacroList);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lstDay);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 49);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(721, 454);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Macro Builder - You can generate custom macto here";
            // 
            // chkAppendType
            // 
            this.chkAppendType.AutoSize = true;
            this.chkAppendType.Checked = true;
            this.chkAppendType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAppendType.Location = new System.Drawing.Point(21, 365);
            this.chkAppendType.Name = "chkAppendType";
            this.chkAppendType.Size = new System.Drawing.Size(187, 21);
            this.chkAppendType.TabIndex = 13;
            this.chkAppendType.Text = "Add micro after file name";
            this.chkAppendType.UseVisualStyleBackColor = true;
            this.chkAppendType.CheckedChanged += new System.EventHandler(this.tlMacroList_TagAdded);
            // 
            // lstOffset
            // 
            this.lstOffset.FormattingEnabled = true;
            this.lstOffset.ItemHeight = 16;
            this.lstOffset.Location = new System.Drawing.Point(238, 61);
            this.lstOffset.Name = "lstOffset";
            this.lstOffset.Size = new System.Drawing.Size(462, 212);
            this.lstOffset.TabIndex = 12;
            this.lstOffset.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lstOffset_MouseDoubleClick);
            this.lstOffset.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lstCars_MouseMove);
            // 
            // lblMacroResult
            // 
            this.lblMacroResult.AutoSize = true;
            this.lblMacroResult.Location = new System.Drawing.Point(148, 419);
            this.lblMacroResult.Name = "lblMacroResult";
            this.lblMacroResult.Size = new System.Drawing.Size(142, 17);
            this.lblMacroResult.TabIndex = 9;
            this.lblMacroResult.Text = "Test 25-May-2018.txt";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 419);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 17);
            this.label5.TabIndex = 8;
            this.label5.Text = "Macro Result:";
            // 
            // tlMacroList
            // 
            this.tlMacroList.Location = new System.Drawing.Point(21, 316);
            this.tlMacroList.Margin = new System.Windows.Forms.Padding(4);
            this.tlMacroList.Name = "tlMacroList";
            this.tlMacroList.ShowTextBox = false;
            this.tlMacroList.Size = new System.Drawing.Size(679, 37);
            this.tlMacroList.TabIndex = 7;
            this.tlMacroList.Tags = ((System.Collections.Generic.List<string>)(resources.GetObject("tlMacroList.Tags")));
            this.tlMacroList.TagChanged += new FerretLib.WinForms.Controls.TagListControl.TagChangedDelegate(this.tlMacroList_TagAdded);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 292);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Selected Macro:";
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(570, 513);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 8;
            this.button1.Text = "&Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.AutoSize = true;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(661, 513);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 9;
            this.button2.Text = "&Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tt1
            // 
            this.tt1.ToolTipTitle = "Offset Example";
            // 
            // lblMacroExpression
            // 
            this.lblMacroExpression.AutoSize = true;
            this.lblMacroExpression.Location = new System.Drawing.Point(148, 395);
            this.lblMacroExpression.Name = "lblMacroExpression";
            this.lblMacroExpression.Size = new System.Drawing.Size(142, 17);
            this.lblMacroExpression.TabIndex = 15;
            this.lblMacroExpression.Text = "Test 25-May-2018.txt";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Macro Expression:";
            // 
            // MacroBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 554);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOutputFileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MacroBuilder";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Macro Insert/Check";
            this.Load += new System.EventHandler(this.MacroBuilder_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutputFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstDay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private FerretLib.WinForms.Controls.TagListControl tlMacroList;
        private System.Windows.Forms.Label lblMacroResult;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolTip tt1;
        private System.Windows.Forms.ListBox lstOffset;
        private System.Windows.Forms.CheckBox chkAppendType;
        private System.Windows.Forms.Label lblMacroExpression;
        private System.Windows.Forms.Label label7;
    }
}