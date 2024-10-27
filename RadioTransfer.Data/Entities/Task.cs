using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thornton.Data
{
    public class Task
    {
        [Key]
        public long TaskId { get; set; }
        public string Name { get; set; }
        public string CronExpression { get; set; }
        public int TaskTypeId { get; set; }
        public string Path { get; set; }
        public string OutputPath { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }
        public int NumberOfOcurrences { get; set; }
    }
}
