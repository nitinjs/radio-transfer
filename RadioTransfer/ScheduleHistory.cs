using SQLiteSample.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thornton.Scheduler
{
    public partial class ScheduleHistory : Form
    {
        public ThorntonContext Db { get; set; }
        public bool LimitHistory { get; set; }
        public DateTime LoadedDateTime { get; set; }
        public int Id { get; set; }
        public ScheduleHistory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ScheduleHistory_Load(object sender, EventArgs e)
        {
            //read the log history
            RefreshLog();
        }

        List<long> loaded = new List<long>();

        public void RefreshLog(bool tick = false)
        {
            var query = Db.TaskExecutionLogs.Where(x => x.SQLscheduleId == Id && loaded.Contains(x.TaskExecutionLogId) == false);
            if (LimitHistory)
            {
                query = query.Where(x => x.ExecutedDateTime >= LoadedDateTime);
            }

            var log = tick == false ? query.OrderByDescending(x => x.ExecutedDateTime).ToList() : query.OrderBy(x => x.ExecutedDateTime).ToList();
            foreach (var l in log)
            {
                string text = l.ExecutedDateTime.ToShortDateString() + " " + l.ExecutedDateTime.ToShortTimeString() + ": " + l.Description + "\n";

                if (tick)
                    PrependTextBox(text);
                else
                    AppendTextBox(text);

                loaded.Add(l.TaskExecutionLogId);
            }
        }

        public void AppendTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            this.txtHistory.Text = this.txtHistory.Text + value + "\n";
        }

        public void PrependTextBox(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(AppendTextBox), new object[] { value });
                return;
            }
            this.txtHistory.Text = value + "\n" + this.txtHistory.Text;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            RefreshLog(true);
        }

        private void txtHistory_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtHistory_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
    }
}
