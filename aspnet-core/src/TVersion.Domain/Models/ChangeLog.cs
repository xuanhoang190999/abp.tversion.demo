﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace TVersion.Models
{
    public class ChangeLog : MyEntity<long>
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
