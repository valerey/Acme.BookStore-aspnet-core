
using Acme.BookStore.BackgroundWorker2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using System;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.BackgroundJobs.Quartz;
using Volo.Abp.BackgroundWorkers;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Quartz;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;

namespace Acme.BookStore;

[DependsOn(
    typeof(BookStoreDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(BookStoreApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpTenantManagementApplicationModule),
    typeof(AbpFeatureManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpBackgroundJobsModule),
    typeof(AbpBackgroundJobsQuartzModule),
    typeof(AbpBackgroundWorkersModule)) ]
public class BookStoreApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<BookStoreApplicationModule>();
        });

        Configure<AbpBackgroundJobOptions>(options =>
        {
            options.IsJobExecutionEnabled = true; 
        });

        //var configuration = context.Services.GetConfiguration();

        //PreConfigure<AbpQuartzOptions>(options =>
        //{
        //    options.Configurator = configure =>
        //    {
        //        configure.UsePersistentStore(storeOptions =>
        //        {
        //            storeOptions.UseProperties = true;
        //            //storeOptions.UseJsonSerializer();
        //            storeOptions.UseSqlServer(configuration.GetConnectionString("Server=localhost;Database=BookStore;Trusted_Connection=True"));
        //            storeOptions.UseClustering(c =>
        //            {
        //                c.CheckinMisfireThreshold = TimeSpan.FromSeconds(20);
        //                c.CheckinInterval = TimeSpan.FromSeconds(10);
        //            });
        //        });
        //    };
        //});

        Configure<AbpBackgroundJobQuartzOptions>(options =>
        {
            options.RetryCount = 1;
            options.RetryIntervalMillisecond = 1000;
        });

    }

    public override void OnApplicationInitialization(
       ApplicationInitializationContext context)
    {
        context.AddBackgroundWorkerAsync<InvalidAutorCheckWorker>();
    }
}
