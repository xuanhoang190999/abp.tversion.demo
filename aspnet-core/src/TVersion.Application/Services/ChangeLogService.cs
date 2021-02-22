using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVersion.Models;
using TVersion.ViewModels;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace TVersion.Services
{
    public class ChangeLogService : Service<ChangeLog, long>
    {
        private readonly IRepository<ChangeLog, long> _changelogRepository;
        private readonly ICurrentUser _currentUser;

        public ChangeLogService(IRepository<ChangeLog, long> changelogRepository, ICurrentUser currentUser) : base (changelogRepository)
        {
            _changelogRepository = changelogRepository;
            _currentUser = currentUser;
        }

        public List<ChangeLog> GetByPackageId(long id)
        {
            var result = _changelogRepository.Where(x => x.PackageId == id).ToList();
            return result;
        }

        public void Insert(ChangeLog changelog)
        {
            changelog.CreatedById = _currentUser.Id;
            changelog.UpdatedById = _currentUser.Id;
            _changelogRepository.InsertAsync(changelog);
        }

        public void Update(ChangeLog changelog)
        {
            changelog.UpdatedById = _currentUser.Id;
            _changelogRepository.UpdateAsync(changelog);
        }

        public void Delete(long id)
        {
            _changelogRepository.DeleteAsync(id);
        }
    }
}
