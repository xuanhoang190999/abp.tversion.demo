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
            CreateMap<Package, PackageViewModel>().ReverseMap();
            CreateMap<ChangeLog, ChangeLogViewModel>().ReverseMap();
        }
    }
}
