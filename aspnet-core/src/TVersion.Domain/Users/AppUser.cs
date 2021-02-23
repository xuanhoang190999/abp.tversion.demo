using System;
using System.Collections.Generic;
using TVersion.Entities;
using TVersion.Models;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.Users;

namespace TVersion.Users
{
    public class AppUser : FullAuditedAggregateRoot<Guid>, IUser
    {
        public Guid? TenantId { get; set; }

        public string UserName { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public string Avatar { get; set; }

        private AppUser()
        {
            
        }
    }
}
