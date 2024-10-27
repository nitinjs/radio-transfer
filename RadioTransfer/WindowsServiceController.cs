using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Thornton.Scheduler
{
    public class WindowsServiceController
    {
        private string serviceName = ConfigureService.ServiceName;

        public WindowsServiceController()
        {
            this.serviceName = ConfigureService.ServiceName;
        }

        // this method will throw an exception if the serivce is NOT in Running status.
        public void RestartService()
        {
            using (ServiceController service = new ServiceController(serviceName))
            {
                try
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);

                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Can not restart the Windows Service " + serviceName);
                }
            }
        }

        // this method will throw an exception if the serivce is NOT in Running status.
        public void StopService()
        {
            using (ServiceController service = new ServiceController(serviceName))
            {
                try
                {
                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Can not stop the Windows Service " + serviceName);
                }
            }
        }

        // this method will throw an exception if the service is NOT in Stopped status.
        public void StartService()
        {
            using (ServiceController service = new ServiceController(serviceName))
            {
                try
                {
                    service.Start();
                    service.WaitForStatus(ServiceControllerStatus.Running);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Can not start the Windows Service " + serviceName);
                }
            }
        }

        // if service running then restart the serivce, if the service is stopped then start it.
        // this method will not throw an exception.
        public void StartOrRestart()
        {
            if (IsRunningStatus)
                RestartService();
            else if (IsStoppedStatus)
                StartService();
        }

        // stop the service if it is running, if it is already stopped then do nothing.
        // this method will not throw an exception if the service is in Stopped status.
        public void StopServiceIfRunning()
        {
            using (ServiceController service = new ServiceController(serviceName))
            {
                try
                {
                    if (!IsRunningStatus)
                        return;

                    service.Stop();
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Can not stop the Windows Service " + serviceName);
                }
            }
        }

        public bool IsRunningStatus => Status == ServiceControllerStatus.Running;

        public bool IsStoppedStatus => Status == ServiceControllerStatus.Stopped;

        public ServiceControllerStatus? Status
        {
            get
            {
                try
                {
                    using (ServiceController service = new ServiceController(serviceName))
                    {
                        return service.Status;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
    }
}
