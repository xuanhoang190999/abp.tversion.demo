using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVersion.Entities;
using Volo.Abp.Domain.Entities;

namespace TVersion.Models
{
    //public abstract class MyEntityGuid<TKey> : Entity<TKey>, ICreatedEntity, IUpdatedEntity
    //{
    //    public MyEntityGuid()
    //    {
    //        DateCreated = DateTime.Now;
    //        DateUpdated = DateTime.Now;
    //    }

    //    //[Key]
    //    //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    //    //public long Id { get; set; }

    //    public DateTime? DateCreated { get; set; } = DateTime.Now;

    //    public DateTime? DateUpdated { get; set; }

    //    public Guid UpdatedById { get; set; }

    //    public Guid CreatedById { set; get; }
    //}
}
