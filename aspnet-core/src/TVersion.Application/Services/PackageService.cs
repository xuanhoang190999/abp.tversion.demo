using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVersion.Models;
using TVersion.ViewModels;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace TVersion.Services
{
    public class PackageService : Service<Package, long>
    {
        private readonly IRepository<Package, long> _packageRepository;
        private readonly ICurrentUser _currentUser;


        public PackageService(IRepository<Package, long> packageRepository, ICurrentUser currentUser) : base(packageRepository)
        {
            _packageRepository = packageRepository;
            _currentUser = currentUser;
        }

        public List<Package> GetAll()
        {
            var result = _packageRepository.ToList();
            return result;
        }

        public void Insert(Package package)
        {
            package.CreatedById = _currentUser.Id;
            package.UpdatedById = _currentUser.Id;
            _packageRepository.InsertAsync(package);
        }

        public void Update(Package package)
        {
            package.UpdatedById = _currentUser.Id;
            _packageRepository.UpdateAsync(package);
        }

        public void Delete(long id)
        {
            _packageRepository.DeleteAsync(id);
        }
    }
}
