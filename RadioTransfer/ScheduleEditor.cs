using SQLjobScheduler;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Thornton.Data;
using System.Linq;
using Thornton.Scheduler;

namespace QuartzCronGenerator
{
    public partial class MainForm : Form
    {
        #region Designer Code
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainPanel = new System.Windows.Forms.Panel();
            this.InputPanel = new System.Windows.Forms.Panel();
            this.grpDuration = new System.Windows.Forms.GroupBox();
            this.optDurationNoEnd = new System.Windows.Forms.RadioButton();
            this.dtDurationEnd = new System.Windows.Forms.DateTimePicker();
            this.optDurationEnd = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.dtDurationStart = new System.Windows.Forms.DateTimePicker();
            this.grpOneTimeOccur = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtOneTimeOccurTime = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtOneTimeOccurDate = new System.Windows.Forms.DateTimePicker();
            this.cmbScheduleType = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTaskType = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ButtonGenerate = new System.Windows.Forms.Button();
            this.CronExpressionTextBox = new System.Windows.Forms.TextBox();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InputTabControl = new System.Windows.Forms.TabControl();
            this.MinutesPage = new System.Windows.Forms.TabPage();
            this.MinutesLabel = new System.Windows.Forms.Label();
            this.MinutesUpDown = new System.Windows.Forms.NumericUpDown();
            this.EveryLabel1 = new System.Windows.Forms.Label();
            this.HoursPage = new System.Windows.Forms.TabPage();
            this.MinutesComboBox1 = new System.Windows.Forms.ComboBox();
            this.HoursComboBox1 = new System.Windows.Forms.ComboBox();
            this.AtTimeRadioButton = new System.Windows.Forms.RadioButton();
            this.HourlyRadioButton = new System.Windows.Forms.RadioButton();
            this.HoursLabel = new System.Windows.Forms.Label();
            this.HoursUpDown = new System.Windows.Forms.NumericUpDown();
            this.DaysPage = new System.Windows.Forms.TabPage();
            this.MinutesComboBox2 = new System.Windows.Forms.ComboBox();
            this.HoursComboBox2 = new System.Windows.Forms.ComboBox();
            this.StartTimeLabel = new System.Windows.Forms.Label();
            this.EveryWeekDayRadioButton = new System.Windows.Forms.RadioButton();
            this.DaysLabel = new System.Windows.Forms.Label();
            this.DaysUpDown = new System.Windows.Forms.NumericUpDown();
            this.DailyRadioButton = new System.Windows.Forms.RadioButton();
            this.WeeksPage = new System.Windows.Forms.TabPage();
            this.SundayCheckBox = new System.Windows.Forms.CheckBox();
            this.SaturdayCheckBox = new System.Windows.Forms.CheckBox();
            this.FridayCheckBox = new System.Windows.Forms.CheckBox();
            this.ThursdayCheckBox = new System.Windows.Forms.CheckBox();
            this.WednesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.MinutesComboBox3 = new System.Windows.Forms.ComboBox();
            this.HoursComboBox3 = new System.Windows.Forms.ComboBox();
            this.StartTimeLabel2 = new System.Windows.Forms.Label();
            this.TuesdayCheckBox = new System.Windows.Forms.CheckBox();
            this.MondayCheckBox = new System.Windows.Forms.CheckBox();
            this.MonthsPage = new System.Windows.Forms.TabPage();
            this.MonthUpDown = new System.Windows.Forms.NumericUpDown();
            this.MonthUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.DayUpDown = new System.Windows.Forms.NumericUpDown();
            this.MinutesComboBox4 = new System.Windows.Forms.ComboBox();
            this.HoursComboBox4 = new System.Windows.Forms.ComboBox();
            this.StartTimeLabel3 = new System.Windows.Forms.Label();
            this.MonthLabel2 = new System.Windows.Forms.Label();
            this.OfEveryLabel2 = new System.Windows.Forms.Label();
            this.DayOfWeekComboBox = new System.Windows.Forms.ComboBox();
            this.SeqNumberComboBox = new System.Windows.Forms.ComboBox();
            this.TheRadioButton = new System.Windows.Forms.RadioButton();
            this.MonthLabel = new System.Windows.Forms.Label();
            this.OfEveryLabel = new System.Windows.Forms.Label();
            this.DayRadioButton = new System.Windows.Forms.RadioButton();
            this.YearsPage = new System.Windows.Forms.TabPage();
            this.MinutesComboBox5 = new System.Windows.Forms.ComboBox();
            this.HoursComboBox5 = new System.Windows.Forms.ComboBox();
            this.StartTimeLabel4 = new System.Windows.Forms.Label();
            this.MonthComboBox2 = new System.Windows.Forms.ComboBox();
            this.OfLabel = new System.Windows.Forms.Label();
            this.DayOfWeekComboBox2 = new System.Windows.Forms.ComboBox();
            this.SeqNumberComboBox2 = new System.Windows.Forms.ComboBox();
            this.TheRadioButton2 = new System.Windows.Forms.RadioButton();
            this.DayOfMonthUpDown = new System.Windows.Forms.NumericUpDown();
            this.MonthComboBox = new System.Windows.Forms.ComboBox();
            this.EveryRadioButton = new System.Windows.Forms.RadioButton();
            this.MainPanel.SuspendLayout();
            this.InputPanel.SuspendLayout();
            this.grpDuration.SuspendLayout();
            this.grpOneTimeOccur.SuspendLayout();
            this.InputTabControl.SuspendLayout();
            this.MinutesPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinutesUpDown)).BeginInit();
            this.HoursPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HoursUpDown)).BeginInit();
            this.DaysPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DaysUpDown)).BeginInit();
            this.WeeksPage.SuspendLayout();
            this.MonthsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonthUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DayUpDown)).BeginInit();
            this.YearsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DayOfMonthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.InputPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(4);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(580, 529);
            this.MainPanel.TabIndex = 0;
            // 
            // InputPanel
            // 
            this.InputPanel.Controls.Add(this.grpDuration);
            this.InputPanel.Controls.Add(this.grpOneTimeOccur);
            this.InputPanel.Controls.Add(this.cmbScheduleType);
            this.InputPanel.Controls.Add(this.label3);
            this.InputPanel.Controls.Add(this.label2);
            this.InputPanel.Controls.Add(this.cmbTaskType);
            this.InputPanel.Controls.Add(this.btnCancel);
            this.InputPanel.Controls.Add(this.ButtonGenerate);
            this.InputPanel.Controls.Add(this.CronExpressionTextBox);
            this.InputPanel.Controls.Add(this.btnConfigure);
            this.InputPanel.Controls.Add(this.chkEnabled);
            this.InputPanel.Controls.Add(this.txtName);
            this.InputPanel.Controls.Add(this.label1);
            this.InputPanel.Controls.Add(this.InputTabControl);
            this.InputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputPanel.Location = new System.Drawing.Point(0, 0);
            this.InputPanel.Margin = new System.Windows.Forms.Padding(4);
            this.InputPanel.Name = "InputPanel";
            this.InputPanel.Size = new System.Drawing.Size(580, 529);
            this.InputPanel.TabIndex = 5;
            // 
            // grpDuration
            // 
            this.grpDuration.Controls.Add(this.optDurationNoEnd);
            this.grpDuration.Controls.Add(this.dtDurationEnd);
            this.grpDuration.Controls.Add(this.optDurationEnd);
            this.grpDuration.Controls.Add(this.label15);
            this.grpDuration.Controls.Add(this.dtDurationStart);
            this.grpDuration.Location = new System.Drawing.Point(8, 404);
            this.grpDuration.Margin = new System.Windows.Forms.Padding(4);
            this.grpDuration.Name = "grpDuration";
            this.grpDuration.Padding = new System.Windows.Forms.Padding(4);
            this.grpDuration.Size = new System.Drawing.Size(563, 80);
            this.grpDuration.TabIndex = 23;
            this.grpDuration.TabStop = false;
            this.grpDuration.Text = "Duration";
            // 
            // optDurationNoEnd
            // 
            this.optDurationNoEnd.AutoSize = true;
            this.optDurationNoEnd.Checked = true;
            this.optDurationNoEnd.Location = new System.Drawing.Point(307, 52);
            this.optDurationNoEnd.Margin = new System.Windows.Forms.Padding(4);
            this.optDurationNoEnd.Name = "optDurationNoEnd";
            this.optDurationNoEnd.Size = new System.Drawing.Size(107, 21);
            this.optDurationNoEnd.TabIndex = 4;
            this.optDurationNoEnd.TabStop = true;
            this.optDurationNoEnd.Text = "No end date";
            this.optDurationNoEnd.UseVisualStyleBackColor = true;
            // 
            // dtDurationEnd
            // 
            this.dtDurationEnd.CustomFormat = "dd/MM/yyyy";
            this.dtDurationEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDurationEnd.Location = new System.Drawing.Point(401, 26);
            this.dtDurationEnd.Margin = new System.Windows.Forms.Padding(4);
            this.dtDurationEnd.Name = "dtDurationEnd";
            this.dtDurationEnd.Size = new System.Drawing.Size(121, 22);
            this.dtDurationEnd.TabIndex = 3;
            // 
            // optDurationEnd
            // 
            this.optDurationEnd.AutoSize = true;
            this.optDurationEnd.Location = new System.Drawing.Point(307, 27);
            this.optDurationEnd.Margin = new System.Windows.Forms.Padding(4);
            this.optDurationEnd.Name = "optDurationEnd";
            this.optDurationEnd.Size = new System.Drawing.Size(90, 21);
            this.optDurationEnd.TabIndex = 2;
            this.optDurationEnd.Text = "End date:";
            this.optDurationEnd.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(68, 30);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(74, 17);
            this.label15.TabIndex = 1;
            this.label15.Text = "Start date:";
            // 
            // dtDurationStart
            // 
            this.dtDurationStart.CustomFormat = "dd/MM/yyyy";
            this.dtDurationStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDurationStart.Location = new System.Drawing.Point(153, 26);
            this.dtDurationStart.Margin = new System.Windows.Forms.Padding(4);
            this.dtDurationStart.Name = "dtDurationStart";
            this.dtDurationStart.Size = new System.Drawing.Size(121, 22);
            this.dtDurationStart.TabIndex = 0;
            // 
            // grpOneTimeOccur
            // 
            this.grpOneTimeOccur.Controls.Add(this.label4);
            this.grpOneTimeOccur.Controls.Add(this.dtOneTimeOccurTime);
            this.grpOneTimeOccur.Controls.Add(this.label5);
            this.grpOneTimeOccur.Controls.Add(this.dtOneTimeOccurDate);
            this.grpOneTimeOccur.Location = new System.Drawing.Point(8, 316);
            this.grpOneTimeOccur.Margin = new System.Windows.Forms.Padding(4);
            this.grpOneTimeOccur.Name = "grpOneTimeOccur";
            this.grpOneTimeOccur.Padding = new System.Windows.Forms.Padding(4);
            this.grpOneTimeOccur.Size = new System.Drawing.Size(563, 80);
            this.grpOneTimeOccur.TabIndex = 22;
            this.grpOneTimeOccur.TabStop = false;
            this.grpOneTimeOccur.Text = "One-time occurrence";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(305, 33);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Time:";
            // 
            // dtOneTimeOccurTime
            // 
            this.dtOneTimeOccurTime.CustomFormat = "HH:mm:ss";
            this.dtOneTimeOccurTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOneTimeOccurTime.Location = new System.Drawing.Point(365, 30);
            this.dtOneTimeOccurTime.Margin = new System.Windows.Forms.Padding(4);
            this.dtOneTimeOccurTime.Name = "dtOneTimeOccurTime";
            this.dtOneTimeOccurTime.ShowUpDown = true;
            this.dtOneTimeOccurTime.Size = new System.Drawing.Size(89, 22);
            this.dtOneTimeOccurTime.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(89, 30);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Date:";
            // 
            // dtOneTimeOccurDate
            // 
            this.dtOneTimeOccurDate.CustomFormat = "dd/MM/yyyy";
            this.dtOneTimeOccurDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOneTimeOccurDate.Location = new System.Drawing.Point(153, 26);
            this.dtOneTimeOccurDate.Margin = new System.Windows.Forms.Padding(4);
            this.dtOneTimeOccurDate.Name = "dtOneTimeOccurDate";
            this.dtOneTimeOccurDate.Size = new System.Drawing.Size(121, 22);
            this.dtOneTimeOccurDate.TabIndex = 0;
            // 
            // cmbScheduleType
            // 
            this.cmbScheduleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScheduleType.FormattingEnabled = true;
            this.cmbScheduleType.Items.AddRange(new object[] {
            "Recurring",
            "One time"});
            this.cmbScheduleType.Location = new System.Drawing.Point(133, 84);
            this.cmbScheduleType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbScheduleType.Name = "cmbScheduleType";
            this.cmbScheduleType.Size = new System.Drawing.Size(183, 24);
            this.cmbScheduleType.TabIndex = 21;
            this.cmbScheduleType.SelectedIndexChanged += new System.EventHandler(this.cmbScheduleType_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "Frequency:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 17);
            this.label2.TabIndex = 19;
            this.label2.Text = "Schedule Type:";
            // 
            // cmbTaskType
            // 
            this.cmbTaskType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTaskType.FormattingEnabled = true;
            this.cmbTaskType.Location = new System.Drawing.Point(133, 44);
            this.cmbTaskType.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTaskType.Name = "cmbTaskType";
            this.cmbTaskType.Size = new System.Drawing.Size(183, 24);
            this.cmbTaskType.TabIndex = 18;
            this.cmbTaskType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(471, 491);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 28);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ButtonGenerate
            // 
            this.ButtonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonGenerate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ButtonGenerate.Location = new System.Drawing.Point(352, 491);
            this.ButtonGenerate.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonGenerate.Name = "ButtonGenerate";
            this.ButtonGenerate.Size = new System.Drawing.Size(112, 28);
            this.ButtonGenerate.TabIndex = 0;
            this.ButtonGenerate.Text = "&Ok";
            this.ButtonGenerate.UseVisualStyleBackColor = true;
            this.ButtonGenerate.Click += new System.EventHandler(this.ButtonGenerate_Click);
            // 
            // CronExpressionTextBox
            // 
            this.CronExpressionTextBox.Location = new System.Drawing.Point(8, 494);
            this.CronExpressionTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.CronExpressionTextBox.Name = "CronExpressionTextBox";
            this.CronExpressionTextBox.ReadOnly = true;
            this.CronExpressionTextBox.Size = new System.Drawing.Size(333, 22);
            this.CronExpressionTextBox.TabIndex = 2;
            this.CronExpressionTextBox.Visible = false;
            // 
            // btnConfigure
            // 
            this.btnConfigure.Location = new System.Drawing.Point(327, 42);
            this.btnConfigure.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(115, 28);
            this.btnConfigure.TabIndex = 15;
            this.btnConfigure.Text = "Configure";
            this.btnConfigure.UseVisualStyleBackColor = true;
            this.btnConfigure.Click += new System.EventHandler(this.btnConfigure_Click);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(456, 12);
            this.chkEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(82, 21);
            this.chkEnabled.TabIndex = 14;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(133, 10);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(307, 22);
            this.txtName.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(75, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Name:";
            // 
            // InputTabControl
            // 
            this.InputTabControl.Controls.Add(this.MinutesPage);
            this.InputTabControl.Controls.Add(this.HoursPage);
            this.InputTabControl.Controls.Add(this.DaysPage);
            this.InputTabControl.Controls.Add(this.WeeksPage);
            this.InputTabControl.Controls.Add(this.MonthsPage);
            this.InputTabControl.Controls.Add(this.YearsPage);
            this.InputTabControl.Location = new System.Drawing.Point(8, 121);
            this.InputTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.InputTabControl.Name = "InputTabControl";
            this.InputTabControl.SelectedIndex = 0;
            this.InputTabControl.Size = new System.Drawing.Size(563, 188);
            this.InputTabControl.TabIndex = 6;
            // 
            // MinutesPage
            // 
            this.MinutesPage.Controls.Add(this.MinutesLabel);
            this.MinutesPage.Controls.Add(this.MinutesUpDown);
            this.MinutesPage.Controls.Add(this.EveryLabel1);
            this.MinutesPage.Location = new System.Drawing.Point(4, 25);
            this.MinutesPage.Margin = new System.Windows.Forms.Padding(4);
            this.MinutesPage.Name = "MinutesPage";
            this.MinutesPage.Padding = new System.Windows.Forms.Padding(4);
            this.MinutesPage.Size = new System.Drawing.Size(555, 159);
            this.MinutesPage.TabIndex = 0;
            this.MinutesPage.Text = "Minutes";
            this.MinutesPage.UseVisualStyleBackColor = true;
            // 
            // MinutesLabel
            // 
            this.MinutesLabel.AutoSize = true;
            this.MinutesLabel.Location = new System.Drawing.Point(147, 28);
            this.MinutesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MinutesLabel.Name = "MinutesLabel";
            this.MinutesLabel.Size = new System.Drawing.Size(57, 17);
            this.MinutesLabel.TabIndex = 2;
            this.MinutesLabel.Text = "minutes";
            // 
            // MinutesUpDown
            // 
            this.MinutesUpDown.Location = new System.Drawing.Point(76, 26);
            this.MinutesUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.MinutesUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.MinutesUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MinutesUpDown.Name = "MinutesUpDown";
            this.MinutesUpDown.Size = new System.Drawing.Size(63, 22);
            this.MinutesUpDown.TabIndex = 1;
            this.MinutesUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // EveryLabel1
            // 
            this.EveryLabel1.AutoSize = true;
            this.EveryLabel1.Location = new System.Drawing.Point(23, 28);
            this.EveryLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.EveryLabel1.Name = "EveryLabel1";
            this.EveryLabel1.Size = new System.Drawing.Size(44, 17);
            this.EveryLabel1.TabIndex = 0;
            this.EveryLabel1.Text = "Every";
            // 
            // HoursPage
            // 
            this.HoursPage.Controls.Add(this.MinutesComboBox1);
            this.HoursPage.Controls.Add(this.HoursComboBox1);
            this.HoursPage.Controls.Add(this.AtTimeRadioButton);
            this.HoursPage.Controls.Add(this.HourlyRadioButton);
            this.HoursPage.Controls.Add(this.HoursLabel);
            this.HoursPage.Controls.Add(this.HoursUpDown);
            this.HoursPage.Location = new System.Drawing.Point(4, 25);
            this.HoursPage.Margin = new System.Windows.Forms.Padding(4);
            this.HoursPage.Name = "HoursPage";
            this.HoursPage.Padding = new System.Windows.Forms.Padding(4);
            this.HoursPage.Size = new System.Drawing.Size(555, 159);
            this.HoursPage.TabIndex = 1;
            this.HoursPage.Text = "Hourly";
            this.HoursPage.UseVisualStyleBackColor = true;
            // 
            // MinutesComboBox1
            // 
            this.MinutesComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinutesComboBox1.FormattingEnabled = true;
            this.MinutesComboBox1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.MinutesComboBox1.Location = new System.Drawing.Point(159, 58);
            this.MinutesComboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.MinutesComboBox1.Name = "MinutesComboBox1";
            this.MinutesComboBox1.Size = new System.Drawing.Size(61, 24);
            this.MinutesComboBox1.TabIndex = 6;
            this.MinutesComboBox1.Enter += new System.EventHandler(this.MinutesComboBox1_Enter);
            // 
            // HoursComboBox1
            // 
            this.HoursComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HoursComboBox1.FormattingEnabled = true;
            this.HoursComboBox1.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.HoursComboBox1.Location = new System.Drawing.Point(88, 58);
            this.HoursComboBox1.Margin = new System.Windows.Forms.Padding(4);
            this.HoursComboBox1.Name = "HoursComboBox1";
            this.HoursComboBox1.Size = new System.Drawing.Size(61, 24);
            this.HoursComboBox1.TabIndex = 5;
            this.HoursComboBox1.Enter += new System.EventHandler(this.HoursComboBox1_Enter);
            // 
            // AtTimeRadioButton
            // 
            this.AtTimeRadioButton.AutoSize = true;
            this.AtTimeRadioButton.Location = new System.Drawing.Point(11, 59);
            this.AtTimeRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.AtTimeRadioButton.Name = "AtTimeRadioButton";
            this.AtTimeRadioButton.Size = new System.Drawing.Size(42, 21);
            this.AtTimeRadioButton.TabIndex = 4;
            this.AtTimeRadioButton.Text = "At";
            this.AtTimeRadioButton.UseVisualStyleBackColor = true;
            // 
            // HourlyRadioButton
            // 
            this.HourlyRadioButton.AutoSize = true;
            this.HourlyRadioButton.Checked = true;
            this.HourlyRadioButton.Location = new System.Drawing.Point(11, 26);
            this.HourlyRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.HourlyRadioButton.Name = "HourlyRadioButton";
            this.HourlyRadioButton.Size = new System.Drawing.Size(65, 21);
            this.HourlyRadioButton.TabIndex = 3;
            this.HourlyRadioButton.TabStop = true;
            this.HourlyRadioButton.Text = "Every";
            this.HourlyRadioButton.UseVisualStyleBackColor = true;
            // 
            // HoursLabel
            // 
            this.HoursLabel.AutoSize = true;
            this.HoursLabel.Location = new System.Drawing.Point(159, 28);
            this.HoursLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HoursLabel.Name = "HoursLabel";
            this.HoursLabel.Size = new System.Drawing.Size(44, 17);
            this.HoursLabel.TabIndex = 2;
            this.HoursLabel.Text = "hours";
            // 
            // HoursUpDown
            // 
            this.HoursUpDown.Location = new System.Drawing.Point(88, 26);
            this.HoursUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.HoursUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.HoursUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HoursUpDown.Name = "HoursUpDown";
            this.HoursUpDown.Size = new System.Drawing.Size(63, 22);
            this.HoursUpDown.TabIndex = 1;
            this.HoursUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.HoursUpDown.Enter += new System.EventHandler(this.HoursUpDown_Enter);
            // 
            // DaysPage
            // 
            this.DaysPage.Controls.Add(this.MinutesComboBox2);
            this.DaysPage.Controls.Add(this.HoursComboBox2);
            this.DaysPage.Controls.Add(this.StartTimeLabel);
            this.DaysPage.Controls.Add(this.EveryWeekDayRadioButton);
            this.DaysPage.Controls.Add(this.DaysLabel);
            this.DaysPage.Controls.Add(this.DaysUpDown);
            this.DaysPage.Controls.Add(this.DailyRadioButton);
            this.DaysPage.Location = new System.Drawing.Point(4, 25);
            this.DaysPage.Margin = new System.Windows.Forms.Padding(4);
            this.DaysPage.Name = "DaysPage";
            this.DaysPage.Padding = new System.Windows.Forms.Padding(4);
            this.DaysPage.Size = new System.Drawing.Size(555, 159);
            this.DaysPage.TabIndex = 2;
            this.DaysPage.Text = "Daily";
            this.DaysPage.UseVisualStyleBackColor = true;
            // 
            // MinutesComboBox2
            // 
            this.MinutesComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinutesComboBox2.FormattingEnabled = true;
            this.MinutesComboBox2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.MinutesComboBox2.Location = new System.Drawing.Point(159, 97);
            this.MinutesComboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.MinutesComboBox2.Name = "MinutesComboBox2";
            this.MinutesComboBox2.Size = new System.Drawing.Size(61, 24);
            this.MinutesComboBox2.TabIndex = 10;
            // 
            // HoursComboBox2
            // 
            this.HoursComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HoursComboBox2.FormattingEnabled = true;
            this.HoursComboBox2.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.HoursComboBox2.Location = new System.Drawing.Point(88, 97);
            this.HoursComboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.HoursComboBox2.Name = "HoursComboBox2";
            this.HoursComboBox2.Size = new System.Drawing.Size(61, 24);
            this.HoursComboBox2.TabIndex = 9;
            // 
            // StartTimeLabel
            // 
            this.StartTimeLabel.AutoSize = true;
            this.StartTimeLabel.Location = new System.Drawing.Point(12, 101);
            this.StartTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StartTimeLabel.Name = "StartTimeLabel";
            this.StartTimeLabel.Size = new System.Drawing.Size(68, 17);
            this.StartTimeLabel.TabIndex = 8;
            this.StartTimeLabel.Text = "Start time";
            // 
            // EveryWeekDayRadioButton
            // 
            this.EveryWeekDayRadioButton.AutoSize = true;
            this.EveryWeekDayRadioButton.Location = new System.Drawing.Point(11, 65);
            this.EveryWeekDayRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.EveryWeekDayRadioButton.Name = "EveryWeekDayRadioButton";
            this.EveryWeekDayRadioButton.Size = new System.Drawing.Size(128, 21);
            this.EveryWeekDayRadioButton.TabIndex = 7;
            this.EveryWeekDayRadioButton.Text = "Every week day";
            this.EveryWeekDayRadioButton.UseVisualStyleBackColor = true;
            // 
            // DaysLabel
            // 
            this.DaysLabel.AutoSize = true;
            this.DaysLabel.Location = new System.Drawing.Point(159, 28);
            this.DaysLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.DaysLabel.Name = "DaysLabel";
            this.DaysLabel.Size = new System.Drawing.Size(38, 17);
            this.DaysLabel.TabIndex = 6;
            this.DaysLabel.Text = "days";
            // 
            // DaysUpDown
            // 
            this.DaysUpDown.Location = new System.Drawing.Point(88, 26);
            this.DaysUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.DaysUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.DaysUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DaysUpDown.Name = "DaysUpDown";
            this.DaysUpDown.Size = new System.Drawing.Size(63, 22);
            this.DaysUpDown.TabIndex = 5;
            this.DaysUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DaysUpDown.Enter += new System.EventHandler(this.DaysUpDown_Enter);
            // 
            // DailyRadioButton
            // 
            this.DailyRadioButton.AutoSize = true;
            this.DailyRadioButton.Checked = true;
            this.DailyRadioButton.Location = new System.Drawing.Point(11, 26);
            this.DailyRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.DailyRadioButton.Name = "DailyRadioButton";
            this.DailyRadioButton.Size = new System.Drawing.Size(65, 21);
            this.DailyRadioButton.TabIndex = 4;
            this.DailyRadioButton.TabStop = true;
            this.DailyRadioButton.Text = "Every";
            this.DailyRadioButton.UseVisualStyleBackColor = true;
            // 
            // WeeksPage
            // 
            this.WeeksPage.Controls.Add(this.SundayCheckBox);
            this.WeeksPage.Controls.Add(this.SaturdayCheckBox);
            this.WeeksPage.Controls.Add(this.FridayCheckBox);
            this.WeeksPage.Controls.Add(this.ThursdayCheckBox);
            this.WeeksPage.Controls.Add(this.WednesdayCheckBox);
            this.WeeksPage.Controls.Add(this.MinutesComboBox3);
            this.WeeksPage.Controls.Add(this.HoursComboBox3);
            this.WeeksPage.Controls.Add(this.StartTimeLabel2);
            this.WeeksPage.Controls.Add(this.TuesdayCheckBox);
            this.WeeksPage.Controls.Add(this.MondayCheckBox);
            this.WeeksPage.Location = new System.Drawing.Point(4, 25);
            this.WeeksPage.Margin = new System.Windows.Forms.Padding(4);
            this.WeeksPage.Name = "WeeksPage";
            this.WeeksPage.Padding = new System.Windows.Forms.Padding(4);
            this.WeeksPage.Size = new System.Drawing.Size(555, 159);
            this.WeeksPage.TabIndex = 3;
            this.WeeksPage.Text = "Weekly";
            this.WeeksPage.UseVisualStyleBackColor = true;
            // 
            // SundayCheckBox
            // 
            this.SundayCheckBox.AutoSize = true;
            this.SundayCheckBox.Location = new System.Drawing.Point(217, 50);
            this.SundayCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.SundayCheckBox.Name = "SundayCheckBox";
            this.SundayCheckBox.Size = new System.Drawing.Size(78, 21);
            this.SundayCheckBox.TabIndex = 18;
            this.SundayCheckBox.Text = "Sunday";
            this.SundayCheckBox.UseVisualStyleBackColor = true;
            // 
            // SaturdayCheckBox
            // 
            this.SaturdayCheckBox.AutoSize = true;
            this.SaturdayCheckBox.Location = new System.Drawing.Point(120, 50);
            this.SaturdayCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.SaturdayCheckBox.Name = "SaturdayCheckBox";
            this.SaturdayCheckBox.Size = new System.Drawing.Size(87, 21);
            this.SaturdayCheckBox.TabIndex = 17;
            this.SaturdayCheckBox.Text = "Saturday";
            this.SaturdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // FridayCheckBox
            // 
            this.FridayCheckBox.AutoSize = true;
            this.FridayCheckBox.Location = new System.Drawing.Point(27, 50);
            this.FridayCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.FridayCheckBox.Name = "FridayCheckBox";
            this.FridayCheckBox.Size = new System.Drawing.Size(69, 21);
            this.FridayCheckBox.TabIndex = 16;
            this.FridayCheckBox.Text = "Friday";
            this.FridayCheckBox.UseVisualStyleBackColor = true;
            // 
            // ThursdayCheckBox
            // 
            this.ThursdayCheckBox.AutoSize = true;
            this.ThursdayCheckBox.Location = new System.Drawing.Point(336, 22);
            this.ThursdayCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.ThursdayCheckBox.Name = "ThursdayCheckBox";
            this.ThursdayCheckBox.Size = new System.Drawing.Size(90, 21);
            this.ThursdayCheckBox.TabIndex = 15;
            this.ThursdayCheckBox.Text = "Thursday";
            this.ThursdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // WednesdayCheckBox
            // 
            this.WednesdayCheckBox.AutoSize = true;
            this.WednesdayCheckBox.Location = new System.Drawing.Point(217, 22);
            this.WednesdayCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.WednesdayCheckBox.Name = "WednesdayCheckBox";
            this.WednesdayCheckBox.Size = new System.Drawing.Size(105, 21);
            this.WednesdayCheckBox.TabIndex = 14;
            this.WednesdayCheckBox.Text = "Wednesday";
            this.WednesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // MinutesComboBox3
            // 
            this.MinutesComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinutesComboBox3.FormattingEnabled = true;
            this.MinutesComboBox3.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.MinutesComboBox3.Location = new System.Drawing.Point(169, 116);
            this.MinutesComboBox3.Margin = new System.Windows.Forms.Padding(4);
            this.MinutesComboBox3.Name = "MinutesComboBox3";
            this.MinutesComboBox3.Size = new System.Drawing.Size(61, 24);
            this.MinutesComboBox3.TabIndex = 13;
            // 
            // HoursComboBox3
            // 
            this.HoursComboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HoursComboBox3.FormattingEnabled = true;
            this.HoursComboBox3.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.HoursComboBox3.Location = new System.Drawing.Point(99, 116);
            this.HoursComboBox3.Margin = new System.Windows.Forms.Padding(4);
            this.HoursComboBox3.Name = "HoursComboBox3";
            this.HoursComboBox3.Size = new System.Drawing.Size(61, 24);
            this.HoursComboBox3.TabIndex = 12;
            // 
            // StartTimeLabel2
            // 
            this.StartTimeLabel2.AutoSize = true;
            this.StartTimeLabel2.Location = new System.Drawing.Point(23, 119);
            this.StartTimeLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StartTimeLabel2.Name = "StartTimeLabel2";
            this.StartTimeLabel2.Size = new System.Drawing.Size(68, 17);
            this.StartTimeLabel2.TabIndex = 11;
            this.StartTimeLabel2.Text = "Start time";
            // 
            // TuesdayCheckBox
            // 
            this.TuesdayCheckBox.AutoSize = true;
            this.TuesdayCheckBox.Location = new System.Drawing.Point(120, 22);
            this.TuesdayCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.TuesdayCheckBox.Name = "TuesdayCheckBox";
            this.TuesdayCheckBox.Size = new System.Drawing.Size(85, 21);
            this.TuesdayCheckBox.TabIndex = 1;
            this.TuesdayCheckBox.Text = "Tuesday";
            this.TuesdayCheckBox.UseVisualStyleBackColor = true;
            // 
            // MondayCheckBox
            // 
            this.MondayCheckBox.AutoSize = true;
            this.MondayCheckBox.Checked = true;
            this.MondayCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MondayCheckBox.Location = new System.Drawing.Point(27, 22);
            this.MondayCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.MondayCheckBox.Name = "MondayCheckBox";
            this.MondayCheckBox.Size = new System.Drawing.Size(80, 21);
            this.MondayCheckBox.TabIndex = 0;
            this.MondayCheckBox.Text = "Monday";
            this.MondayCheckBox.UseVisualStyleBackColor = true;
            // 
            // MonthsPage
            // 
            this.MonthsPage.Controls.Add(this.MonthUpDown);
            this.MonthsPage.Controls.Add(this.MonthUpDown2);
            this.MonthsPage.Controls.Add(this.DayUpDown);
            this.MonthsPage.Controls.Add(this.MinutesComboBox4);
            this.MonthsPage.Controls.Add(this.HoursComboBox4);
            this.MonthsPage.Controls.Add(this.StartTimeLabel3);
            this.MonthsPage.Controls.Add(this.MonthLabel2);
            this.MonthsPage.Controls.Add(this.OfEveryLabel2);
            this.MonthsPage.Controls.Add(this.DayOfWeekComboBox);
            this.MonthsPage.Controls.Add(this.SeqNumberComboBox);
            this.MonthsPage.Controls.Add(this.TheRadioButton);
            this.MonthsPage.Controls.Add(this.MonthLabel);
            this.MonthsPage.Controls.Add(this.OfEveryLabel);
            this.MonthsPage.Controls.Add(this.DayRadioButton);
            this.MonthsPage.Location = new System.Drawing.Point(4, 25);
            this.MonthsPage.Margin = new System.Windows.Forms.Padding(4);
            this.MonthsPage.Name = "MonthsPage";
            this.MonthsPage.Padding = new System.Windows.Forms.Padding(4);
            this.MonthsPage.Size = new System.Drawing.Size(555, 159);
            this.MonthsPage.TabIndex = 4;
            this.MonthsPage.Text = "Montly";
            this.MonthsPage.UseVisualStyleBackColor = true;
            // 
            // MonthUpDown
            // 
            this.MonthUpDown.Location = new System.Drawing.Point(213, 20);
            this.MonthUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.MonthUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.MonthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MonthUpDown.Name = "MonthUpDown";
            this.MonthUpDown.Size = new System.Drawing.Size(52, 22);
            this.MonthUpDown.TabIndex = 18;
            this.MonthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MonthUpDown2
            // 
            this.MonthUpDown2.Location = new System.Drawing.Point(365, 60);
            this.MonthUpDown2.Margin = new System.Windows.Forms.Padding(4);
            this.MonthUpDown2.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.MonthUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MonthUpDown2.Name = "MonthUpDown2";
            this.MonthUpDown2.Size = new System.Drawing.Size(52, 22);
            this.MonthUpDown2.TabIndex = 17;
            this.MonthUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // DayUpDown
            // 
            this.DayUpDown.Location = new System.Drawing.Point(83, 20);
            this.DayUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.DayUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.DayUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DayUpDown.Name = "DayUpDown";
            this.DayUpDown.Size = new System.Drawing.Size(52, 22);
            this.DayUpDown.TabIndex = 16;
            this.DayUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MinutesComboBox4
            // 
            this.MinutesComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinutesComboBox4.FormattingEnabled = true;
            this.MinutesComboBox4.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.MinutesComboBox4.Location = new System.Drawing.Point(164, 106);
            this.MinutesComboBox4.Margin = new System.Windows.Forms.Padding(4);
            this.MinutesComboBox4.Name = "MinutesComboBox4";
            this.MinutesComboBox4.Size = new System.Drawing.Size(61, 24);
            this.MinutesComboBox4.TabIndex = 15;
            // 
            // HoursComboBox4
            // 
            this.HoursComboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HoursComboBox4.FormattingEnabled = true;
            this.HoursComboBox4.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.HoursComboBox4.Location = new System.Drawing.Point(93, 106);
            this.HoursComboBox4.Margin = new System.Windows.Forms.Padding(4);
            this.HoursComboBox4.Name = "HoursComboBox4";
            this.HoursComboBox4.Size = new System.Drawing.Size(61, 24);
            this.HoursComboBox4.TabIndex = 14;
            // 
            // StartTimeLabel3
            // 
            this.StartTimeLabel3.AutoSize = true;
            this.StartTimeLabel3.Location = new System.Drawing.Point(17, 110);
            this.StartTimeLabel3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StartTimeLabel3.Name = "StartTimeLabel3";
            this.StartTimeLabel3.Size = new System.Drawing.Size(68, 17);
            this.StartTimeLabel3.TabIndex = 11;
            this.StartTimeLabel3.Text = "Start time";
            // 
            // MonthLabel2
            // 
            this.MonthLabel2.AutoSize = true;
            this.MonthLabel2.Location = new System.Drawing.Point(428, 64);
            this.MonthLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MonthLabel2.Name = "MonthLabel2";
            this.MonthLabel2.Size = new System.Drawing.Size(64, 17);
            this.MonthLabel2.TabIndex = 10;
            this.MonthLabel2.Text = "month(s)";
            // 
            // OfEveryLabel2
            // 
            this.OfEveryLabel2.AutoSize = true;
            this.OfEveryLabel2.Location = new System.Drawing.Point(297, 65);
            this.OfEveryLabel2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OfEveryLabel2.Name = "OfEveryLabel2";
            this.OfEveryLabel2.Size = new System.Drawing.Size(59, 17);
            this.OfEveryLabel2.TabIndex = 8;
            this.OfEveryLabel2.Text = "of every";
            // 
            // DayOfWeekComboBox
            // 
            this.DayOfWeekComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DayOfWeekComboBox.FormattingEnabled = true;
            this.DayOfWeekComboBox.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.DayOfWeekComboBox.Location = new System.Drawing.Point(193, 60);
            this.DayOfWeekComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.DayOfWeekComboBox.Name = "DayOfWeekComboBox";
            this.DayOfWeekComboBox.Size = new System.Drawing.Size(95, 24);
            this.DayOfWeekComboBox.TabIndex = 7;
            // 
            // SeqNumberComboBox
            // 
            this.SeqNumberComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SeqNumberComboBox.FormattingEnabled = true;
            this.SeqNumberComboBox.Items.AddRange(new object[] {
            "First",
            "Second",
            "Third",
            "Fourth"});
            this.SeqNumberComboBox.Location = new System.Drawing.Point(88, 60);
            this.SeqNumberComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.SeqNumberComboBox.Name = "SeqNumberComboBox";
            this.SeqNumberComboBox.Size = new System.Drawing.Size(96, 24);
            this.SeqNumberComboBox.TabIndex = 6;
            // 
            // TheRadioButton
            // 
            this.TheRadioButton.AutoSize = true;
            this.TheRadioButton.Location = new System.Drawing.Point(16, 63);
            this.TheRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.TheRadioButton.Name = "TheRadioButton";
            this.TheRadioButton.Size = new System.Drawing.Size(54, 21);
            this.TheRadioButton.TabIndex = 5;
            this.TheRadioButton.Text = "The";
            this.TheRadioButton.UseVisualStyleBackColor = true;
            // 
            // MonthLabel
            // 
            this.MonthLabel.AutoSize = true;
            this.MonthLabel.Location = new System.Drawing.Point(273, 23);
            this.MonthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.MonthLabel.Name = "MonthLabel";
            this.MonthLabel.Size = new System.Drawing.Size(64, 17);
            this.MonthLabel.TabIndex = 4;
            this.MonthLabel.Text = "month(s)";
            // 
            // OfEveryLabel
            // 
            this.OfEveryLabel.AutoSize = true;
            this.OfEveryLabel.Location = new System.Drawing.Point(145, 22);
            this.OfEveryLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OfEveryLabel.Name = "OfEveryLabel";
            this.OfEveryLabel.Size = new System.Drawing.Size(59, 17);
            this.OfEveryLabel.TabIndex = 2;
            this.OfEveryLabel.Text = "of every";
            // 
            // DayRadioButton
            // 
            this.DayRadioButton.AutoSize = true;
            this.DayRadioButton.Checked = true;
            this.DayRadioButton.Location = new System.Drawing.Point(16, 21);
            this.DayRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.DayRadioButton.Name = "DayRadioButton";
            this.DayRadioButton.Size = new System.Drawing.Size(54, 21);
            this.DayRadioButton.TabIndex = 0;
            this.DayRadioButton.TabStop = true;
            this.DayRadioButton.Text = "Day";
            this.DayRadioButton.UseVisualStyleBackColor = true;
            // 
            // YearsPage
            // 
            this.YearsPage.Controls.Add(this.MinutesComboBox5);
            this.YearsPage.Controls.Add(this.HoursComboBox5);
            this.YearsPage.Controls.Add(this.StartTimeLabel4);
            this.YearsPage.Controls.Add(this.MonthComboBox2);
            this.YearsPage.Controls.Add(this.OfLabel);
            this.YearsPage.Controls.Add(this.DayOfWeekComboBox2);
            this.YearsPage.Controls.Add(this.SeqNumberComboBox2);
            this.YearsPage.Controls.Add(this.TheRadioButton2);
            this.YearsPage.Controls.Add(this.DayOfMonthUpDown);
            this.YearsPage.Controls.Add(this.MonthComboBox);
            this.YearsPage.Controls.Add(this.EveryRadioButton);
            this.YearsPage.Location = new System.Drawing.Point(4, 25);
            this.YearsPage.Margin = new System.Windows.Forms.Padding(4);
            this.YearsPage.Name = "YearsPage";
            this.YearsPage.Padding = new System.Windows.Forms.Padding(4);
            this.YearsPage.Size = new System.Drawing.Size(555, 159);
            this.YearsPage.TabIndex = 5;
            this.YearsPage.Text = "Yearly";
            this.YearsPage.UseVisualStyleBackColor = true;
            // 
            // MinutesComboBox5
            // 
            this.MinutesComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MinutesComboBox5.FormattingEnabled = true;
            this.MinutesComboBox5.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31",
            "32",
            "33",
            "34",
            "35",
            "36",
            "37",
            "38",
            "39",
            "40",
            "41",
            "42",
            "43",
            "44",
            "45",
            "46",
            "47",
            "48",
            "49",
            "50",
            "51",
            "52",
            "53",
            "54",
            "55",
            "56",
            "57",
            "58",
            "59"});
            this.MinutesComboBox5.Location = new System.Drawing.Point(159, 106);
            this.MinutesComboBox5.Margin = new System.Windows.Forms.Padding(4);
            this.MinutesComboBox5.Name = "MinutesComboBox5";
            this.MinutesComboBox5.Size = new System.Drawing.Size(61, 24);
            this.MinutesComboBox5.TabIndex = 27;
            // 
            // HoursComboBox5
            // 
            this.HoursComboBox5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.HoursComboBox5.FormattingEnabled = true;
            this.HoursComboBox5.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23"});
            this.HoursComboBox5.Location = new System.Drawing.Point(88, 106);
            this.HoursComboBox5.Margin = new System.Windows.Forms.Padding(4);
            this.HoursComboBox5.Name = "HoursComboBox5";
            this.HoursComboBox5.Size = new System.Drawing.Size(61, 24);
            this.HoursComboBox5.TabIndex = 26;
            // 
            // StartTimeLabel4
            // 
            this.StartTimeLabel4.AutoSize = true;
            this.StartTimeLabel4.Location = new System.Drawing.Point(12, 110);
            this.StartTimeLabel4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.StartTimeLabel4.Name = "StartTimeLabel4";
            this.StartTimeLabel4.Size = new System.Drawing.Size(68, 17);
            this.StartTimeLabel4.TabIndex = 25;
            this.StartTimeLabel4.Text = "Start time";
            // 
            // MonthComboBox2
            // 
            this.MonthComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonthComboBox2.FormattingEnabled = true;
            this.MonthComboBox2.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.MonthComboBox2.Location = new System.Drawing.Point(327, 58);
            this.MonthComboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.MonthComboBox2.Name = "MonthComboBox2";
            this.MonthComboBox2.Size = new System.Drawing.Size(160, 24);
            this.MonthComboBox2.TabIndex = 24;
            // 
            // OfLabel
            // 
            this.OfLabel.AutoSize = true;
            this.OfLabel.Location = new System.Drawing.Point(297, 63);
            this.OfLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.OfLabel.Name = "OfLabel";
            this.OfLabel.Size = new System.Drawing.Size(20, 17);
            this.OfLabel.TabIndex = 23;
            this.OfLabel.Text = "of";
            // 
            // DayOfWeekComboBox2
            // 
            this.DayOfWeekComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DayOfWeekComboBox2.FormattingEnabled = true;
            this.DayOfWeekComboBox2.Items.AddRange(new object[] {
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "Sunday"});
            this.DayOfWeekComboBox2.Location = new System.Drawing.Point(193, 58);
            this.DayOfWeekComboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.DayOfWeekComboBox2.Name = "DayOfWeekComboBox2";
            this.DayOfWeekComboBox2.Size = new System.Drawing.Size(95, 24);
            this.DayOfWeekComboBox2.TabIndex = 22;
            // 
            // SeqNumberComboBox2
            // 
            this.SeqNumberComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SeqNumberComboBox2.FormattingEnabled = true;
            this.SeqNumberComboBox2.Items.AddRange(new object[] {
            "First",
            "Second",
            "Third",
            "Fourth"});
            this.SeqNumberComboBox2.Location = new System.Drawing.Point(88, 58);
            this.SeqNumberComboBox2.Margin = new System.Windows.Forms.Padding(4);
            this.SeqNumberComboBox2.Name = "SeqNumberComboBox2";
            this.SeqNumberComboBox2.Size = new System.Drawing.Size(96, 24);
            this.SeqNumberComboBox2.TabIndex = 21;
            // 
            // TheRadioButton2
            // 
            this.TheRadioButton2.AutoSize = true;
            this.TheRadioButton2.Location = new System.Drawing.Point(11, 60);
            this.TheRadioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.TheRadioButton2.Name = "TheRadioButton2";
            this.TheRadioButton2.Size = new System.Drawing.Size(54, 21);
            this.TheRadioButton2.TabIndex = 20;
            this.TheRadioButton2.Text = "The";
            this.TheRadioButton2.UseVisualStyleBackColor = true;
            // 
            // DayOfMonthUpDown
            // 
            this.DayOfMonthUpDown.Location = new System.Drawing.Point(257, 18);
            this.DayOfMonthUpDown.Margin = new System.Windows.Forms.Padding(4);
            this.DayOfMonthUpDown.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.DayOfMonthUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.DayOfMonthUpDown.Name = "DayOfMonthUpDown";
            this.DayOfMonthUpDown.Size = new System.Drawing.Size(63, 22);
            this.DayOfMonthUpDown.TabIndex = 19;
            this.DayOfMonthUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // MonthComboBox
            // 
            this.MonthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MonthComboBox.FormattingEnabled = true;
            this.MonthComboBox.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.MonthComboBox.Location = new System.Drawing.Point(88, 17);
            this.MonthComboBox.Margin = new System.Windows.Forms.Padding(4);
            this.MonthComboBox.Name = "MonthComboBox";
            this.MonthComboBox.Size = new System.Drawing.Size(160, 24);
            this.MonthComboBox.TabIndex = 1;
            // 
            // EveryRadioButton
            // 
            this.EveryRadioButton.AutoSize = true;
            this.EveryRadioButton.Checked = true;
            this.EveryRadioButton.Location = new System.Drawing.Point(11, 18);
            this.EveryRadioButton.Margin = new System.Windows.Forms.Padding(4);
            this.EveryRadioButton.Name = "EveryRadioButton";
            this.EveryRadioButton.Size = new System.Drawing.Size(65, 21);
            this.EveryRadioButton.TabIndex = 0;
            this.EveryRadioButton.TabStop = true;
            this.EveryRadioButton.Text = "Every";
            this.EveryRadioButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 529);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule Editor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainPanel.ResumeLayout(false);
            this.InputPanel.ResumeLayout(false);
            this.InputPanel.PerformLayout();
            this.grpDuration.ResumeLayout(false);
            this.grpDuration.PerformLayout();
            this.grpOneTimeOccur.ResumeLayout(false);
            this.grpOneTimeOccur.PerformLayout();
            this.InputTabControl.ResumeLayout(false);
            this.MinutesPage.ResumeLayout(false);
            this.MinutesPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MinutesUpDown)).EndInit();
            this.HoursPage.ResumeLayout(false);
            this.HoursPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HoursUpDown)).EndInit();
            this.DaysPage.ResumeLayout(false);
            this.DaysPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DaysUpDown)).EndInit();
            this.WeeksPage.ResumeLayout(false);
            this.WeeksPage.PerformLayout();
            this.MonthsPage.ResumeLayout(false);
            this.MonthsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MonthUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MonthUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DayUpDown)).EndInit();
            this.YearsPage.ResumeLayout(false);
            this.YearsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DayOfMonthUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Button ButtonGenerate;
        private System.Windows.Forms.Panel InputPanel;
        private System.Windows.Forms.TextBox CronExpressionTextBox;
        private System.Windows.Forms.TabControl InputTabControl;
        private System.Windows.Forms.TabPage MinutesPage;
        private System.Windows.Forms.TabPage HoursPage;
        private System.Windows.Forms.Label EveryLabel1;
        private System.Windows.Forms.NumericUpDown MinutesUpDown;
        private System.Windows.Forms.Label MinutesLabel;
        private System.Windows.Forms.NumericUpDown HoursUpDown;
        private System.Windows.Forms.Label HoursLabel;
        private System.Windows.Forms.RadioButton HourlyRadioButton;
        private System.Windows.Forms.RadioButton AtTimeRadioButton;
        private System.Windows.Forms.ComboBox MinutesComboBox1;
        private System.Windows.Forms.ComboBox HoursComboBox1;
        private System.Windows.Forms.TabPage DaysPage;
        private System.Windows.Forms.RadioButton DailyRadioButton;
        private System.Windows.Forms.NumericUpDown DaysUpDown;
        private System.Windows.Forms.Label DaysLabel;
        private System.Windows.Forms.RadioButton EveryWeekDayRadioButton;
        private System.Windows.Forms.Label StartTimeLabel;
        private System.Windows.Forms.ComboBox MinutesComboBox2;
        private System.Windows.Forms.ComboBox HoursComboBox2;
        private System.Windows.Forms.TabPage WeeksPage;
        private System.Windows.Forms.CheckBox MondayCheckBox;
        private System.Windows.Forms.CheckBox TuesdayCheckBox;
        private System.Windows.Forms.ComboBox MinutesComboBox3;
        private System.Windows.Forms.ComboBox HoursComboBox3;
        private System.Windows.Forms.Label StartTimeLabel2;
        private System.Windows.Forms.CheckBox SundayCheckBox;
        private System.Windows.Forms.CheckBox SaturdayCheckBox;
        private System.Windows.Forms.CheckBox FridayCheckBox;
        private System.Windows.Forms.CheckBox ThursdayCheckBox;
        private System.Windows.Forms.CheckBox WednesdayCheckBox;
        private System.Windows.Forms.TabPage MonthsPage;
        private System.Windows.Forms.RadioButton DayRadioButton;
        private System.Windows.Forms.Label OfEveryLabel;
        private System.Windows.Forms.Label MonthLabel;
        private System.Windows.Forms.RadioButton TheRadioButton;
        private System.Windows.Forms.ComboBox DayOfWeekComboBox;
        private System.Windows.Forms.ComboBox SeqNumberComboBox;
        private System.Windows.Forms.Label OfEveryLabel2;
        private System.Windows.Forms.Label MonthLabel2;
        private System.Windows.Forms.Label StartTimeLabel3;
        private System.Windows.Forms.ComboBox MinutesComboBox4;
        private System.Windows.Forms.ComboBox HoursComboBox4;
        private System.Windows.Forms.NumericUpDown DayUpDown;
        private System.Windows.Forms.NumericUpDown MonthUpDown2;
        private System.Windows.Forms.NumericUpDown MonthUpDown;
        private System.Windows.Forms.TabPage YearsPage;
        private System.Windows.Forms.RadioButton EveryRadioButton;
        private System.Windows.Forms.ComboBox MonthComboBox;
        private System.Windows.Forms.NumericUpDown DayOfMonthUpDown;
        private System.Windows.Forms.ComboBox MonthComboBox2;
        private System.Windows.Forms.Label OfLabel;
        private System.Windows.Forms.ComboBox DayOfWeekComboBox2;
        private System.Windows.Forms.ComboBox SeqNumberComboBox2;
        private System.Windows.Forms.RadioButton TheRadioButton2;
        private System.Windows.Forms.ComboBox MinutesComboBox5;
        private System.Windows.Forms.ComboBox HoursComboBox5;
        private Button btnConfigure;
        private CheckBox chkEnabled;
        private TextBox txtName;
        private Label label1;
        private Button btnCancel;
        private Label label2;
        private ComboBox cmbTaskType;
        private System.Windows.Forms.Label StartTimeLabel4;
        #endregion

        public string Mode = "NEW";    // NEW or EDIT or VIEW
        private ComboBox cmbScheduleType;
        private Label label3;
        private GroupBox grpOneTimeOccur;
        private Label label4;
        private DateTimePicker dtOneTimeOccurTime;
        private Label label5;
        private DateTimePicker dtOneTimeOccurDate;
        private GroupBox grpDuration;
        private RadioButton optDurationNoEnd;
        private DateTimePicker dtDurationEnd;
        private RadioButton optDurationEnd;
        private Label label15;
        private DateTimePicker dtDurationStart;
        public SQLschedule Schedule = null;
        public List<TaskType> TaskTypes { get; set; }
        public MainForm(bool view = false)
        {
            if (view)
            {
                Mode = "VIEW";
            }
            else if (Schedule == null)
            {
                Mode = "NEW";
            }
            InitializeComponent();

            switch (Mode)
            {
                case "NEW":
                    this.Text = "Add Schedule";
                    break;
                case "VIEW":
                    this.Text = "View Schedule";
                    break;
                case "EDIT":
                    this.Text = "Edit Schedule";
                    break;
            }
        }

        public MainForm(SQLschedule objSchedule, List<TaskType> TaskTypes, bool view = false) : this(view)
        {
            Mode = "EDIT";
            this.Schedule = objSchedule;
            this.TaskTypes = TaskTypes;
        }

        private void ButtonGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                CronExpressionTextBox.Clear();

                Schedule.name = txtName.Text.Trim();
                if (chkEnabled.Checked)
                    Schedule.enabled = true;
                else
                    Schedule.enabled = false;

                if (InputTabControl.SelectedTab == InputTabControl.TabPages["MinutesPage"])
                {
                    CronExpressionTextBox.Text = CronExpression.EveryNMinutes((int)MinutesUpDown.Value);
                }
                else if (InputTabControl.SelectedTab == InputTabControl.TabPages["HoursPage"])
                {
                    if (HourlyRadioButton.Checked)
                    {
                        CronExpressionTextBox.Text = CronExpression.EveryNHours((int)HoursUpDown.Value);
                    }
                    else if (AtTimeRadioButton.Checked)
                    {
                        CronExpressionTextBox.Text = CronExpression.EveryDayAt(Convert.ToInt32(HoursComboBox1.SelectedItem),
                                                                               Convert.ToInt32(MinutesComboBox1.SelectedItem));
                    }
                }
                else if (InputTabControl.SelectedTab == InputTabControl.TabPages["DaysPage"])
                {
                    if (DailyRadioButton.Checked)
                    {
                        CronExpressionTextBox.Text = CronExpression.EveryNDaysAt((int)DaysUpDown.Value,
                                                                                 Convert.ToInt32(HoursComboBox2.SelectedItem),
                                                                                 Convert.ToInt32(MinutesComboBox2.SelectedItem));
                    }
                    else if (EveryWeekDayRadioButton.Checked)
                    {
                        CronExpressionTextBox.Text = CronExpression.EveryWeekDayAt(Convert.ToInt32(HoursComboBox2.SelectedItem),
                                                                                   Convert.ToInt32(MinutesComboBox2.SelectedItem));
                    }
                }
                else if (InputTabControl.SelectedTab == InputTabControl.TabPages["WeeksPage"])
                {
                    int total = 0;
                    if (MondayCheckBox.Checked) total += 1;
                    if (TuesdayCheckBox.Checked) total += 2;
                    if (WednesdayCheckBox.Checked) total += 4;
                    if (ThursdayCheckBox.Checked) total += 8;
                    if (FridayCheckBox.Checked) total += 16;
                    if (SaturdayCheckBox.Checked) total += 32;
                    if (SundayCheckBox.Checked) total += 64;

                    if (total == 0)
                    {
                        ShowError("At least one day of the week is required.");
                    }
                    else
                    {
                        CronExpressionTextBox.Text = CronExpression.EverySpecificWeekDayAt(Convert.ToInt32(HoursComboBox3.SelectedItem),
                                                                                           Convert.ToInt32(MinutesComboBox3.SelectedItem), (DaysOfWeek)total);
                    }
                }
                else if (InputTabControl.SelectedTab == InputTabControl.TabPages["MonthsPage"])
                {
                    if (DayRadioButton.Checked)
                    {
                        CronExpressionTextBox.Text =
                            CronExpression.EverySpecificDayEveryNMonthAt(Convert.ToInt32(DayUpDown.Value),
                                                                         Convert.ToInt32(MonthUpDown.Value),
                                                                         Convert.ToInt32(HoursComboBox4.SelectedItem),
                                                                         Convert.ToInt32(MinutesComboBox4.SelectedItem));
                    }
                    else if (TheRadioButton.Checked)
                    {
                        // Convert combo box index to enum (0 -> 1, 1 -> 2, 2 -> 4, etc)
                        var days = (DaysOfWeek)(Math.Pow(2, DayOfWeekComboBox.SelectedIndex));

                        // Convert combo box (first, second, third, fourth) to enum
                        var seqNumber = (DaySeqNumber)(SeqNumberComboBox.SelectedIndex + 1);

                        CronExpressionTextBox.Text =
                            CronExpression.EverySpecificSeqWeekDayEveryNMonthAt(seqNumber,
                                                                                days,
                                                                                Convert.ToInt32(MonthUpDown2.Value),
                                                                                Convert.ToInt32(HoursComboBox4.SelectedItem),
                                                                                Convert.ToInt32(MinutesComboBox4.SelectedItem));
                    }
                }
                else if (InputTabControl.SelectedTab == InputTabControl.TabPages["YearsPage"])
                {
                    if (EveryRadioButton.Checked)
                    {
                        var month = (Months)(MonthComboBox.SelectedIndex + 1);

                        CronExpressionTextBox.Text =
                            CronExpression.EverySpecificDayOfMonthAt(month,
                                                                     Convert.ToInt32(DayOfMonthUpDown.Value),
                                                                     Convert.ToInt32(HoursComboBox5.SelectedItem),
                                                                     Convert.ToInt32(MinutesComboBox5.SelectedItem));
                    }
                    else if (TheRadioButton2.Checked)
                    {
                        // Convert combo box index to enum (0 -> 1, 1 -> 2, 2 -> 4, etc)
                        var days = (DaysOfWeek)(Math.Pow(2, DayOfWeekComboBox2.SelectedIndex));

                        // Convert combo box (first, second, third, fourth) to enum
                        var seqNumber = (DaySeqNumber)(SeqNumberComboBox2.SelectedIndex + 1);

                        var month = (Months)(MonthComboBox2.SelectedIndex + 1);

                        CronExpressionTextBox.Text =
                            CronExpression.EverySpecificSeqWeekDayOfMonthAt(seqNumber,
                                                                            days,
                                                                            month,
                                                                            Convert.ToInt32(HoursComboBox5.SelectedItem),
                                                                            Convert.ToInt32(MinutesComboBox5.SelectedItem));
                    }
                }

                //set values for serialization
                Schedule.SelectedTabIndex = InputTabControl.SelectedIndex;

                Schedule.Tab1_Minutes = Convert.ToInt32(MinutesUpDown.Value);

                Schedule.Tab2_SelectedRadioIndex = HourlyRadioButton.Checked ? 0 : 1;
                Schedule.Tab2_Hours = Convert.ToInt32(HoursUpDown.Value);
                Schedule.Tab2_At_HH = HoursComboBox1.SelectedIndex;
                Schedule.Tab2_At_MM = MinutesComboBox1.SelectedIndex;

                Schedule.Tab3_SelectedRadioIndex = DailyRadioButton.Checked ? 0 : 1; ;
                Schedule.Tab3_Days = Convert.ToInt32(DaysUpDown.Value);
                Schedule.Tab3_EveryWeekDay_HH = HoursComboBox2.SelectedIndex;
                Schedule.Tab3_EveryWeekDay_MM = MinutesComboBox2.SelectedIndex;

                Schedule.Tab4_Monday = MondayCheckBox.Checked;
                Schedule.Tab4_Tuesday = TuesdayCheckBox.Checked;
                Schedule.Tab4_Wednesday = WednesdayCheckBox.Checked;
                Schedule.Tab4_Thursday = ThursdayCheckBox.Checked;
                Schedule.Tab4_Friday = FridayCheckBox.Checked;
                Schedule.Tab4_Saturday = SaturdayCheckBox.Checked;
                Schedule.Tab4_Sunday = SundayCheckBox.Checked;
                Schedule.Tab4_Day_HH = HoursComboBox3.SelectedIndex;
                Schedule.Tab4_Day_MM = MinutesComboBox3.SelectedIndex;

                Schedule.Tab5_SelectedRadioIndex = DayRadioButton.Checked ? 0 : 1;
                Schedule.Tab5_DayX = Convert.ToInt32(DayUpDown.Value);
                Schedule.Tab5_EveryXMonths = Convert.ToInt32(MonthUpDown.Value);
                Schedule.Tab5_Xth = SeqNumberComboBox.SelectedIndex;
                Schedule.Tab5_XthDay = DayOfWeekComboBox.SelectedIndex;
                Schedule.Tab5_EveryXMonths = Convert.ToInt32(MonthUpDown2.Value);
                Schedule.Tab5_Month_HH = HoursComboBox4.SelectedIndex;
                Schedule.Tab5_Month_MM = MinutesComboBox4.SelectedIndex;

                Schedule.Tab6_SelectedRadioIndex = EveryRadioButton.Checked ? 0 : 1;
                Schedule.Tab6_MonthName = MonthComboBox.SelectedIndex;
                Schedule.Tab6_MonthDate = Convert.ToInt32(DayOfMonthUpDown.Value);
                Schedule.Tab6_Xth = SeqNumberComboBox2.SelectedIndex;
                Schedule.Tab6_XthDay = DayOfWeekComboBox2.SelectedIndex;
                Schedule.Tab6_OfMonthName = MonthComboBox2.SelectedIndex;
                Schedule.Tab6_Year_HH = HoursComboBox5.SelectedIndex;
                Schedule.Tab6_Year_MM = MinutesComboBox5.SelectedIndex;

                Schedule.TaskTypeId = Convert.ToInt32(cmbTaskType.SelectedValue);

                Schedule.IsOnetime = cmbScheduleType.SelectedIndex == 1;

                Schedule.CronExpression = CronExpressionTextBox.Text;

                if (cmbScheduleType.SelectedIndex == 1)//one-time
                {
                    Schedule.active_start_date = new DateTime(dtOneTimeOccurDate.Value.Year, dtOneTimeOccurDate.Value.Month, dtOneTimeOccurDate.Value.Day);// dtOneTimeOccurDate.Value;
                    //timing
                    Schedule.active_start_date = Schedule.active_start_date.Add(new TimeSpan(dtOneTimeOccurTime.Value.Hour, dtOneTimeOccurTime.Value.Minute, dtOneTimeOccurTime.Value.Second));
                    Schedule.active_end_date = new DateTime(9998, 12, 31);
                }
                else//recurring
                {
                    Schedule.active_start_date = dtOneTimeOccurDate.Value;

                    if (optDurationNoEnd.Checked)
                    {
                        Schedule.active_end_date = new DateTime(9998, 12, 31);
                    }
                    else
                    {
                        if (dtDurationEnd.Value < dtDurationStart.Value)
                        {
                            MessageBox.Show("The dates of the 'Duration' period are not in the correct sequence.");
                            //this.DialogResult = DialogResult.Cancel;
                            return;
                        }
                        Schedule.active_end_date = dtDurationEnd.Value;
                    }
                }

                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void ShowError(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Schedule == null)
            {
                Schedule = new SQLschedule();
                Schedule.TaskTypeId = 1;
            }

            HoursComboBox1.SelectedIndex = 12;
            MinutesComboBox1.SelectedIndex = 0;

            HoursComboBox2.SelectedIndex = 12;
            MinutesComboBox2.SelectedIndex = 0;

            HoursComboBox3.SelectedIndex = 12;
            MinutesComboBox3.SelectedIndex = 0;

            SeqNumberComboBox.SelectedIndex = 0;
            DayOfWeekComboBox.SelectedIndex = 0;

            HoursComboBox4.SelectedIndex = 12;
            MinutesComboBox4.SelectedIndex = 0;

            MonthComboBox.SelectedIndex = 0;
            MonthComboBox2.SelectedIndex = 0;

            SeqNumberComboBox2.SelectedIndex = 0;
            DayOfWeekComboBox2.SelectedIndex = 0;

            HoursComboBox5.SelectedIndex = 12;
            MinutesComboBox5.SelectedIndex = 0;

            cmbScheduleType.SelectedIndex = 0;

            cmbTaskType.DataSource = TaskTypes;
            cmbTaskType.DisplayMember = "Name";
            cmbTaskType.ValueMember = "TaskTypeId";
            cmbTaskType.SelectedIndex = 0;

            //Load from schedule details object
            if (Mode == "VIEW" || Mode == "EDIT")
            {
                txtName.Text = Schedule.name;

                //set values for serialization
                InputTabControl.SelectedIndex = Schedule.SelectedTabIndex;

                MinutesUpDown.Value = Schedule.Tab1_Minutes;

                HourlyRadioButton.Checked = Schedule.Tab2_SelectedRadioIndex == 0;
                AtTimeRadioButton.Checked = Schedule.Tab2_SelectedRadioIndex == 1;
                HoursUpDown.Value = Schedule.Tab2_Hours;
                HoursComboBox1.SelectedIndex = Schedule.Tab2_At_HH;
                MinutesComboBox1.SelectedIndex = Schedule.Tab2_At_MM;

                DailyRadioButton.Checked = Schedule.Tab3_SelectedRadioIndex == 0;
                EveryWeekDayRadioButton.Checked = Schedule.Tab3_SelectedRadioIndex == 1;
                DaysUpDown.Value = Schedule.Tab3_Days;
                HoursComboBox2.SelectedIndex = Schedule.Tab3_EveryWeekDay_HH;
                MinutesComboBox2.SelectedIndex = Schedule.Tab3_EveryWeekDay_MM;

                MondayCheckBox.Checked = Schedule.Tab4_Monday;
                TuesdayCheckBox.Checked = Schedule.Tab4_Tuesday;
                WednesdayCheckBox.Checked = Schedule.Tab4_Wednesday;
                ThursdayCheckBox.Checked = Schedule.Tab4_Thursday;
                FridayCheckBox.Checked = Schedule.Tab4_Friday;
                SaturdayCheckBox.Checked = Schedule.Tab4_Saturday;
                SundayCheckBox.Checked = Schedule.Tab4_Sunday;
                HoursComboBox3.SelectedIndex = Schedule.Tab4_Day_HH;
                MinutesComboBox3.SelectedIndex = Schedule.Tab4_Day_MM;

                DayRadioButton.Checked = Schedule.Tab5_SelectedRadioIndex == 0;
                TheRadioButton.Checked = Schedule.Tab5_SelectedRadioIndex == 1;
                DayUpDown.Value = Schedule.Tab5_DayX;
                MonthUpDown.Value = Schedule.Tab5_EveryXMonths;
                SeqNumberComboBox.SelectedIndex = Schedule.Tab5_Xth;
                DayOfWeekComboBox.SelectedIndex = Schedule.Tab5_XthDay;
                MonthUpDown2.Value = Schedule.Tab5_EveryXMonths;
                HoursComboBox4.SelectedIndex = Schedule.Tab5_Month_HH;
                MinutesComboBox4.SelectedIndex = Schedule.Tab5_Month_MM;

                EveryRadioButton.Checked = Schedule.Tab6_SelectedRadioIndex == 0;
                TheRadioButton2.Checked = Schedule.Tab6_SelectedRadioIndex == 1;
                MonthComboBox.SelectedIndex = Schedule.Tab6_MonthName;
                DayOfMonthUpDown.Value = Schedule.Tab6_MonthDate;
                SeqNumberComboBox2.SelectedIndex = Schedule.Tab6_Xth;
                DayOfWeekComboBox2.SelectedIndex = Schedule.Tab6_XthDay;
                MonthComboBox2.SelectedIndex = Schedule.Tab6_OfMonthName;
                HoursComboBox5.SelectedIndex = Schedule.Tab6_Year_HH;
                MinutesComboBox5.SelectedIndex = Schedule.Tab6_Year_MM;

                if (Schedule.TaskTypeId != 0)
                    cmbTaskType.SelectedItem = TaskTypes.Where(x => x.TaskTypeId == Schedule.TaskTypeId).First();
                cmbScheduleType.SelectedIndex = Schedule.IsOnetime ? 1 : 0;

                CronExpressionTextBox.Text = Schedule.CronExpression;

                if (cmbScheduleType.SelectedIndex == 1)//one-time
                {
                    dtOneTimeOccurDate.Value = Schedule.active_start_date;//= new DateTime(dtOneTimeOccurDate.Value.Year, dtOneTimeOccurDate.Value.Month, dtOneTimeOccurDate.Value.Day);// dtOneTimeOccurDate.Value;
                    optDurationNoEnd.Checked = Schedule.active_end_date == new DateTime(9998, 12, 31);
                }
                else//recurring
                {
                    dtOneTimeOccurDate.Value = Schedule.active_start_date;

                    if (Schedule.active_end_date == new DateTime(9998, 12, 31))
                    {
                        optDurationNoEnd.Checked = true;
                    }
                    else
                    {
                        optDurationEnd.Checked = true;
                        dtDurationEnd.Value = Schedule.active_end_date.Value;
                    }
                }
            }
            else
            {
                InputTabControl.SelectedIndex = 3;
            }
        }

        private void HoursComboBox1_Enter(object sender, EventArgs e)
        {
            AtTimeRadioButton.Checked = true;
        }

        private void MinutesComboBox1_Enter(object sender, EventArgs e)
        {
            AtTimeRadioButton.Checked = true;
        }

        private void HoursUpDown_Enter(object sender, EventArgs e)
        {
            HourlyRadioButton.Checked = true;
        }

        private void DaysUpDown_Enter(object sender, EventArgs e)
        {
            DailyRadioButton.Checked = true;
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(CronExpressionTextBox.Text);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Schedule.TaskTypeId = Convert.ToInt32(cmbTaskType.SelectedValue);
            }
            catch 
            {
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cmbScheduleType.SelectedIndex;
            if (selected == 0)
            {
                grpOneTimeOccur.Enabled = false;
                InputTabControl.Enabled = true;
                grpDuration.Enabled = true;
            }
            else
            {
                grpOneTimeOccur.Enabled = true;
                InputTabControl.Enabled = false;
                grpDuration.Enabled = false;
            }
            //MessageBox.Show(selected.ToString());
        }

        private void btnConfigure_Click(object sender, EventArgs e)
        {
            ScheduleTypeEditor editor = new ScheduleTypeEditor();
            if (string.IsNullOrWhiteSpace(Schedule.OutputPath))
            {
                Schedule.OutputPath = AppDomain.CurrentDomain.BaseDirectory;
            }


            //HTTP
            editor.txtHttpLink.Text = Schedule.Path;
            editor.txtDownloadPath.Text = Schedule.OutputPath;
            //editor.chkRenameOldFileHTTP.Checked = Schedule.RenameOldFile;
            editor.txtHttpNewName.Text = Schedule.OutputFileName;

            //FTP
            editor.txtFTP_Host.Text = Schedule.FTP_Host;
            editor.txtFTP_Port.Text = Schedule.FTP_Port == 0 ? "21" : Schedule.FTP_Port.ToString();
            editor.txtFTP_Path.Text = Schedule.FTP_Path;
            editor.cmbFTP_Protocol.SelectedIndex = Schedule.FTP_Protocol;
            editor.cmbFTP_LogonType.SelectedIndex = Schedule.FTP_LogonType;
            //editor.txtOutputFileName.Text = Schedule.OutputFileName;
            editor.txtFtpNewName.Text = Schedule.OutputFileName;
            editor.chkFTP_IsPassive.Checked = Schedule.FTP_IsPassive;
            //editor.chkRenameOldFileFTP.Checked = Schedule.RenameOldFile;
            if (editor.cmbFTP_LogonType.SelectedIndex == 0)
            {
                editor.txtFTP_UserName.Enabled = false;
                editor.txtFTP_Password.Enabled = false;
            }
            else
            {
                editor.txtFTP_UserName.Enabled = true;
                editor.txtFTP_Password.Enabled = true;
            }
            editor.txtFTP_UserName.Text = Schedule.FTP_UserName;
            editor.txtFTP_Password.Text = Schedule.FTP_Password;
            editor.chkFTPSubdirectories.Checked = Schedule.FTP_SyncSubdirectories;

            //network
            editor.txtNetworkPath.Text = Schedule.Path;
            editor.txtNetworkNewName.Text = Schedule.OutputFileName;
            //editor.chkNetworkRenameOldFile.Checked = Schedule.RenameOldFile;

            //dropbox
            editor.txtDropboxPath.Text = Schedule.Path;
            editor.txtDropboxFileNewName.Text = Schedule.OutputFileName;

            //google
            editor.txtGoogleDrivePath.Text = Schedule.Path;
            editor.txtGDriveFileNewName.Text = Schedule.OutputFileName;

            //rss
            editor.txtRssPath.Text = Schedule.Path;
            //editor.chkRssRenameOldFile.Checked = Schedule.RenameOldFile;
            editor.txtRssNewFileName.Text = Schedule.OutputFileName;

            switch (cmbTaskType.SelectedIndex)
            {
                case 0:
                    editor.scheduleTabs.TabPages.Remove(editor.tbFTP);
                    //editor.scheduleTabs.TabPages.Remove(editor.tbHTTP);
                    editor.scheduleTabs.TabPages.Remove(editor.tbNetworkFolder);
                    editor.scheduleTabs.TabPages.Remove(editor.tbDropbox);
                    editor.scheduleTabs.TabPages.Remove(editor.tbGdrive);
                    editor.scheduleTabs.TabPages.Remove(editor.tbRss);
                    break;
                case 1:
                    //editor.scheduleTabs.TabPages.Remove(editor.tbFTP);
                    editor.scheduleTabs.TabPages.Remove(editor.tbHTTP);
                    editor.scheduleTabs.TabPages.Remove(editor.tbNetworkFolder);
                    editor.scheduleTabs.TabPages.Remove(editor.tbDropbox);
                    editor.scheduleTabs.TabPages.Remove(editor.tbGdrive);
                    editor.scheduleTabs.TabPages.Remove(editor.tbRss);
                    break;
                case 2:
                    editor.scheduleTabs.TabPages.Remove(editor.tbFTP);
                    editor.scheduleTabs.TabPages.Remove(editor.tbHTTP);
                    //editor.scheduleTabs.TabPages.Remove(editor.tbNetworkFolder);
                    editor.scheduleTabs.TabPages.Remove(editor.tbDropbox);
                    editor.scheduleTabs.TabPages.Remove(editor.tbGdrive);
                    editor.scheduleTabs.TabPages.Remove(editor.tbRss);
                    break;
                case 3:
                    editor.scheduleTabs.TabPages.Remove(editor.tbFTP);
                    editor.scheduleTabs.TabPages.Remove(editor.tbHTTP);
                    editor.scheduleTabs.TabPages.Remove(editor.tbNetworkFolder);
                    //editor.scheduleTabs.TabPages.Remove(editor.tbDropbox);
                    editor.scheduleTabs.TabPages.Remove(editor.tbGdrive);
                    editor.scheduleTabs.TabPages.Remove(editor.tbRss);
                    break;
                case 4:
                    editor.scheduleTabs.TabPages.Remove(editor.tbFTP);
                    editor.scheduleTabs.TabPages.Remove(editor.tbHTTP);
                    editor.scheduleTabs.TabPages.Remove(editor.tbNetworkFolder);
                    editor.scheduleTabs.TabPages.Remove(editor.tbDropbox);
                    //editor.scheduleTabs.TabPages.Remove(editor.tbGdrive);
                    editor.scheduleTabs.TabPages.Remove(editor.tbRss);
                    break;
                case 5:
                    editor.scheduleTabs.TabPages.Remove(editor.tbFTP);
                    editor.scheduleTabs.TabPages.Remove(editor.tbHTTP);
                    editor.scheduleTabs.TabPages.Remove(editor.tbNetworkFolder);
                    editor.scheduleTabs.TabPages.Remove(editor.tbDropbox);
                    editor.scheduleTabs.TabPages.Remove(editor.tbGdrive);
                    //editor.scheduleTabs.TabPages.Remove(editor.tbRss);
                    break;
            }
            editor.ShowDialog();
            switch (Schedule.TaskTypeId)
            {
                case Thornton.Data.TaskTypes.HTTP://HTTP
                    {
                        Schedule.OutputPath = editor.txtDownloadPath.Text;
                        Schedule.OutputFileName = editor.txtHttpNewName.Text;
                        Schedule.Path = editor.txtHttpLink.Text;
                        Schedule.RenameOldFile = !string.IsNullOrWhiteSpace(editor.txtHttpNewName.Text);
                    }
                    break;
                case Thornton.Data.TaskTypes.FTP://ftp
                    {
                        Schedule.OutputPath = editor.txtDownloadPath.Text;
                        Schedule.FTP_Host = editor.txtFTP_Host.Text;
                        Schedule.FTP_Port = Convert.ToInt32(editor.txtFTP_Port.Text);
                        Schedule.FTP_Path = editor.txtFTP_Path.Text;
                        Schedule.FTP_Protocol = editor.cmbFTP_Protocol.SelectedIndex;
                        Schedule.FTP_LogonType = editor.cmbFTP_LogonType.SelectedIndex;
                        Schedule.FTP_UserName = editor.txtFTP_UserName.Text;
                        Schedule.FTP_Password = editor.txtFTP_Password.Text;
                        Schedule.OutputFileName = editor.txtFtpNewName.Text;
                        Schedule.FTP_SyncSubdirectories = editor.chkFTPSubdirectories.Checked;
                        Schedule.FTP_IsPassive = editor.chkFTP_IsPassive.Checked;
                        //Schedule.RenameOldFile = editor.chkRenameOldFileFTP.Checked;
                    }
                    break;
                case Thornton.Data.TaskTypes.NetworkFolder:
                    {
                        Schedule.OutputPath = editor.txtDownloadPath.Text;
                        Schedule.Path = editor.txtNetworkPath.Text;
                        Schedule.OutputFileName = editor.txtNetworkNewName.Text;
                        Schedule.RenameOldFile = !string.IsNullOrWhiteSpace(editor.txtNetworkNewName.Text);
                    }
                    break;//network
                case Thornton.Data.TaskTypes.Dropbox:
                    {
                        Schedule.OutputPath = editor.txtDownloadPath.Text;
                        Schedule.Path = editor.txtDropboxPath.Text;
                        Schedule.OutputFileName = editor.txtDropboxFileNewName.Text;
                        Schedule.RenameOldFile = !string.IsNullOrWhiteSpace(editor.txtDropboxFileNewName.Text);
                    }
                    break;//dropbox
                case Thornton.Data.TaskTypes.GoogleDrive:
                    {
                        Schedule.OutputPath = editor.txtDownloadPath.Text;
                        Schedule.Path = editor.txtGoogleDrivePath.Text;
                        Schedule.OutputFileName = editor.txtGDriveFileNewName.Text;
                        Schedule.RenameOldFile = !string.IsNullOrWhiteSpace(editor.txtGDriveFileNewName.Text);
                    }
                    break;//google
                case Thornton.Data.TaskTypes.RSS:
                    {
                        Schedule.OutputPath = editor.txtDownloadPath.Text;
                        Schedule.OutputFileName = editor.txtRssNewFileName.Text;
                        Schedule.Path = editor.txtRssPath.Text;
                        Schedule.RenameOldFile = !string.IsNullOrWhiteSpace(editor.txtRssNewFileName.Text);
                    }
                    break;//rss
            }
        }
    }
}
