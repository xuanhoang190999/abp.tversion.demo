using TVersion.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace TVersion
{
    [DependsOn(
        typeof(TVersionEntityFrameworkCoreTestModule)
        )]
    public class TVersionDomainTestModule : AbpModule
    {

    }
}