using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLjobScheduler;
using Quartz;

namespace SQLjobSchedulerGUI
{

    public partial class ModSchedule : Form
    {
        public string Mode = "NEW";    // NEW or EDIT or VIEW
        private Button btnConfigure;
        public SQLschedule Schedule = null;

        public ModSchedule(bool view = false)
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
        }

        public ModSchedule(SQLschedule objSchedule, bool view = false) : this(view)
        {
            Mode = "EDIT";
            this.Schedule = objSchedule;
        }

        private void ModSchedule_Load(object sender, EventArgs e)
        {
            // Combobox default selection and controls default values
            cmbScheduleType.SelectedIndex = 0;
            cmbFrequencyOccurs.SelectedIndex = 0;
            cmbFrequencyThe.SelectedIndex = 0;
            cmbFrequencyTheWeekday.SelectedIndex = 0;
            cmbDailyFreqEvery.SelectedIndex = 0;
            dtDailyFreqOnce.Value = new DateTime(DateTime.Now.Year, 1, 1, 0, 0, 0);
            optFrequencyDay.Checked = true;
            optDailyFreqOnce.Checked = true;
            optDurationNoEnd.Checked = true;

            if (Schedule != null)
            {
                this.Text = "Edit Schedule";
                txtName.Text = Schedule.name;
                chkEnabled.Checked = (Schedule.enabled == true);

                if (Schedule.freq_type == 1)
                {
                    cmbScheduleType.SelectedIndex = 1;    // One-time
                    dtOneTimeOccurDate.Value = Schedule.active_start_date;
                    dtOneTimeOccurTime.Value = Schedule.active_start_time;
                }
                else
                {
                    cmbScheduleType.SelectedIndex = 0;
                    if (Schedule.freq_type == 4)
                    {
                        cmbFrequencyOccurs.SelectedIndex = 0; // Daily
                        numFrequencyRecurs.Value = Schedule.freq_interval;
                    }
                    if (Schedule.freq_type == 8)
                    {
                        cmbFrequencyOccurs.SelectedIndex = 1; // Weekly
                        chkFrequencyRecursSun.Checked = ((Schedule.freq_interval & 1) > 0);
                        chkFrequencyRecursMon.Checked = ((Schedule.freq_interval & 2) > 0);
                        chkFrequencyRecursTue.Checked = ((Schedule.freq_interval & 4) > 0);
                        chkFrequencyRecursWed.Checked = ((Schedule.freq_interval & 8) > 0);
                        chkFrequencyRecursThu.Checked = ((Schedule.freq_interval & 16) > 0);
                        chkFrequencyRecursFri.Checked = ((Schedule.freq_interval & 32) > 0);
                        chkFrequencyRecursSat.Checked = ((Schedule.freq_interval & 64) > 0);
                        numFrequencyRecurs.Value = Schedule.freq_recurrence_factor;
                    }
                    if (Schedule.freq_type == 16)
                    {
                        optFrequencyDay.Checked = true;
                        cmbFrequencyOccurs.SelectedIndex = 2; // Monthly "Day"
                        numFrequencyDay.Value = Schedule.freq_interval;
                        numFrequencyDayEvery.Value = Schedule.freq_recurrence_factor;
                    }
                    if (Schedule.freq_type == 32)
                    {
                        optFrequencyThe.Checked = true;
                        cmbFrequencyOccurs.SelectedIndex = 2; // Monthly "The..."

                        switch (Schedule.freq_relative_interval)
                        {
                            case 1:
                                cmbFrequencyThe.SelectedIndex = 0;
                                break;
                            case 2:
                                cmbFrequencyThe.SelectedIndex = 1;
                                break;
                            case 4:
                                cmbFrequencyThe.SelectedIndex = 2;
                                break;
                            case 8:
                                cmbFrequencyThe.SelectedIndex = 3;
                                break;
                            case 16:
                                cmbFrequencyThe.SelectedIndex = 4;
                                break;
                        }
                        cmbFrequencyTheWeekday.SelectedIndex = Schedule.freq_interval - 1;
                        numFrequencyTheEvery.Value = Schedule.freq_recurrence_factor;
                    }
                }

                if (Schedule.freq_subday_type == 1)
                {
                    optDailyFreqOnce.Checked = true;
                    dtDailyFreqOnce.Value = Schedule.active_start_time;
                }
                else
                {
                    optDailyFreqEvery.Checked = true;
                    if (Schedule.freq_subday_type == 8)
                        cmbDailyFreqEvery.SelectedIndex = 0;
                    if (Schedule.freq_subday_type == 4)
                        cmbDailyFreqEvery.SelectedIndex = 1;
                    if (Schedule.freq_subday_type == 2)
                        cmbDailyFreqEvery.SelectedIndex = 2;

                    if (Schedule.freq_subday_interval > 0)
                        numDailyFreqEvery.Value = Schedule.freq_subday_interval;
                    else
                        numDailyFreqEvery.Value = 1;
                }

                dtDurationStart.Value = Schedule.active_start_date;
                if (Schedule.active_end_date > dtDurationEnd.MaxDate)
                {
                    optDurationNoEnd.Checked = true;
                    dtDurationEnd.Value = dtDurationEnd.MaxDate;
                }
                else
                {
                    optDurationEnd.Checked = true;
                    dtDurationEnd.Value = Schedule.active_end_date.Value;
                }
                dtDailyFreqStart.Value = Schedule.active_start_time;
                dtDailyFreqEnd.Value = Schedule.active_end_time.Value;
            }

            if (Mode == "VIEW")
            {
                this.Text = "View Schedule details";
                btnOk.Enabled = false;
            }
        }

