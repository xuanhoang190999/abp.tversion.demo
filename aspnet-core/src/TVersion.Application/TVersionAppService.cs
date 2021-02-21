using System;
using System.Collections.Generic;
using System.Text;
using TVersion.Localization;
using Volo.Abp.Application.Services;

namespace TVersion
{
    /* Inherit your application services from this class.
     */
    public abstract class TVersionAppService : ApplicationService
    {
        protected TVersionAppService()
        {
            LocalizationResource = typeof(TVersionResource);
        }
    }
}
