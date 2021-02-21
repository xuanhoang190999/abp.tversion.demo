using Volo.Abp.Modularity;

namespace TVersion
{
    [DependsOn(
        typeof(TVersionApplicationModule),
        typeof(TVersionDomainTestModule)
        )]
    public class TVersionApplicationTestModule : AbpModule
    {

    }
}