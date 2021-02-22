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

namespace TVersion.Services
{
    public class ChangeLogService : Service<ChangeLog, long>
    {
        private readonly IRepository<ChangeLog, long> _changelogRepository;
        private readonly IMapper _mapper;

        public ChangeLogService(IRepository<ChangeLog, long> changelogRepository, IMapper mapper) : base (changelogRepository)
        {
            _changelogRepository = changelogRepository;
            _mapper = mapper;
        }

        public List<ChangeLog> GetByPackageId(long id)
        {
            var result = _changelogRepository.Where(x => x.PackageId == id).ToList();
            return result;
        }

        public void Insert(ChangeLogViewModel changelog)
        {
            var changelogMap = _mapper.Map<ChangeLog>(changelog);
            changelogMap.CreatedById = this.UserLogged.Id;
            changelogMap.UpdatedById = this.UserLogged.Id;
            _changelogRepository.InsertAsync(changelogMap);
        }

        public void Update(ChangeLogViewModel changelog)
        {
            var changelogMap = _mapper.Map<ChangeLog>(changelog);
            changelogMap.UpdatedById = this.UserLogged.Id;
            _changelogRepository.UpdateAsync(changelogMap);
        }

        public void Delete(long id)
        {
            _changelogRepository.DeleteAsync(id);
        }
    }
}
