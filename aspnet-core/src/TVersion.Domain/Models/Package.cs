using System.Collections.Generic;
using Volo.Abp.Domain.Entities.Auditing;

namespace TVersion.Models
{
    public class Package : AuditedAggregateRoot<long>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Image { get; set; }

        public virtual ICollection<ChangeLog> ChangeLogs { get; set; }

        public Package()
        {
            ChangeLogs = new HashSet<ChangeLog>();
        }
    }
}
