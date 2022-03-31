using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Acme.BookStore.MultiTenancy;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Emailing;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.IdentityServer;
using Volo.Abp.Modularity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.PermissionManagement.IdentityServer;
using Volo.Abp.SettingManagement;
using Volo.Abp.TenantManagement;
using Volo.Abp;
using Volo.Abp.BackgroundWorkers;
using Acme.BookStore.BackgroundWorker;
using Volo.Abp.BackgroundWorkers.Quartz;
using Volo.Abp.BackgroundJobs.Quartz;

namespace Acme.BookStore;

[DependsOn(
    typeof(BookStoreDomainSharedModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(AbpBackgroundJobsDomainModule),
    typeof(AbpFeatureManagementDomainModule),
    typeof(AbpIdentityDomainModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpIdentityServerDomainModule),
    typeof(AbpPermissionManagementDomainIdentityServerModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(AbpTenantManagementDomainModule),
    typeof(AbpEmailingModule),
    typeof(AbpBackgroundJobsModule),
    typeof(AbpBackgroundJobsQuartzModule),
    typeof(AbpBackgroundWorkersModule),
    typeof(AbpBackgroundWorkersQuartzModule)
)]
public class BookStoreDomainModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = MultiTenancyConsts.IsEnabled;
        });



        Configure<AbpBackgroundJobOptions>(options =>
        {
            options.IsJobExecutionEnabled = true;
        });

        Configure<AbpBackgroundWorkerQuartzOptions>(options =>
        {
            options.IsAutoRegisterEnabled = true;
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

#if DEBUG
        context.Services.Replace(ServiceDescriptor.Singleton<IEmailSender, NullEmailSender>());
#endif
    }

    public override void OnApplicationInitialization(
      ApplicationInitializationContext context)
    {
        context.AddBackgroundWorkerAsync<InvalidAutorCheckWorker>();
    }
}
