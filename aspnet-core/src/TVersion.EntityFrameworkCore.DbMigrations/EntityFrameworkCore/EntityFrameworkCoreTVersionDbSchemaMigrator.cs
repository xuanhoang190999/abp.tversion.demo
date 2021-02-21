using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TVersion.Data;
using Volo.Abp.DependencyInjection;

namespace TVersion.EntityFrameworkCore
{
    public class EntityFrameworkCoreTVersionDbSchemaMigrator
        : ITVersionDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public EntityFrameworkCoreTVersionDbSchemaMigrator(
            IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task MigrateAsync()
        {
            /* We intentionally resolving the TVersionMigrationsDbContext
             * from IServiceProvider (instead of directly injecting it)
             * to properly get the connection string of the current tenant in the
             * current scope.
             */

            await _serviceProvider
                .GetRequiredService<TVersionMigrationsDbContext>()
                .Database
                .MigrateAsync();
        }
    }
}