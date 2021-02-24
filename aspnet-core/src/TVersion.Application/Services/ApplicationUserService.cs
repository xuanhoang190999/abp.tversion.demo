using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVersion.ViewModels;
using Volo.Abp.Application.Services;

namespace TVersion.Services
{
    public class ApplicationUserService : ApplicationService
    {
        public ApplicationUserService()
        {

        }

        public ApplicationUserDto GetUserLogged()
        {
            var userLogger = new ApplicationUserDto()
            {
                Name = CurrentUser.Name,
                PhoneNumber = CurrentUser.PhoneNumber,
                Email = CurrentUser.Email,
                Role = CurrentUser.Roles,
            };

            return userLogger;
        }
    }
}
