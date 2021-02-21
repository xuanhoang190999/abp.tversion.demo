using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVersion.Models;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TVersion.Services
{
    public class ChangeLogService : Service<ChangeLog, long>
    {
        private readonly IRepository<ChangeLog, long> _changelogRepository;

        public ChangeLogService(IRepository<ChangeLog, long> changelogRepository) : base (changelogRepository)
        {
            _changelogRepository = changelogRepository;
        }
    }
}
