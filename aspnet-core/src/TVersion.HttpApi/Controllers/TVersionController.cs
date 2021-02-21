using TVersion.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace TVersion.Controllers
{
    /* Inherit your controllers from this class.
     */
    public abstract class TVersionController : AbpController
    {
        protected TVersionController()
        {
            LocalizationResource = typeof(TVersionResource);
        }
    }
}