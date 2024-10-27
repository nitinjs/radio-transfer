using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thorn = Thornton.Scheduler.Quartz;

namespace Thornton.Scheduler
{
    public class MyService
    {
        Thorn.ITaskScheduler scheduler;
        public void Start()
        {
            scheduler = new Thorn.TaskScheduler();
            scheduler.Run();
        }
        public void Stop()
        {
            if (scheduler != null)
            {
                scheduler.Stop();
            }
        }
    }
}
