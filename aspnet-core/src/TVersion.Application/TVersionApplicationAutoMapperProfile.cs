using AutoMapper;
using TVersion.Models;
using TVersion.ViewModels;

namespace TVersion
{
    public class TVersionApplicationAutoMapperProfile : Profile
    {
        public TVersionApplicationAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            CreateMap<Package, PackageDto>().ReverseMap();
            CreateMap<ChangeLog, ChangeLogDto>().ReverseMap();
            CreateMap<CreateUpdateChangeLogDto, ChangeLog>();
            CreateMap<CreateUpdatePackageDto, Package>();
        }
    }
}
