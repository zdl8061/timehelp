/*----------------------------------------------------------------
 *  Copyright (C) 2016 天下商机（txooo.com）版权所有
 * 
 *  文 件 名：Class1
 *  所属项目：
 *  创建用户：张德良
 *  创建时间：2017/4/14 星期五 下午 14:30:11
 *  
 *  功能描述：
 *          1、
 *          2、
 * 
 *  修改标识：
 *  修改描述：
 *  待 完 善：
 *          1、 
----------------------------------------------------------------*/
using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzDemo
{
    public class Demo : Registry
    {
        public Demo()
        {
            // Schedule an IJob to run at an interval
            // 立即执行每两秒一次的计划任务。（指定一个时间间隔运行，根据自己需求，可以是秒、分、时、天、月、年等。）
            Schedule<MyJob>().ToRunNow().AndEvery(2).Seconds();

            // Schedule an IJob to run once, delayed by a specific time interval
            // 延迟一个指定时间间隔执行一次计划任务。（当然，这个间隔依然可以是秒、分、时、天、月、年等。）
            Schedule<MyJob>().ToRunOnceIn(5).Seconds();

            // Schedule a simple job to run at a specific time
            // 在一个指定时间执行计划任务（最常用。这里是在每天的下午 1:10 分执行）
            Schedule(() => Console.WriteLine("It's 1:10 PM now.")).ToRunEvery(1).Days().At(13, 10);

            Schedule(() => {

                // 做你想做的事儿。
                Console.WriteLine("It's 1:10 PM now.");

            }).ToRunEvery(1).Days().At(13, 10);

            // Schedule a more complex action to run immediately and on an monthly interval
            // 立即执行一个在每月的星期一 3:00 的计划任务（可以看出来这个一个比较复杂点的时间，它意思是它也能做到！）
            Schedule<MyComplexJob>().ToRunNow().AndEvery(1).Months().OnTheFirst(DayOfWeek.Monday).At(3, 0);

            // Schedule multiple jobs to be run in a single schedule
            // 在同一个计划中执行两个（多个）任务
            Schedule<MyJob>().AndThen<MyOtherJob>().ToRunNow().AndEvery(5).Minutes();

        }


    }

    public class MyJob : IJob
    {

        void IJob.Execute()
        {
            Console.WriteLine("现在时间是：" + DateTime.Now);
        }
    }

    public class MyOtherJob : IJob
    {

        void IJob.Execute()
        {
            Console.WriteLine("这是另一个 Job ，现在时间是：" + DateTime.Now);
        }
    }

    public class MyComplexJob : IJob
    {

        void IJob.Execute()
        {
            Console.WriteLine("这是比较复杂的 Job ，现在时间是：" + DateTime.Now);
        }
    }
}