        private void cmbScheduleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbScheduleType.SelectedIndex == 0)
            {
                grpOneTimeOccur.Enabled = false;
                grpFrequency.Enabled = true;
                grpDailyFreq.Enabled = true;
                grpDuration.Enabled = true;
            }
            else
            {
                grpOneTimeOccur.Enabled = true;
                grpFrequency.Enabled = false;
                grpDailyFreq.Enabled = false;
                grpDuration.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (Schedule == null)
                Schedule = new SQLschedule();

            Schedule.name = txtName.Text.Trim();
            if (chkEnabled.Checked)
                Schedule.enabled = true;
            else
                Schedule.enabled = false;

            if (cmbScheduleType.SelectedIndex == 1)
            {
                Schedule.freq_type = 1;     // One-time
                Schedule.active_start_date = dtOneTimeOccurDate.Value;
                Schedule.active_end_date = new DateTime(9998, 12, 31);
                Schedule.active_start_time = dtOneTimeOccurTime.Value;
                Schedule.active_end_time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);
            }
            else
            {
                if (cmbFrequencyOccurs.SelectedIndex == 0)
                {
                    Schedule.freq_type = 4;   // Daily
                    Schedule.freq_interval = (int)numFrequencyRecurs.Value;
                }

                if (cmbFrequencyOccurs.SelectedIndex == 1)
                {
                    Schedule.freq_type = 8;   // Weekly
                    int freq_interval = 0;
                    if (chkFrequencyRecursSun.Checked)
                        freq_interval += 1;
                    if (chkFrequencyRecursMon.Checked)
                        freq_interval += 2;
                    if (chkFrequencyRecursTue.Checked)
                        freq_interval += 4;
                    if (chkFrequencyRecursWed.Checked)
                        freq_interval += 8;
                    if (chkFrequencyRecursThu.Checked)
                        freq_interval += 16;
                    if (chkFrequencyRecursFri.Checked)
                        freq_interval += 32;
                    if (chkFrequencyRecursSat.Checked)
                        freq_interval += 64;

                    if (freq_interval == 0)
                    {
                        MessageBox.Show("A weekly frequency requires you to select at least one weekday.");
                        return;
                    }

                    Schedule.freq_interval = freq_interval;
                    Schedule.freq_recurrence_factor = (int)numFrequencyRecurs.Value;
                }

                if (cmbFrequencyOccurs.SelectedIndex == 2 && optFrequencyDay.Checked)
                {
                    Schedule.freq_type = 16;   // Monthly "Day"
                    Schedule.freq_interval = (int)numFrequencyDay.Value;
                    Schedule.freq_recurrence_factor = (int)numFrequencyDayEvery.Value;
                }

                if (cmbFrequencyOccurs.SelectedIndex == 2 && optFrequencyThe.Checked)
                {
                    Schedule.freq_type = 32;   // Monthly "The..."

                    switch (cmbFrequencyThe.SelectedIndex)
                    {
                        case 0:
                            Schedule.freq_relative_interval = 1;
                            break;
                        case 1:
                            Schedule.freq_relative_interval = 2;
                            break;
                        case 2:
                            Schedule.freq_relative_interval = 4;
                            break;
                        case 3:
                            Schedule.freq_relative_interval = 8;
                            break;
                        case 4:
                            Schedule.freq_relative_interval = 16;
                            break;
                    }
                    Schedule.freq_interval = cmbFrequencyTheWeekday.SelectedIndex + 1;
                    Schedule.freq_recurrence_factor = (int)numFrequencyTheEvery.Value;
                }

                if (optDailyFreqOnce.Checked)
                {
                    Schedule.freq_subday_type = 1;
                    Schedule.active_start_time = dtDailyFreqOnce.Value;
                }
                else
                {
                    if (cmbDailyFreqEvery.SelectedIndex == 0)
                        Schedule.freq_subday_type = 8;
                    if (cmbDailyFreqEvery.SelectedIndex == 1)
                        Schedule.freq_subday_type = 4;
                    if (cmbDailyFreqEvery.SelectedIndex == 2)
                        Schedule.freq_subday_type = 2;

                    Schedule.freq_subday_interval = (int)numDailyFreqEvery.Value;
                    Schedule.active_start_time = dtDailyFreqStart.Value;
                    Schedule.active_end_time = dtDailyFreqEnd.Value;
                }

                Schedule.active_start_date = dtDurationStart.Value;
                if (optDurationNoEnd.Checked)
                {
                    Schedule.active_end_date = new DateTime(9998, 12, 31);
                    Schedule.active_end_time = new DateTime(9998, 12, 31, 0, 0, 0);
                }
                else
                {
                    if (dtDurationEnd.Value < dtDurationStart.Value)
                    {
                        MessageBox.Show("The dates of the 'Duration' period are not in the correct sequence.");
                        return;
                    }
                    Schedule.active_end_date = dtDurationEnd.Value;
                }
            }


            this.DialogResult = DialogResult.OK;
        }

        private void cmbFrequencyOccurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbFrequencyOccurs.SelectedIndex)
            {
                case 0:
                    lblFrequencyRecurs.Visible = true;
                    numFrequencyRecurs.Visible = true;
                    lblFrequencyRecursWhat.Visible = true;
                    lblFrequencyRecursWhat.Text = "day(s)";

                    chkFrequencyRecursMon.Visible = false;
                    chkFrequencyRecursTue.Visible = false;
                    chkFrequencyRecursWed.Visible = false;
                    chkFrequencyRecursThu.Visible = false;
                    chkFrequencyRecursFri.Visible = false;
                    chkFrequencyRecursSat.Visible = false;
                    chkFrequencyRecursSun.Visible = false;

                    optFrequencyDay.Visible = false;
                    numFrequencyDay.Visible = false;
                    lblFrequencyDay1.Visible = false;
                    numFrequencyDayEvery.Visible = false;
                    lblFrequencyDay2.Visible = false;
                    optFrequencyThe.Visible = false;
                    cmbFrequencyThe.Visible = false;
                    cmbFrequencyTheWeekday.Visible = false;
                    lblFrequencyThe1.Visible = false;
                    numFrequencyTheEvery.Visible = false;
                    lblFrequencyThe2.Visible = false;
                    break;
                case 1:
                    lblFrequencyRecurs.Visible = true;
                    numFrequencyRecurs.Visible = true;
                    lblFrequencyRecursWhat.Visible = true;
                    lblFrequencyRecursWhat.Text = "week(s) on these days:";

                    chkFrequencyRecursMon.Visible = true;
                    chkFrequencyRecursTue.Visible = true;
                    chkFrequencyRecursWed.Visible = true;
                    chkFrequencyRecursThu.Visible = true;
                    chkFrequencyRecursFri.Visible = true;
                    chkFrequencyRecursSat.Visible = true;
                    chkFrequencyRecursSun.Visible = true;

                    optFrequencyDay.Visible = false;
                    numFrequencyDay.Visible = false;
                    lblFrequencyDay1.Visible = false;
                    numFrequencyDayEvery.Visible = false;
                    lblFrequencyDay2.Visible = false;
                    optFrequencyThe.Visible = false;
                    cmbFrequencyThe.Visible = false;
                    cmbFrequencyTheWeekday.Visible = false;
                    lblFrequencyThe1.Visible = false;
                    numFrequencyTheEvery.Visible = false;
                    lblFrequencyThe2.Visible = false;
                    break;
                case 2:
                    lblFrequencyRecurs.Visible = false;
                    numFrequencyRecurs.Visible = false;
                    lblFrequencyRecursWhat.Visible = false;
                    lblFrequencyRecursWhat.Text = "";

                    chkFrequencyRecursMon.Visible = false;
                    chkFrequencyRecursTue.Visible = false;
                    chkFrequencyRecursWed.Visible = false;
                    chkFrequencyRecursThu.Visible = false;
                    chkFrequencyRecursFri.Visible = false;
                    chkFrequencyRecursSat.Visible = false;
                    chkFrequencyRecursSun.Visible = false;

                    optFrequencyDay.Visible = true;
                    numFrequencyDay.Visible = true;
                    lblFrequencyDay1.Visible = true;
                    numFrequencyDayEvery.Visible = true;
                    lblFrequencyDay2.Visible = true;
                    optFrequencyThe.Visible = true;
                    cmbFrequencyThe.Visible = true;
                    cmbFrequencyTheWeekday.Visible = true;
                    lblFrequencyThe1.Visible = true;
                    numFrequencyTheEvery.Visible = true;
                    lblFrequencyThe2.Visible = true;
                    break;

            }
        }

        private void cmbDailyFreqEvery_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbDailyFreqEvery.SelectedIndex)
            {
                case 0:
                    numDailyFreqEvery.Minimum = 1;    // hours
                    numDailyFreqEvery.Maximum = 24;
                    break;
                case 1:
                    numDailyFreqEvery.Minimum = 1;    // minutes
                    numDailyFreqEvery.Maximum = 60;
                    break;
                case 2:
                    numDailyFreqEvery.Minimum = 11;   // seconds
                    numDailyFreqEvery.Maximum = 60;
                    break;
            }
        }

        private void optFrequencyDay_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableControlsDependingFromOptionButtons();
        }

        private void optDailyFreqOnce_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableControlsDependingFromOptionButtons();
        }

        private void optDurationEnd_CheckedChanged(object sender, EventArgs e)
        {
            EnableDisableControlsDependingFromOptionButtons();
        }

        private void EnableDisableControlsDependingFromOptionButtons()
        {
            if (optFrequencyDay.Checked)
            {
                numFrequencyDay.Enabled = true;
                numFrequencyDayEvery.Enabled = true;
                cmbFrequencyThe.Enabled = false;
                cmbFrequencyTheWeekday.Enabled = false;
                numFrequencyTheEvery.Enabled = false;
            }
            else
            {
                numFrequencyDay.Enabled = false;
                numFrequencyDayEvery.Enabled = false;
                cmbFrequencyThe.Enabled = true;
                cmbFrequencyTheWeekday.Enabled = true;
                numFrequencyTheEvery.Enabled = true;
            }

            if (optDailyFreqOnce.Checked)
            {
                dtDailyFreqOnce.Enabled = true;
                numDailyFreqEvery.Enabled = false;
                cmbDailyFreqEvery.Enabled = false;
                dtDailyFreqStart.Enabled = false;
                dtDailyFreqEnd.Enabled = false;
            }
            else
            {
                dtDailyFreqOnce.Enabled = false;
                numDailyFreqEvery.Enabled = true;
                cmbDailyFreqEvery.Enabled = true;
                dtDailyFreqStart.Enabled = true;
                dtDailyFreqEnd.Enabled = true;
            }

            if (optDurationEnd.Checked)
            {
                dtDurationEnd.Enabled = true;
            }
            else
            {
                dtDurationEnd.Enabled = false;
            }

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModSchedule));
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbScheduleType = new System.Windows.Forms.ComboBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.grpOneTimeOccur = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtOneTimeOccurTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtOneTimeOccurDate = new System.Windows.Forms.DateTimePicker();
            this.grpFrequency = new System.Windows.Forms.GroupBox();
            this.lblFrequencyThe2 = new System.Windows.Forms.Label();
            this.numFrequencyTheEvery = new System.Windows.Forms.NumericUpDown();
            this.lblFrequencyThe1 = new System.Windows.Forms.Label();
            this.cmbFrequencyTheWeekday = new System.Windows.Forms.ComboBox();
            this.cmbFrequencyThe = new System.Windows.Forms.ComboBox();
            this.lblFrequencyDay2 = new System.Windows.Forms.Label();
            this.numFrequencyDayEvery = new System.Windows.Forms.NumericUpDown();
            this.lblFrequencyDay1 = new System.Windows.Forms.Label();
            this.numFrequencyDay = new System.Windows.Forms.NumericUpDown();
            this.optFrequencyThe = new System.Windows.Forms.RadioButton();
            this.optFrequencyDay = new System.Windows.Forms.RadioButton();
            this.chkFrequencyRecursSun = new System.Windows.Forms.CheckBox();
            this.chkFrequencyRecursSat = new System.Windows.Forms.CheckBox();
            this.chkFrequencyRecursFri = new System.Windows.Forms.CheckBox();
            this.chkFrequencyRecursThu = new System.Windows.Forms.CheckBox();
            this.chkFrequencyRecursWed = new System.Windows.Forms.CheckBox();
            this.chkFrequencyRecursTue = new System.Windows.Forms.CheckBox();
            this.chkFrequencyRecursMon = new System.Windows.Forms.CheckBox();
            this.lblFrequencyRecursWhat = new System.Windows.Forms.Label();
            this.lblFrequencyRecurs = new System.Windows.Forms.Label();
            this.numFrequencyRecurs = new System.Windows.Forms.NumericUpDown();
            this.cmbFrequencyOccurs = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpDailyFreq = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.dtDailyFreqEnd = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.dtDailyFreqStart = new System.Windows.Forms.DateTimePicker();
            this.dtDailyFreqOnce = new System.Windows.Forms.DateTimePicker();
            this.cmbDailyFreqEvery = new System.Windows.Forms.ComboBox();
            this.numDailyFreqEvery = new System.Windows.Forms.NumericUpDown();
            this.optDailyFreqEvery = new System.Windows.Forms.RadioButton();
            this.optDailyFreqOnce = new System.Windows.Forms.RadioButton();
            this.grpDuration = new System.Windows.Forms.GroupBox();
            this.optDurationNoEnd = new System.Windows.Forms.RadioButton();
            this.dtDurationEnd = new System.Windows.Forms.DateTimePicker();
            this.optDurationEnd = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.dtDurationStart = new System.Windows.Forms.DateTimePicker();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfigure = new System.Windows.Forms.Button();
            this.grpOneTimeOccur.SuspendLayout();
            this.grpFrequency.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequencyTheEvery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequencyDayEvery)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequencyDay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequencyRecurs)).BeginInit();
            this.grpDailyFreq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDailyFreqEvery)).BeginInit();
            this.grpDuration.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(130, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(259, 20);
            this.txtName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Schedule type:";
            // 
            // cmbScheduleType
            // 
            this.cmbScheduleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbScheduleType.FormattingEnabled = true;
            this.cmbScheduleType.Items.AddRange(new object[] {
            "Recurring",
            "One time"});
            this.cmbScheduleType.Location = new System.Drawing.Point(130, 38);
            this.cmbScheduleType.Name = "cmbScheduleType";
            this.cmbScheduleType.Size = new System.Drawing.Size(177, 21);
            this.cmbScheduleType.TabIndex = 3;
            this.cmbScheduleType.SelectedIndexChanged += new System.EventHandler(this.cmbScheduleType_SelectedIndexChanged);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(421, 42);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(65, 17);
            this.chkEnabled.TabIndex = 4;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // grpOneTimeOccur
            // 
            this.grpOneTimeOccur.Controls.Add(this.label4);
            this.grpOneTimeOccur.Controls.Add(this.dtOneTimeOccurTime);
            this.grpOneTimeOccur.Controls.Add(this.label3);
            this.grpOneTimeOccur.Controls.Add(this.dtOneTimeOccurDate);
            this.grpOneTimeOccur.Location = new System.Drawing.Point(15, 75);
            this.grpOneTimeOccur.Name = "grpOneTimeOccur";
            this.grpOneTimeOccur.Size = new System.Drawing.Size(471, 65);
            this.grpOneTimeOccur.TabIndex = 5;
            this.grpOneTimeOccur.TabStop = false;
            this.grpOneTimeOccur.Text = "One-time occurrence";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(254, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Time:";
            // 
            // dtOneTimeOccurTime
            // 
            this.dtOneTimeOccurTime.CustomFormat = "HH:mm:ss";
            this.dtOneTimeOccurTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOneTimeOccurTime.Location = new System.Drawing.Point(299, 21);
            this.dtOneTimeOccurTime.Name = "dtOneTimeOccurTime";
            this.dtOneTimeOccurTime.ShowUpDown = true;
            this.dtOneTimeOccurTime.Size = new System.Drawing.Size(68, 20);
            this.dtOneTimeOccurTime.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Date:";
            // 
            // dtOneTimeOccurDate
            // 
            this.dtOneTimeOccurDate.CustomFormat = "dd/MM/yyyy";
            this.dtOneTimeOccurDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtOneTimeOccurDate.Location = new System.Drawing.Point(115, 21);
            this.dtOneTimeOccurDate.Name = "dtOneTimeOccurDate";
            this.dtOneTimeOccurDate.Size = new System.Drawing.Size(92, 20);
            this.dtOneTimeOccurDate.TabIndex = 0;
            // 
            // grpFrequency
            // 
            this.grpFrequency.Controls.Add(this.lblFrequencyThe2);
            this.grpFrequency.Controls.Add(this.numFrequencyTheEvery);
            this.grpFrequency.Controls.Add(this.lblFrequencyThe1);
            this.grpFrequency.Controls.Add(this.cmbFrequencyTheWeekday);
            this.grpFrequency.Controls.Add(this.cmbFrequencyThe);
            this.grpFrequency.Controls.Add(this.lblFrequencyDay2);
            this.grpFrequency.Controls.Add(this.numFrequencyDayEvery);
            this.grpFrequency.Controls.Add(this.lblFrequencyDay1);
            this.grpFrequency.Controls.Add(this.numFrequencyDay);
            this.grpFrequency.Controls.Add(this.optFrequencyThe);
            this.grpFrequency.Controls.Add(this.optFrequencyDay);
            this.grpFrequency.Controls.Add(this.chkFrequencyRecursSun);
            this.grpFrequency.Controls.Add(this.chkFrequencyRecursSat);
            this.grpFrequency.Controls.Add(this.chkFrequencyRecursFri);
            this.grpFrequency.Controls.Add(this.chkFrequencyRecursThu);
            this.grpFrequency.Controls.Add(this.chkFrequencyRecursWed);
            this.grpFrequency.Controls.Add(this.chkFrequencyRecursTue);
            this.grpFrequency.Controls.Add(this.chkFrequencyRecursMon);
            this.grpFrequency.Controls.Add(this.lblFrequencyRecursWhat);
            this.grpFrequency.Controls.Add(this.lblFrequencyRecurs);
            this.grpFrequency.Controls.Add(this.numFrequencyRecurs);
            this.grpFrequency.Controls.Add(this.cmbFrequencyOccurs);
            this.grpFrequency.Controls.Add(this.label5);
            this.grpFrequency.Location = new System.Drawing.Point(15, 131);
            this.grpFrequency.Name = "grpFrequency";
            this.grpFrequency.Size = new System.Drawing.Size(471, 155);
            this.grpFrequency.TabIndex = 6;
            this.grpFrequency.TabStop = false;
            this.grpFrequency.Text = "Frequency";
            // 
            // lblFrequencyThe2
            // 
            this.lblFrequencyThe2.AutoSize = true;
            this.lblFrequencyThe2.Location = new System.Drawing.Point(380, 102);
            this.lblFrequencyThe2.Name = "lblFrequencyThe2";
            this.lblFrequencyThe2.Size = new System.Drawing.Size(47, 13);
            this.lblFrequencyThe2.TabIndex = 26;
            this.lblFrequencyThe2.Text = "month(s)";
            // 
            // numFrequencyTheEvery
            // 
            this.numFrequencyTheEvery.Location = new System.Drawing.Point(314, 100);
            this.numFrequencyTheEvery.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numFrequencyTheEvery.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFrequencyTheEvery.Name = "numFrequencyTheEvery";
            this.numFrequencyTheEvery.Size = new System.Drawing.Size(60, 20);
            this.numFrequencyTheEvery.TabIndex = 25;
            this.numFrequencyTheEvery.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblFrequencyThe1
            // 
            this.lblFrequencyThe1.AutoSize = true;
            this.lblFrequencyThe1.Location = new System.Drawing.Point(263, 102);
            this.lblFrequencyThe1.Name = "lblFrequencyThe1";
            this.lblFrequencyThe1.Size = new System.Drawing.Size(45, 13);
            this.lblFrequencyThe1.TabIndex = 24;
            this.lblFrequencyThe1.Text = "of every";
            // 
            // cmbFrequencyTheWeekday
            // 
            this.cmbFrequencyTheWeekday.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrequencyTheWeekday.FormattingEnabled = true;
            this.cmbFrequencyTheWeekday.Items.AddRange(new object[] {
            "Sunday",
            "Monday",
            "Tuesday",
            "Wednesday",
            "Thursday",
            "Friday",
            "Saturday",
            "day",
            "weekday",
            "weekend day"});
            this.cmbFrequencyTheWeekday.Location = new System.Drawing.Point(155, 100);
            this.cmbFrequencyTheWeekday.Name = "cmbFrequencyTheWeekday";
            this.cmbFrequencyTheWeekday.Size = new System.Drawing.Size(100, 21);
            this.cmbFrequencyTheWeekday.TabIndex = 23;
            // 
            // cmbFrequencyThe
            // 
            this.cmbFrequencyThe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrequencyThe.FormattingEnabled = true;
            this.cmbFrequencyThe.Items.AddRange(new object[] {
            "first",
            "second",
            "third",
            "fourth",
            "last"});
            this.cmbFrequencyThe.Location = new System.Drawing.Point(66, 100);
            this.cmbFrequencyThe.Name = "cmbFrequencyThe";
            this.cmbFrequencyThe.Size = new System.Drawing.Size(83, 21);
            this.cmbFrequencyThe.TabIndex = 22;
            // 
            // lblFrequencyDay2
            // 
            this.lblFrequencyDay2.AutoSize = true;
            this.lblFrequencyDay2.Location = new System.Drawing.Point(241, 74);
            this.lblFrequencyDay2.Name = "lblFrequencyDay2";
            this.lblFrequencyDay2.Size = new System.Drawing.Size(47, 13);
            this.lblFrequencyDay2.TabIndex = 21;
            this.lblFrequencyDay2.Text = "month(s)";
            // 
            // numFrequencyDayEvery
            // 
            this.numFrequencyDayEvery.Location = new System.Drawing.Point(175, 72);
            this.numFrequencyDayEvery.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            0});
            this.numFrequencyDayEvery.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFrequencyDayEvery.Name = "numFrequencyDayEvery";
            this.numFrequencyDayEvery.Size = new System.Drawing.Size(60, 20);
            this.numFrequencyDayEvery.TabIndex = 20;
            this.numFrequencyDayEvery.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblFrequencyDay1
            // 
            this.lblFrequencyDay1.AutoSize = true;
            this.lblFrequencyDay1.Location = new System.Drawing.Point(124, 74);
            this.lblFrequencyDay1.Name = "lblFrequencyDay1";
            this.lblFrequencyDay1.Size = new System.Drawing.Size(45, 13);
            this.lblFrequencyDay1.TabIndex = 19;
            this.lblFrequencyDay1.Text = "of every";
            // 
            // numFrequencyDay
            // 
            this.numFrequencyDay.Location = new System.Drawing.Point(66, 72);
            this.numFrequencyDay.Maximum = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.numFrequencyDay.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFrequencyDay.Name = "numFrequencyDay";
            this.numFrequencyDay.Size = new System.Drawing.Size(52, 20);
            this.numFrequencyDay.TabIndex = 18;
            this.numFrequencyDay.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // optFrequencyThe
            // 
            this.optFrequencyThe.AutoSize = true;
            this.optFrequencyThe.Location = new System.Drawing.Point(16, 101);
            this.optFrequencyThe.Name = "optFrequencyThe";
            this.optFrequencyThe.Size = new System.Drawing.Size(44, 17);
            this.optFrequencyThe.TabIndex = 17;
            this.optFrequencyThe.TabStop = true;
            this.optFrequencyThe.Text = "The";
            this.optFrequencyThe.UseVisualStyleBackColor = true;
            // 
            // optFrequencyDay
            // 
            this.optFrequencyDay.AutoSize = true;
            this.optFrequencyDay.Location = new System.Drawing.Point(16, 72);
            this.optFrequencyDay.Name = "optFrequencyDay";
            this.optFrequencyDay.Size = new System.Drawing.Size(44, 17);
            this.optFrequencyDay.TabIndex = 16;
            this.optFrequencyDay.TabStop = true;
            this.optFrequencyDay.Text = "Day";
            this.optFrequencyDay.UseVisualStyleBackColor = true;
            this.optFrequencyDay.CheckedChanged += new System.EventHandler(this.optFrequencyDay_CheckedChanged);
            // 
            // chkFrequencyRecursSun
            // 
            this.chkFrequencyRecursSun.AutoSize = true;
            this.chkFrequencyRecursSun.Location = new System.Drawing.Point(415, 47);
            this.chkFrequencyRecursSun.Name = "chkFrequencyRecursSun";
            this.chkFrequencyRecursSun.Size = new System.Drawing.Size(45, 17);
            this.chkFrequencyRecursSun.TabIndex = 15;
            this.chkFrequencyRecursSun.Text = "Sun";
            this.chkFrequencyRecursSun.UseVisualStyleBackColor = true;
            // 
            // chkFrequencyRecursSat
            // 
            this.chkFrequencyRecursSat.AutoSize = true;
            this.chkFrequencyRecursSat.Location = new System.Drawing.Point(359, 75);
            this.chkFrequencyRecursSat.Name = "chkFrequencyRecursSat";
            this.chkFrequencyRecursSat.Size = new System.Drawing.Size(42, 17);
            this.chkFrequencyRecursSat.TabIndex = 14;
            this.chkFrequencyRecursSat.Text = "Sat";
            this.chkFrequencyRecursSat.UseVisualStyleBackColor = true;
            // 
            // chkFrequencyRecursFri
            // 
            this.chkFrequencyRecursFri.AutoSize = true;
            this.chkFrequencyRecursFri.Location = new System.Drawing.Point(359, 61);
            this.chkFrequencyRecursFri.Name = "chkFrequencyRecursFri";
            this.chkFrequencyRecursFri.Size = new System.Drawing.Size(37, 17);
            this.chkFrequencyRecursFri.TabIndex = 13;
            this.chkFrequencyRecursFri.Text = "Fri";
            this.chkFrequencyRecursFri.UseVisualStyleBackColor = true;
            // 
            // chkFrequencyRecursThu
            // 
            this.chkFrequencyRecursThu.AutoSize = true;
            this.chkFrequencyRecursThu.Location = new System.Drawing.Point(359, 47);
            this.chkFrequencyRecursThu.Name = "chkFrequencyRecursThu";
            this.chkFrequencyRecursThu.Size = new System.Drawing.Size(45, 17);
            this.chkFrequencyRecursThu.TabIndex = 12;
            this.chkFrequencyRecursThu.Text = "Thu";
            this.chkFrequencyRecursThu.UseVisualStyleBackColor = true;
            // 
            // chkFrequencyRecursWed
            // 
            this.chkFrequencyRecursWed.AutoSize = true;
            this.chkFrequencyRecursWed.Location = new System.Drawing.Point(301, 75);
            this.chkFrequencyRecursWed.Name = "chkFrequencyRecursWed";
            this.chkFrequencyRecursWed.Size = new System.Drawing.Size(49, 17);
            this.chkFrequencyRecursWed.TabIndex = 11;
            this.chkFrequencyRecursWed.Text = "Wed";
            this.chkFrequencyRecursWed.UseVisualStyleBackColor = true;
            // 
            // chkFrequencyRecursTue
            // 
            this.chkFrequencyRecursTue.AutoSize = true;
            this.chkFrequencyRecursTue.Location = new System.Drawing.Point(301, 61);
            this.chkFrequencyRecursTue.Name = "chkFrequencyRecursTue";
            this.chkFrequencyRecursTue.Size = new System.Drawing.Size(45, 17);
            this.chkFrequencyRecursTue.TabIndex = 10;
            this.chkFrequencyRecursTue.Text = "Tue";
            this.chkFrequencyRecursTue.UseVisualStyleBackColor = true;
            // 
            // chkFrequencyRecursMon
            // 
            this.chkFrequencyRecursMon.AutoSize = true;
            this.chkFrequencyRecursMon.Location = new System.Drawing.Point(301, 47);
            this.chkFrequencyRecursMon.Name = "chkFrequencyRecursMon";
            this.chkFrequencyRecursMon.Size = new System.Drawing.Size(47, 17);
            this.chkFrequencyRecursMon.TabIndex = 9;
            this.chkFrequencyRecursMon.Text = "Mon";
            this.chkFrequencyRecursMon.UseVisualStyleBackColor = true;
            // 
            // lblFrequencyRecursWhat
            // 
            this.lblFrequencyRecursWhat.AutoSize = true;
            this.lblFrequencyRecursWhat.Location = new System.Drawing.Point(181, 50);
            this.lblFrequencyRecursWhat.Name = "lblFrequencyRecursWhat";
            this.lblFrequencyRecursWhat.Size = new System.Drawing.Size(35, 13);
            this.lblFrequencyRecursWhat.TabIndex = 8;
            this.lblFrequencyRecursWhat.Text = "day(s)";
            // 
            // lblFrequencyRecurs
            // 
            this.lblFrequencyRecurs.AutoSize = true;
            this.lblFrequencyRecurs.Location = new System.Drawing.Point(13, 48);
            this.lblFrequencyRecurs.Name = "lblFrequencyRecurs";
            this.lblFrequencyRecurs.Size = new System.Drawing.Size(73, 13);
            this.lblFrequencyRecurs.TabIndex = 7;
            this.lblFrequencyRecurs.Text = "Recurs every:";
            // 
            // numFrequencyRecurs
            // 
            this.numFrequencyRecurs.Location = new System.Drawing.Point(115, 46);
            this.numFrequencyRecurs.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numFrequencyRecurs.Name = "numFrequencyRecurs";
            this.numFrequencyRecurs.Size = new System.Drawing.Size(60, 20);
            this.numFrequencyRecurs.TabIndex = 6;
            this.numFrequencyRecurs.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cmbFrequencyOccurs
            // 
            this.cmbFrequencyOccurs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFrequencyOccurs.FormattingEnabled = true;
            this.cmbFrequencyOccurs.Items.AddRange(new object[] {
            "Daily",
            "Weekly",
            "Monthly"});
            this.cmbFrequencyOccurs.Location = new System.Drawing.Point(115, 19);
            this.cmbFrequencyOccurs.Name = "cmbFrequencyOccurs";
            this.cmbFrequencyOccurs.Size = new System.Drawing.Size(177, 21);
            this.cmbFrequencyOccurs.TabIndex = 5;
            this.cmbFrequencyOccurs.SelectedIndexChanged += new System.EventHandler(this.cmbFrequencyOccurs_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Occurs:";
            // 
            // grpDailyFreq
            // 
            this.grpDailyFreq.Controls.Add(this.label13);
            this.grpDailyFreq.Controls.Add(this.dtDailyFreqEnd);
            this.grpDailyFreq.Controls.Add(this.label12);
            this.grpDailyFreq.Controls.Add(this.dtDailyFreqStart);
            this.grpDailyFreq.Controls.Add(this.dtDailyFreqOnce);
            this.grpDailyFreq.Controls.Add(this.cmbDailyFreqEvery);
            this.grpDailyFreq.Controls.Add(this.numDailyFreqEvery);
            this.grpDailyFreq.Controls.Add(this.optDailyFreqEvery);
            this.grpDailyFreq.Controls.Add(this.optDailyFreqOnce);
            this.grpDailyFreq.Location = new System.Drawing.Point(15, 268);
            this.grpDailyFreq.Name = "grpDailyFreq";
            this.grpDailyFreq.Size = new System.Drawing.Size(471, 128);
            this.grpDailyFreq.TabIndex = 7;
            this.grpDailyFreq.TabStop = false;
            this.grpDailyFreq.Text = "Daily frequency";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(284, 79);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "Ending at:";
            // 
            // dtDailyFreqEnd
            // 
            this.dtDailyFreqEnd.CustomFormat = "HH:mm:ss";
            this.dtDailyFreqEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDailyFreqEnd.Location = new System.Drawing.Point(353, 77);
            this.dtDailyFreqEnd.Name = "dtDailyFreqEnd";
            this.dtDailyFreqEnd.ShowUpDown = true;
            this.dtDailyFreqEnd.Size = new System.Drawing.Size(70, 20);
            this.dtDailyFreqEnd.TabIndex = 30;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(284, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "Starting at:";
            // 
            // dtDailyFreqStart
            // 
            this.dtDailyFreqStart.CustomFormat = "HH:mm:ss";
            this.dtDailyFreqStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDailyFreqStart.Location = new System.Drawing.Point(353, 55);
            this.dtDailyFreqStart.Name = "dtDailyFreqStart";
            this.dtDailyFreqStart.ShowUpDown = true;
            this.dtDailyFreqStart.Size = new System.Drawing.Size(70, 20);
            this.dtDailyFreqStart.TabIndex = 28;
            // 
            // dtDailyFreqOnce
            // 
            this.dtDailyFreqOnce.CustomFormat = "HH:mm:ss";
            this.dtDailyFreqOnce.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDailyFreqOnce.Location = new System.Drawing.Point(121, 24);
            this.dtDailyFreqOnce.Name = "dtDailyFreqOnce";
            this.dtDailyFreqOnce.ShowUpDown = true;
            this.dtDailyFreqOnce.Size = new System.Drawing.Size(70, 20);
            this.dtDailyFreqOnce.TabIndex = 27;
            // 
            // cmbDailyFreqEvery
            // 
            this.cmbDailyFreqEvery.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDailyFreqEvery.FormattingEnabled = true;
            this.cmbDailyFreqEvery.Items.AddRange(new object[] {
            "hour(s)",
            "minute(s)",
            "second(s)"});
            this.cmbDailyFreqEvery.Location = new System.Drawing.Point(172, 54);
            this.cmbDailyFreqEvery.Name = "cmbDailyFreqEvery";
            this.cmbDailyFreqEvery.Size = new System.Drawing.Size(83, 21);
            this.cmbDailyFreqEvery.TabIndex = 22;
            this.cmbDailyFreqEvery.SelectedIndexChanged += new System.EventHandler(this.cmbDailyFreqEvery_SelectedIndexChanged);
            // 
            // numDailyFreqEvery
            // 
            this.numDailyFreqEvery.Location = new System.Drawing.Point(121, 54);
            this.numDailyFreqEvery.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numDailyFreqEvery.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDailyFreqEvery.Name = "numDailyFreqEvery";
            this.numDailyFreqEvery.Size = new System.Drawing.Size(48, 20);
            this.numDailyFreqEvery.TabIndex = 18;
            this.numDailyFreqEvery.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // optDailyFreqEvery
            // 
            this.optDailyFreqEvery.AutoSize = true;
            this.optDailyFreqEvery.Location = new System.Drawing.Point(16, 54);
            this.optDailyFreqEvery.Name = "optDailyFreqEvery";
            this.optDailyFreqEvery.Size = new System.Drawing.Size(91, 17);
            this.optDailyFreqEvery.TabIndex = 17;
            this.optDailyFreqEvery.TabStop = true;
            this.optDailyFreqEvery.Text = "Occurs every:";
            this.optDailyFreqEvery.UseVisualStyleBackColor = true;
            // 
            // optDailyFreqOnce
            // 
            this.optDailyFreqOnce.AutoSize = true;
            this.optDailyFreqOnce.Location = new System.Drawing.Point(16, 26);
            this.optDailyFreqOnce.Name = "optDailyFreqOnce";
            this.optDailyFreqOnce.Size = new System.Drawing.Size(101, 17);
            this.optDailyFreqOnce.TabIndex = 16;
            this.optDailyFreqOnce.TabStop = true;
            this.optDailyFreqOnce.Text = "Occurs once at:";
            this.optDailyFreqOnce.UseVisualStyleBackColor = true;
            this.optDailyFreqOnce.CheckedChanged += new System.EventHandler(this.optDailyFreqOnce_CheckedChanged);
            // 
            // grpDuration
            // 
            this.grpDuration.Controls.Add(this.optDurationNoEnd);
            this.grpDuration.Controls.Add(this.dtDurationEnd);
            this.grpDuration.Controls.Add(this.optDurationEnd);
            this.grpDuration.Controls.Add(this.label15);
            this.grpDuration.Controls.Add(this.dtDurationStart);
            this.grpDuration.Location = new System.Drawing.Point(15, 372);
            this.grpDuration.Name = "grpDuration";
            this.grpDuration.Size = new System.Drawing.Size(471, 65);
            this.grpDuration.TabIndex = 8;
            this.grpDuration.TabStop = false;
            this.grpDuration.Text = "Duration";
            // 
            // optDurationNoEnd
            // 
            this.optDurationNoEnd.AutoSize = true;
            this.optDurationNoEnd.Location = new System.Drawing.Point(282, 42);
            this.optDurationNoEnd.Name = "optDurationNoEnd";
            this.optDurationNoEnd.Size = new System.Drawing.Size(84, 17);
            this.optDurationNoEnd.TabIndex = 4;
            this.optDurationNoEnd.TabStop = true;
            this.optDurationNoEnd.Text = "No end date";
            this.optDurationNoEnd.UseVisualStyleBackColor = true;
            // 
            // dtDurationEnd
            // 
            this.dtDurationEnd.CustomFormat = "dd/MM/yyyy";
            this.dtDurationEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDurationEnd.Location = new System.Drawing.Point(353, 21);
            this.dtDurationEnd.Name = "dtDurationEnd";
            this.dtDurationEnd.Size = new System.Drawing.Size(92, 20);
            this.dtDurationEnd.TabIndex = 3;
            // 
            // optDurationEnd
            // 
            this.optDurationEnd.AutoSize = true;
            this.optDurationEnd.Location = new System.Drawing.Point(282, 22);
            this.optDurationEnd.Name = "optDurationEnd";
            this.optDurationEnd.Size = new System.Drawing.Size(71, 17);
            this.optDurationEnd.TabIndex = 2;
            this.optDurationEnd.TabStop = true;
            this.optDurationEnd.Text = "End date:";
            this.optDurationEnd.UseVisualStyleBackColor = true;
            this.optDurationEnd.CheckedChanged += new System.EventHandler(this.optDurationEnd_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(51, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Start date:";
            // 
            // dtDurationStart
            // 
            this.dtDurationStart.CustomFormat = "dd/MM/yyyy";
            this.dtDurationStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDurationStart.Location = new System.Drawing.Point(115, 21);
            this.dtDurationStart.Name = "dtDurationStart";
            this.dtDurationStart.Size = new System.Drawing.Size(92, 20);
            this.dtDurationStart.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(329, 449);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 9;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(411, 449);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfigure
            // 
            this.btnConfigure.Location = new System.Drawing.Point(400, 10);
            this.btnConfigure.Name = "btnConfigure";
            this.btnConfigure.Size = new System.Drawing.Size(86, 23);
            this.btnConfigure.TabIndex = 11;
            this.btnConfigure.Text = "Configure";
            this.btnConfigure.UseVisualStyleBackColor = true;
            // 
            // ModSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(503, 484);
            this.Controls.Add(this.btnConfigure);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.grpDuration);
            this.Controls.Add(this.grpDailyFreq);
            this.Controls.Add(this.grpFrequency);
            this.Controls.Add(this.grpOneTimeOccur);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.cmbScheduleType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModSchedule";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Schedule Editor";
            this.Load += new System.EventHandler(this.ModSchedule_Load);
            this.grpOneTimeOccur.ResumeLayout(false);
            this.grpOneTimeOccur.PerformLayout();
            this.grpFrequency.ResumeLayout(false);
            this.grpFrequency.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequencyTheEvery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequencyDayEvery)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequencyDay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFrequencyRecurs)).EndInit();
            this.grpDailyFreq.ResumeLayout(false);
            this.grpDailyFreq.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDailyFreqEvery)).EndInit();
            this.grpDuration.ResumeLayout(false);
            this.grpDuration.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbScheduleType;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.GroupBox grpOneTimeOccur;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtOneTimeOccurTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtOneTimeOccurDate;
        private System.Windows.Forms.GroupBox grpFrequency;
        private System.Windows.Forms.ComboBox cmbFrequencyOccurs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblFrequencyRecursWhat;
        private System.Windows.Forms.Label lblFrequencyRecurs;
        private System.Windows.Forms.NumericUpDown numFrequencyRecurs;
        private System.Windows.Forms.CheckBox chkFrequencyRecursSun;
        private System.Windows.Forms.CheckBox chkFrequencyRecursSat;
        private System.Windows.Forms.CheckBox chkFrequencyRecursFri;
        private System.Windows.Forms.CheckBox chkFrequencyRecursThu;
        private System.Windows.Forms.CheckBox chkFrequencyRecursWed;
        private System.Windows.Forms.CheckBox chkFrequencyRecursTue;
        private System.Windows.Forms.CheckBox chkFrequencyRecursMon;
        private System.Windows.Forms.NumericUpDown numFrequencyDayEvery;
        private System.Windows.Forms.Label lblFrequencyDay1;
        private System.Windows.Forms.NumericUpDown numFrequencyDay;
        private System.Windows.Forms.RadioButton optFrequencyThe;
        private System.Windows.Forms.RadioButton optFrequencyDay;
        private System.Windows.Forms.Label lblFrequencyThe2;
        private System.Windows.Forms.NumericUpDown numFrequencyTheEvery;
        private System.Windows.Forms.Label lblFrequencyThe1;
        private System.Windows.Forms.ComboBox cmbFrequencyTheWeekday;
        private System.Windows.Forms.ComboBox cmbFrequencyThe;
        private System.Windows.Forms.Label lblFrequencyDay2;
        private System.Windows.Forms.GroupBox grpDailyFreq;
        private System.Windows.Forms.ComboBox cmbDailyFreqEvery;
        private System.Windows.Forms.NumericUpDown numDailyFreqEvery;
        private System.Windows.Forms.RadioButton optDailyFreqEvery;
        private System.Windows.Forms.RadioButton optDailyFreqOnce;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker dtDailyFreqStart;
        private System.Windows.Forms.DateTimePicker dtDailyFreqOnce;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker dtDailyFreqEnd;
        private System.Windows.Forms.GroupBox grpDuration;
        private System.Windows.Forms.RadioButton optDurationEnd;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dtDurationStart;
        private System.Windows.Forms.RadioButton optDurationNoEnd;
        private System.Windows.Forms.DateTimePicker dtDurationEnd;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
