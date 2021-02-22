using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVersion.ViewModels
{
    public class ApplicationUserModel
    {
        public ApplicationUserModel()
        {
            
        }

        public string Avatar { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public Guid? Id { get; set; }

        public string UserName { get; set; }

        public string PasswordNew { get; set; }
    }
}
