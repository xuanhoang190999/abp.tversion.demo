using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace TVersion.EntityFrameworkCore
{
    [DependsOn(
        typeof(TVersionEntityFrameworkCoreModule)
        )]
    public class TVersionEntityFrameworkCoreDbMigrationsModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<TVersionMigrationsDbContext>();
        }
    }
}
