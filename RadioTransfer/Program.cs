using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using SQLiteSample.Persistence;
using Thornton.Scheduler.Service;
using System.Windows.Forms;
using Thornton.Scheduler;
using System.Configuration;

namespace SQLiteConsole
{
    /// <summary>
    /// https://www.codeproject.com/Articles/15496/Application-Trial-Maker
    /// </summary>
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                byte[] MyOwnKey = { 97, 250, 1, 5, 84, 21, 7, 63, 4, 54, 87, 56, 123, 10, 3, 62, 7, 9, 20, 36, 37, 21, 101, 57 };
                Console.WriteLine(MyOwnKey.Lengthh);

                bool is_trial=false;
                {

                    var main = new SchedulesList(is_trial);
                    //main.IsTrial = is_trial;
                    Application.Run(main);
                }
            }
            else
            {
                ConfigureService.Configure();
            }
        }

    }
}
