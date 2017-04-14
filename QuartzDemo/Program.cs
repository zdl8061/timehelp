using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentScheduler;

namespace QuartzDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region quartz demo

            //Console.WriteLine(DateTime.Now.ToString("r"));
            ////1.首先创建一个作业调度池
            //ISchedulerFactory schedf = new StdSchedulerFactory();

            //IScheduler sched = schedf.GetScheduler();
            ////2.创建出来一个具体的作业
            //IJobDetail job = JobBuilder.Create<JobDemo>().Build();
            ////3.创建并配置一个触发器
            //ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create().WithSimpleSchedule(x => x.WithIntervalInSeconds(3).WithRepeatCount(int.MaxValue)).Build();
            ////4.加入作业调度池中
            //sched.ScheduleJob(job, trigger);
            ////5.开始运行
            //sched.Start();

            #endregion

            #region fluentscheduler 简洁首选

            JobManager.AddJob(() =>
            {
                //Do something...
                Console.WriteLine("Timer task,current time:{0}", DateTime.Now);
            }, t =>
            {
                //每5秒钟执行一次
                t.ToRunNow().AndEvery(5).Seconds();
                ////带有任务名称的任务定时器
                //t.WithName("TaskName").ToRunOnceAt(DateTime.Now.AddSeconds(5));
            });

            #endregion


            Console.ReadKey();
        }
    }
}
