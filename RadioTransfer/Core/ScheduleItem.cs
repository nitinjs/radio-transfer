using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thornton.Scheduler.Core
{
    public class ScheduleItem
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public String StartDate { get; set; }
        public String StartTime { get; set; }
        public String EndDate { get; set; }
        public String IsOnetime { get; set; }
        public string Enabled { get; set; }
    }
}
