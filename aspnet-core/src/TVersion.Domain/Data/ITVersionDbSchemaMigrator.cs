using System.Threading.Tasks;

namespace TVersion.Data
{
    public interface ITVersionDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
