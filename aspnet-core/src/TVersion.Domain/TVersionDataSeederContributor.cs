using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TVersion.Models;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace TVersion
{
    public class TVersionDataSeederContributor : IDataSeedContributor, ITransientDependency
    //public class TVersionDataSeederContributor : ITransientDependency
    {
        private readonly IRepository<Package> _packageRepository;

        public TVersionDataSeederContributor(IRepository<Package> packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _packageRepository.GetCountAsync() <= 0)
            {
                await _packageRepository.InsertAsync(
                    new Package
                    {
                        Name = "TPOS",
                        Code = "TPOSCode",
                        Image = "https://katec.vn/wp-content/uploads/2020/06/TPOS-logo.png"
                    },
                    autoSave: true
                );

                await _packageRepository.InsertAsync(
                    new Package
                    {
                        Name = "TDentist",
                        Code = "TDentistCode",
                        Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQRTr2z3WfWc_TDY36EqntbzjICQNcEfJGTCw&usqp=CAU"
                    },
                    autoSave: true
                );
            }
        }
    }
}
