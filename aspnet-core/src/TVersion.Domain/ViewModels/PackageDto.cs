using Volo.Abp.Application.Dtos;

namespace TVersion.ViewModels
{
    public class PackageDto : AuditedEntityDto<long>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Image { get; set; }
    }
}
