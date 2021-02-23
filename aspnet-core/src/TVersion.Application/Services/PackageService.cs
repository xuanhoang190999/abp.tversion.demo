using TVersion.Models;
using TVersion.ViewModels;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TVersion.Services
{
    public class PackageService : CrudAppService<Package, PackageDto, long, PagedAndSortedResultRequestDto, CreateUpdatePackageDto>
    {
        private readonly IRepository<Package, long> _repository;

        public PackageService(IRepository<Package, long> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
