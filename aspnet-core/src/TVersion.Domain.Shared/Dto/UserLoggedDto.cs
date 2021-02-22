using System;
using System.Collections.Generic;
using System.Text;

namespace TVersion.Dto
{
    public class UserLoggedDto
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Avatar { get; set; }
    }
}
