using CronExpressionDescriptor;
using Quartz;
using Quartz.Impl;
using QuartzCronGenerator;
using SQLiteSample.Persistence;
using SQLjobScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Thornton.Data;
using Thornton.Scheduler.Core;
using Thornton.Scheduler.Quartz;
using Thornton.Scheduler.Service;
using Collection = Quartz.Collection;

namespace Thornton.Scheduler
{
    public partial class SchedulesList : Form
    {
        WindowsServiceController serviceController = new WindowsServiceController();
        public ThorntonContext Db { get; set; }

        public bool IsTrial { get; set; }
        public SchedulesList(bool isTrial = false)
        {
            IsTrial = isTrial;
            var splash = new Splash();
            splash.IsTrial = IsTrial;
            this.Hide();
            splash.ShowDialog();
            InitializeComponent();
            //registerToolStripMenuItem.Visible = IsTrial;
            Db = new ThorntonContext();
            this.Show();

            bool DEBUG = Convert.ToBoolean(ConfigurationManager.AppSettings["DEBUG"]);
            if (DEBUG)
            {
                if (MessageBox.Show("Run schedules now?", "Radio Transfer", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var service = new MyService();
                    service.Start();
                }
            }
        }
        private void BindServiceStatus()
        {
            //lblServiceStatus.Text = ("Radio Transfer service " + (serviceController.Status == null ? "not installed" : serviceController.Status.ToString())) + ".";
        }
        private void ConfigureSchedules_Load(object sender, EventArgs e)
        {
            BindServiceStatus();
            if (Db.TaskTypes.Count() == 0)
            {
                string[] types = { "HTTP", "FTP", "SFTP", "RSS", "Google Drive", "Dropbox" };
                foreach (string gt in types)
                {
                    var obj = new TaskType()
                    {
                        Name = gt
                    };
                    Db.TaskTypes.Add(obj);
                }
                Db.SaveChanges();
            }
            BindGrid();

            //DataGridViewButtonColumn btnView = new DataGridViewButtonColumn();
            //btnView.HeaderText = "";
            //btnView.Text = "View";
            //btnView.UseColumnTextForButtonValue = true;
            //btnView.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //grdSchedules.Columns.Insert(0, btnView);

            DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
            btnEdit.HeaderText = "";
            btnEdit.Text = "Edit";
            btnEdit.UseColumnTextForButtonValue = true;
            btnEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdSchedules.Columns.Insert(0, btnEdit);

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.HeaderText = "";
            btnDelete.Text = "Delete";
            btnDelete.UseColumnTextForButtonValue = true;
            btnDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            grdSchedules.Columns.Insert(0, btnDelete);

            //ReorderColumn("SQLscheduleId", 3, "Id");
            //ReorderColumn("name", 4, "Name");
            //ReorderColumn("TaskTypeId", 5, "Task Type");
            //ReorderColumn("date_created", 6, "Created Date");
            //ReorderColumn("enabled", 7, "Enabled");
            //var columns = grdSchedules.Columns.Cast<DataGridViewColumn>();
            //for (int i = 8; i < columns.Count(); i++)
            //{
            //    var col = columns.ElementAt(i);
            //    col.Visible = false;
            //}

            //grdSchedules.Columns["freq_type"].Visible = false;
            //grdSchedules.Columns["freq_interval"].Visible = false;
        }

        public DataGridViewColumn ReorderColumn(string name, int index, string newName)
        {
            var column = grdSchedules.Columns[name];
            column.DisplayIndex = index;
            column.HeaderText = newName;
            return column;
        }

        public void BindGrid()
        {
            var lst = new List<ScheduleItem>();
            foreach (var item in Db.SQLschedules.ToList())
            {
                var sch = new ScheduleItem();
                sch.Id = item.SQLscheduleId;
                sch.TaskName = item.name;
                sch.StartDate = String.Format("{0:MM/dd/yyyy}", item.active_start_date);
                //sch.StartTime = new TimeSpan(item.active_start_time.Hour, item.active_start_time.Minute, item.active_start_time.Second).ToString();
                sch.EndDate = item.active_end_date.HasValue ? String.Format("{0:MM/dd/yyyy}", item.active_end_date) : "-";
                if (sch.EndDate == "12/31/9998")
                {
                    sch.EndDate = "No end date";
                }
                sch.StartTime = item.IsOnetime ? new TimeSpan(item.active_start_date.Hour, item.active_start_date.Minute, item.active_start_date.Second).ToString() : "-";
                if (!string.IsNullOrWhiteSpace(item.CronExpression))
                    sch.Description = item.IsOnetime ? "Once" : ExpressionDescriptor.GetDescription(item.CronExpression, new Options()
                    {
                        DayOfWeekStartIndexZero = false,
                        Use24HourTimeFormat = true,
                        Locale = "en"
                    });
                sch.IsOnetime = item.IsOnetime ? "Yes" : "No";
                sch.Enabled = item.enabled ? "Yes" : "No";
                lst.Add(sch);
            }
            grdSchedules.DataSource = lst;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ab = new About();
            ab.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var schedule = new MainForm();
            schedule.TaskTypes = Db.TaskTypes.ToList();
            if (schedule.ShowDialog() == DialogResult.OK)
            {
                Db.SQLschedules.Add(schedule.Schedule);
                Db.SaveChanges();

                BindGrid();
            }
        }

        private void grdSchedules_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.ColumnIndex == 0)
            {
                var id = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                var name = senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString();
                DeleteTask(id, name);
            }
            else if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                (e.ColumnIndex == 1))
            {
                var id = Convert.ToInt32(senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString());
                EditTask(id);
            }
        }

        public void EditTask(int id)
        {
            var row = Db.SQLschedules.Where(x => x.SQLscheduleId == id).FirstOrDefault();
            var schedule = new MainForm(row, Db.TaskTypes.ToList(), false);
            if (schedule.ShowDialog() == DialogResult.OK)
            {
                Db.Entry(row).State = System.Data.Entity.EntityState.Modified;
                Db.SaveChanges();
                BindGrid();
            }
        }

        public void DeleteTask(int id, string name)
        {
            if (MessageBox.Show("Delete scheduled task '" + id + ". " + name + "'?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var logs = Db.TaskExecutionLogs.Where(x => x.SQLscheduleId == id);
                foreach (var log in logs)
                {
                    Db.Entry<TaskExecutionLog>(log).State = System.Data.Entity.EntityState.Deleted;
                }

                var row = Db.SQLschedules.Where(x => x.SQLscheduleId == id).FirstOrDefault();
                Db.Entry<SQLschedule>(row).State = System.Data.Entity.EntityState.Deleted;
                Db.SaveChanges();
                BindGrid();
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serviceController.StartOrRestart();
            BindServiceStatus();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            serviceController.StopServiceIfRunning();
            BindServiceStatus();
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void specialButton2_Click(object sender, EventArgs e)
        {
            if (grdSchedules.SelectedRows.Count > 0)
            {
                var id = Convert.ToInt32(grdSchedules.SelectedRows[0].Cells[2].Value.ToString());
                EditTask(id);
            }
            else
            {
                MessageBox.Show("Please select row from grid.");
            }
        }

        private void specialButton3_Click(object sender, EventArgs e)
        {
            if (grdSchedules.SelectedRows.Count > 0)
            {
                var id = Convert.ToInt32(grdSchedules.SelectedRows[0].Cells[2].Value.ToString());
                var record = Db.SQLschedules.AsNoTracking().Where(x => x.SQLscheduleId == id).FirstOrDefault();
                record.SQLscheduleId = 0;
                record.name = record.name + " - copy";
                record.date_created = DateTime.Now;
                record.date_modified = null;
                record.IsProcessing = false;

                Db.Entry<SQLschedule>(record).State = System.Data.Entity.EntityState.Added;
                Db.SaveChanges();

                EditTask(record.SQLscheduleId);
            }
            else
            {
                MessageBox.Show("Please select row from grid.");
            }
        }

        private void specialButton4_Click(object sender, EventArgs e)
        {
            if (grdSchedules.SelectedRows.Count > 0)
            {
                var id = Convert.ToInt32(grdSchedules.SelectedRows[0].Cells[2].Value.ToString());
                var record = Db.SQLschedules.Where(x => x.SQLscheduleId == id).FirstOrDefault();
                if (record != null)
                {
                    record.enabled = !record.enabled;
                    Db.Entry<SQLschedule>(record).State = System.Data.Entity.EntityState.Modified;
                    Db.SaveChanges();
                    BindGrid();
                }
            }
            else
            {
                MessageBox.Show("Please select row from grid.");
            }
        }

        private void specialButton5_Click(object sender, EventArgs e)
        {
            if (grdSchedules.SelectedRows.Count > 0)
            {
                Thread th = new Thread(new ThreadStart(() =>
                {
                    Thread.Sleep(2000);

                    var id = Convert.ToInt32(grdSchedules.SelectedRows[0].Cells[2].Value.ToString());
                    var schedule = Db.SQLschedules.Where(x => x.SQLscheduleId == id).First();

                    ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
                    var _scheduler = schedulerFactory.GetScheduler();

                    string taskGroup = "Thornton";

                    var dictionary = new Dictionary<IJobDetail, Collection.ISet<ITrigger>>();
                    //var dictionary = new Dictionary<IJobDetail, Quartz.Collection.ISet<itrigger>>();﻿

                    var schedules = Db.SQLschedules.Where(x => x.enabled == true).ToList();
                    //foreach (var schedule in schedules)
                    //{
                    string taskName = "Thornton Task " + System.Guid.NewGuid().ToString();
                    IJobDetail scheduledJob = JobBuilder.Create<DownloadTask>()
                            //.WithIdentity(taskName, taskGroup)
                            .WithIdentity(new JobKey(schedule.SQLscheduleId.ToString()))
                            .UsingJobData("id", schedule.SQLscheduleId)
                            .Build();

                    //if (schedule.IsOnetime)//one time
                    //{
                    //if (schedule.active_start_date >= DateTime.Now)
                    //{
                    //var start = new DateTime(schedule.active_start_date.Year, schedule.active_start_date.Month, schedule.active_start_date.Day, schedule.active_start_date.Hour, schedule.active_start_date.Minute, schedule.active_start_date.Second);
                    //var startDateTime = new DateTimeOffset(start);

                    var triggerBuilder = TriggerBuilder.Create()
                            .WithIdentity(taskName, taskGroup)
                            .StartNow();
                    //if (schedule.active_end_date.HasValue)
                    //{
                    //    var end = new DateTime(schedule.active_end_date.Value.Year, schedule.active_end_date.Value.Month, schedule.active_end_date.Value.Day);
                    //    var endDateTime = new DateTimeOffset(end);
                    //    triggerBuilder = triggerBuilder.EndAt(endDateTime);
                    //}

                    ITrigger scheduledTrigger = triggerBuilder.Build();

                    dictionary.Add(scheduledJob, new Collection.HashSet<ITrigger>() { scheduledTrigger });
                    //}
                    //}
                    //else//recurring
                    //{
                    //    var start = new DateTime(schedule.active_start_date.Year, schedule.active_start_date.Month, schedule.active_start_date.Day, schedule.active_start_date.Hour, schedule.active_start_date.Minute, schedule.active_start_date.Second);
                    //    var startDateTime = new DateTimeOffset(start);

                    //    var triggerBuilder = TriggerBuilder.Create()
                    //            .WithIdentity(taskName, taskGroup)
                    //            .WithCronSchedule(schedule.CronExpression)
                    //            .StartAt(startDateTime);
                    //    if (schedule.active_end_date.HasValue)
                    //    {
                    //        var end = new DateTime(schedule.active_end_date.Value.Year, schedule.active_end_date.Value.Month, schedule.active_end_date.Value.Day);
                    //        var endDateTime = new DateTimeOffset(end);
                    //        triggerBuilder = triggerBuilder.EndAt(endDateTime);
                    //    }

                    //    ITrigger scheduledTrigger = triggerBuilder.Build();

                    //    dictionary.Add(scheduledJob, new Collection.HashSet<ITrigger>() { scheduledTrigger });
                    //}
                    //}

                    //if (schedules.Count > 0)
                    //{
                    _scheduler.ScheduleJobs(dictionary, false);
                    _scheduler.Start();
                    //}
                }));
                th.IsBackground = true;
                th.Start();

                specialButton6_Click(sender, e);
            }
            else
            {
                MessageBox.Show("Please select row from grid.");
            }
        }

        private void specialButton8_Click(object sender, EventArgs e)
        {
            if (grdSchedules.SelectedRows.Count > 0)
            {

                var id = Convert.ToInt32(grdSchedules.SelectedRows[0].Cells[2].Value.ToString());
                var name = grdSchedules.SelectedRows[0].Cells[3].Value.ToString();
                DeleteTask(id, name);
            }
            else
            {
                MessageBox.Show("Please select row from grid.");
            }
        }

        private void specialButton7_Click(object sender, EventArgs e)
        {
            Application.Exit();
            //Environment.Exit(0);
        }

        private void specialButton7_Click(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Do you want to exit Radio Transfer application?", "Confirm Exit", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                //restart the service - apply the schedule changes (if any)
                //this.Hide();
                //this.ShowInTaskbar = false;
                serviceController.StartOrRestart();

                try
                {
                    Environment.Exit(0);
                }
                catch
                {
                }
            }
        }

        private void specialButton6_Click(object sender, EventArgs e)
        {
            if (grdSchedules.SelectedRows.Count > 0)
            {
                var id = Convert.ToInt32(grdSchedules.SelectedRows[0].Cells[2].Value.ToString());
                var name = grdSchedules.SelectedRows[0].Cells[3].Value.ToString();
                ScheduleHistory history = new ScheduleHistory();
                history.Db = this.Db;
                history.Id = id;
                history.txtName.Text = name;
                if (sender == btnForceStart)
                {
                    history.LimitHistory = true;
                    history.LoadedDateTime = DateTime.Now;
                }
                history.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select row from grid.");
            }
        }
    }
}
