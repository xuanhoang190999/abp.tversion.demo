using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVersion.Models;
using Volo.Abp.Domain.Repositories;

namespace TVersion.Services
{
    public class PackageService : Service<Package, long>
    {
        private readonly IRepository<Package, long> _backageRepository;

        public PackageService(IRepository<Package, long> backageRepository) : base(backageRepository)
        {
            _backageRepository = backageRepository;
        }

        public List<Package> GetAll()
        {
            var result = _backageRepository.ToList();
            return result;
        }
    }
}
