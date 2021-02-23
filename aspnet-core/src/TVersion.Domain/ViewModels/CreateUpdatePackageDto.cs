using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVersion.ViewModels
{
    public class CreateUpdatePackageDto
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Image { get; set; }

        public DateTime CreationTime { get; set; } = DateTime.Now;

        public DateTime? LastModificationTime { get; set; }
    }
}
