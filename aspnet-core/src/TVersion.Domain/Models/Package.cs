using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace TVersion.Models
{
    public class Package : MyEntity<long>
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
