using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVersion.Models;
using TVersion.ViewModels;
using Volo.Abp.Domain.Repositories;

namespace TVersion.Services
{
    public class PackageService : Service<Package, long>
    {
        private readonly IRepository<Package, long> _packageRepository;
        private readonly IMapper _mapper;

        public PackageService(IRepository<Package, long> packageRepository, IMapper mapper) : base(packageRepository)
        {
            _packageRepository = packageRepository;
            _mapper = mapper;
        }

        public List<Package> GetAll()
        {
            var result = _packageRepository.ToList();
            return result;
        }

        public void Insert(PackageViewModel package)
        {
            var packageMap = _mapper.Map<Package>(package);
            packageMap.CreatedById = this.UserLogged.Id;
            packageMap.UpdatedById = this.UserLogged.Id;
            _packageRepository.InsertAsync(packageMap);
        }

        public void Update(PackageViewModel package)
        {
            var packageMap = _mapper.Map<Package>(package);
            packageMap.CreatedById = this.UserLogged.Id;
            packageMap.UpdatedById = this.UserLogged.Id;
            _packageRepository.UpdateAsync(packageMap);
        }

        public void Delete(long id)
        {
            _packageRepository.DeleteAsync(id);
        }
    }
}
