using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVersion.Models;

namespace TVersion.ViewModels
{
    public class PackageViewModel : MyEntity<long>
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public string Image { get; set; }
    }
}
