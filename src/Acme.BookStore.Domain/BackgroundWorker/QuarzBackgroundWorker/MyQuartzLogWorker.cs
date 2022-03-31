using Microsoft.Extensions.Logging;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.BackgroundWorkers.Quartz;

namespace Acme.BookStore.BackgroundWorker.QuarzBackgroundWorker
{
    public class MyQuartzLogWorker : QuartzBackgroundWorkerBase
    {
        public MyQuartzLogWorker()
        {
            //AutoRegister = false;
            JobDetail = JobBuilder.Create<MyQuartzLogWorker>().WithIdentity(nameof(MyQuartzLogWorker)).Build();
            //Trigger = TriggerBuilder.Create().WithIdentity(nameof(MyQuartzLogWorker)).StartNow().Build();
            //Trigger = TriggerBuilder.Create().WithIdentity(nameof(MyQuartzLogWorker)).StartAt(DateTimeOffset.Now.AddSeconds(30)).Build();
            Trigger = TriggerBuilder.Create()
                                    .WithSimpleSchedule(builder => builder
                                        .WithIntervalInSeconds(5)
                                        .RepeatForever())
                                    .Build();

        }

        public override Task Execute(IJobExecutionContext context)
        {
            Logger.LogInformation("Executed MyQuartzLogWorker..!");
            return Task.CompletedTask;
        }
    }
}
