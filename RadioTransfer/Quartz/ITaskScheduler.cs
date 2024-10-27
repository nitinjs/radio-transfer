using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thornton.Scheduler.Quartz
{
    interface ITaskScheduler
    {
        string Name { get; }
        void Run();
        void Stop();
    }
}
