using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVersion.Entities;
using TVersion.Users;
using Volo.Abp.Domain.Entities;

namespace TVersion.Models
{
    public abstract class MyEntity<TKey> : Entity<TKey>, ICreatedEntity, IUpdatedEntity
    {
        public MyEntity()
        {
            DateCreated = DateTime.Now;
            DateUpdated = DateTime.Now;
        }
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public TKey Id { get; protected set; }

        public DateTime? DateCreated { get; set; } = DateTime.Now;

        public DateTime? DateUpdated { get; set; }

        public Guid UpdatedById { get; set; }

        public Guid CreatedById { set; get; }
    }
}
