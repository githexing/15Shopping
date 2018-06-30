using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;
using System.Configuration;
/// <summary>
/// QuartzStart 的摘要说明
/// </summary>
public class QuartzStart
{
  
	public QuartzStart()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    public static void Start()
    {
        //int time = 8;// setting.GetSettingValue("WebSite", "Trigger");
        Start(2,1);  //24小时制 ，凌晨 2 点 1 分，执行
    }
    //static string sh = ConfigurationManager.AppSettings["StartHour"];
    //static string sm = ConfigurationManager.AppSettings["StartMin"];
    //private static  int startHour = Convert.ToInt32(sh);
    //private static int startMin = Convert.ToInt32(sm);


    private static void Start(int startHour, int startMinute)
    {
        // DateTime.UtcNow的区别UTC(协调世界时)时间
        //DateTime.Now本地时间（时区不同，本地时间不同）
        //两者差八个小时
        DateTime d23 = DateTime.UtcNow;
        //DateTime dss = DateTime.Now.AddDays(-1);
        DateTime dt = DateTime.Now;
        ISchedulerFactory sf = new StdSchedulerFactory();
        IScheduler sched = sf.GetScheduler();

        // define the job and tie it to our HelloJob class
        IJobDetail job = JobBuilder.Create<DoIJob>()
            .WithIdentity("job1", "group1")
            .Build();

        // Trigger the job to run now, and then repeat every 10 seconds
        ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartNow()
            .WithSimpleSchedule(x => x
                .WithIntervalInSeconds(3)   ////每隔3秒执行一次
                .RepeatForever())
            .Build();
        //每天指定时间执行一次
        //ITrigger trigger = TriggerBuilder.Create()
        //.WithDailyTimeIntervalSchedule(
        //             a => a.WithIntervalInHours(24)
        //                        .OnEveryDay()
        //                        .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(startHour, startMinute))
        //                       ).Build();
        // Tell quartz to schedule the job using our trigger
        sched.ScheduleJob(job, trigger);
        sched.Start();
    }
      

}