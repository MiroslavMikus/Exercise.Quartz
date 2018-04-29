using Exercise.Quartz.Jobs;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercise.Quartz
{
    class Program
    {
        static void Main(string[] args)
        {
            ISchedulerFactory factory = new StdSchedulerFactory();

            IScheduler scheduler = factory.GetScheduler().Result;

            IJobDetail job = JobBuilder.Create<ConsoleJob>()
                                .WithIdentity("jobName", "JobGroup")
                                .UsingJobData("Name","JobDataName")
                                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                                .WithSimpleSchedule(a => a.WithIntervalInSeconds(2).WithRepeatCount(5))
                                .StartNow()
                                .Build();

            scheduler.ScheduleJob(job, trigger);

            scheduler.Start();

            Thread.Sleep(TimeSpan.FromMinutes(1));

            scheduler.Shutdown();

            Console.WriteLine("Done");

            Console.ReadLine();
        }
    }
}
