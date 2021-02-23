using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TVersion.Models;
using TVersion.ViewModels;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace TVersion.Services
{
    public class ChangeLogService : CrudAppService<ChangeLog, ChangeLogDto, long, PagedAndSortedResultRequestDto, CreateUpdateChangeLogDto>
    {
        private readonly IRepository<ChangeLog, long> _repository;

        public ChangeLogService(IRepository<ChangeLog, long> repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<ChangeLog> AddInput(CreateUpdateChangeLogDto input)
        {
            var data = new ChangeLog()
            {
                PackageId = input.PackageId,
                Version = input.Version,
                Url = input.Version,
                Title = input.Version,
                Content = input.Content,
                Note = input.Note
            };

            var result = await _repository.InsertAsync(data);

            return result;
        }

        public async Task<List<ChangeLogDto>> GetByPackage(long id)
        {
            var queryable = await _repository.GetQueryableAsync();
            var result = queryable.Where(x => x.PackageId == id)
                .Select(x => new ChangeLogDto
                {
                    Id = x.Id,
                    PackageId = x.PackageId,
                    Version = x.Version,
                    Url = x.Url,
                    Title = x.Title,
                    Content = x.Content,
                    Note = x.Note,
                    CreatorId = x.CreatorId,
                    CreateByAvatar = x.CreateByAvatar,
                    CreatedByName = x.CreatedByName,
                    CreationTime = x.CreationTime,
                })
                .ToList();

            return result;
        }
    }
}
