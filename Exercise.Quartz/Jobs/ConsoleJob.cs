using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise.Quartz.Jobs
{
    class ConsoleJob : IJob
    {
        public string Name { get; }

        public ConsoleJob(string name)
        {
            Name = name;
        }

        public Task Execute(IJobExecutionContext context)
        {
            Console.WriteLine($"Name: {Name} - Hi, Im console Job");

            return Task.CompletedTask;
        }
    }
}
