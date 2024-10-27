using SQLjobScheduler;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thornton.Data
{
    //[Table("TaskExecutionLogs")]
    public class TaskExecutionLog
    {
        //private TaskExecutionLog() {

        //}
        public long TaskExecutionLogId { get; set; }
        public long SQLscheduleId { get; set; }
        //public virtual SQLschedule SQLschedule { get; set; }
        public string Description { get; set; }
        public DateTime ExecutedDateTime { get; set; }
    }
}
