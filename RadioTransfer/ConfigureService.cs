using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace Thornton.Scheduler
{
    public static class ConfigureService
    {
        public static string ServiceName = "RadioTransfer";
        public static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<MyService>(service =>
                {
                    service.ConstructUsing(s => new MyService());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });

                //Setup Account that window service use to run.  
                configure.RunAsLocalSystem();
                configure.SetServiceName(ServiceName);
                configure.SetDisplayName("Radio Transfer Service");
                configure.SetDescription("Radio Transfer Service for periodically downloading files from FTP, SFTP, HTTP, Google & Dropbox");
            });
        }
    }
}
