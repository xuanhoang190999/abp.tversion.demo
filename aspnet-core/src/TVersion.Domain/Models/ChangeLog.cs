﻿using Volo.Abp.Domain.Entities.Auditing;

namespace TVersion.Models
{
    public class ChangeLog : AuditedAggregateRoot<long>
    {
        public long PackageId { get; set; }

        public string Url { get; set; }

        public string Version { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Note { get; set; }

        public string CreatedByName { get; set; }

        public string CreateByAvatar { get; set; }

        public virtual Package Package { get; set; }
    }
}
