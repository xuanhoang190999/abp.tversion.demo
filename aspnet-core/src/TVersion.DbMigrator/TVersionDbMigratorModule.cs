using TVersion.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace TVersion.DbMigrator
{
    [DependsOn(
        typeof(AbpAutofacModule),
        typeof(TVersionEntityFrameworkCoreDbMigrationsModule),
        typeof(TVersionApplicationContractsModule)
        )]
    public class TVersionDbMigratorModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
        }
    }
}
