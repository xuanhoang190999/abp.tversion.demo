using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace TVersion.Data
{
    /* This is used if database provider does't define
     * ITVersionDbSchemaMigrator implementation.
     */
    public class NullTVersionDbSchemaMigrator : ITVersionDbSchemaMigrator, ITransientDependency
    {
        public Task MigrateAsync()
        {
            return Task.CompletedTask;
        }
    }
}