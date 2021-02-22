using System;
using System.Collections.Generic;
using System.Text;

namespace TVersion.Entities
{
    public interface ICreatedEntity
    {
        DateTime? DateCreated { get; set; }

        Guid? CreatedById { get; set; }
    }
}
