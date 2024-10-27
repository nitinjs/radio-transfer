using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Collection = Quartz.Collection;
using SQLiteSample.Persistence;
using Quartz.Impl.Triggers;

namespace Thornton.Scheduler.Quartz
{
    public class TaskScheduler : ITaskScheduler
    {
        ThorntonContext Db;
        public TaskScheduler()
        {
            Db = new ThorntonContext();
        }

        private IScheduler _scheduler;
        public string Name
        {
            get { return GetType().Name; }
        }

        public void Run()
        {
            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler();

            string taskGroup = "Thornton";

            var dictionary = new Dictionary<IJobDetail, Collection.ISet<ITrigger>>();
            //var dictionary = new Dictionary<IJobDetail, Quartz.Collection.ISet<itrigger>>();﻿

            var schedules = Db.SQLschedules.Where(x => x.enabled == true).ToList();
            foreach (var schedule in schedules)
            {
                string taskName = "Thornton Task " + System.Guid.NewGuid().ToString();
                IJobDetail scheduledJob = JobBuilder.Create<DownloadTask>()
                        //.WithIdentity(taskName, taskGroup)
                        .WithIdentity(new JobKey(schedule.SQLscheduleId.ToString()))
                        .UsingJobData("id", schedule.SQLscheduleId)
                        .Build();

                if (schedule.IsOnetime)//one time
                {
                    if (schedule.active_start_date >= DateTime.Now)
                    {
                        var start = new DateTime(schedule.active_start_date.Year, schedule.active_start_date.Month, schedule.active_start_date.Day, schedule.active_start_date.Hour, schedule.active_start_date.Minute, schedule.active_start_date.Second);
                        var startDateTime = new DateTimeOffset(start);

                        var triggerBuilder = TriggerBuilder.Create()
                                .WithIdentity(taskName, taskGroup)
                                .StartAt(startDateTime);
                        if (schedule.active_end_date.HasValue)
                        {
                            var end = new DateTime(schedule.active_end_date.Value.Year, schedule.active_end_date.Value.Month, schedule.active_end_date.Value.Day);
                            var endDateTime = new DateTimeOffset(end);
                            triggerBuilder = triggerBuilder.EndAt(endDateTime);
                        }

                        ITrigger scheduledTrigger = triggerBuilder.Build();

                        dictionary.Add(scheduledJob, new Collection.HashSet<ITrigger>() { scheduledTrigger });
                    }
                }
                else//recurring
                {
                    var start = new DateTime(schedule.active_start_date.Year, schedule.active_start_date.Month, schedule.active_start_date.Day, schedule.active_start_date.Hour, schedule.active_start_date.Minute, schedule.active_start_date.Second);
                    var startDateTime = new DateTimeOffset(start);

                    var triggerBuilder = TriggerBuilder.Create()
                            .WithIdentity(taskName, taskGroup)
                            .WithCronSchedule(schedule.CronExpression)
                            .StartAt(startDateTime);
                    if (schedule.active_end_date.HasValue)
                    {
                        var end = new DateTime(schedule.active_end_date.Value.Year, schedule.active_end_date.Value.Month, schedule.active_end_date.Value.Day);
                        var endDateTime = new DateTimeOffset(end);
                        triggerBuilder = triggerBuilder.EndAt(endDateTime);
                    }

                    ITrigger scheduledTrigger = triggerBuilder.Build();

                    dictionary.Add(scheduledJob, new Collection.HashSet<ITrigger>() { scheduledTrigger });
                }
            }

            if (schedules.Count > 0)
            {
                _scheduler.ScheduleJobs(dictionary, false);
                _scheduler.Start();
            }
        }

        public void Stop()
        {
            _scheduler.Shutdown();
        }
    }
}
