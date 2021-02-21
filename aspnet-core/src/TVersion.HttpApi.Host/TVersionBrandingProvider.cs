using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace TVersion
{
    [Dependency(ReplaceServices = true)]
    public class TVersionBrandingProvider : DefaultBrandingProvider
    {
        public override string AppName => "TVersion";
    }
}
