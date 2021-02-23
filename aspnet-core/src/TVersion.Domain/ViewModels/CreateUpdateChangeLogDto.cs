using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TVersion.ViewModels
{
    public class CreateUpdateChangeLogDto
    {
        public long? Id { get; set; }

        public long PackageId { get; set; }

        public string Url { get; set; }

        [Required]
        public string Version { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Note { get; set; }

        public string CreatedByName { get; set; }

        public string CreateByAvatar { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;

        public DateTime? LastModificationTime { get; set; }
    }
}
