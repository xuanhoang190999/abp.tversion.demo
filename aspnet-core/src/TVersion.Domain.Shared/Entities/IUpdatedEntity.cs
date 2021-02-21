using System;
using System.Collections.Generic;
using System.Text;

namespace TVersion.Entities
{
    public interface IUpdatedEntity
    {
        DateTime? DateUpdated { get; set; }

        Guid UpdatedById { get; set; }
    }
}
