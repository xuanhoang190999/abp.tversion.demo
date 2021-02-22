using System;
using System.Linq;
using TVersion.Users;
using TVersion.ViewModels;
using Volo.Abp.Domain.Repositories;

namespace TVersion.Services
{
    public class ApplicationUserService
    {
        private readonly IRepository<AppUser, Guid> _userRepository;

        private string _host;

        protected string Host
        {
            get
            {
                return _host ?? System.Net.Dns.GetHostName();
            }
            set
            {
                _host = value;
            }
        }

        public ApplicationUserService(IRepository<AppUser, Guid> userRepository)
        {
            _host = System.Net.Dns.GetHostName();
            _userRepository = userRepository;
        }

        public ApplicationUserModel GetById(Guid? id, bool fromCache = false)
        {


            var result = _userRepository.Where(x => x.Id == id ).Select(x => new ApplicationUserModel
            {
                Id = x.Id,
                Name = x.Name,
                UserName = x.UserName,
                Email = x.Email,
                Avatar = x.Avatar,
            })
            .FirstOrDefault();

            return result;
        }
    }
}
