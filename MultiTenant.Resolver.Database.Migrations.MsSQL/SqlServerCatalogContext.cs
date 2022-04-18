using Microsoft.EntityFrameworkCore;
using MultiTenant.Core.Database;

namespace MultiTenant.Resolver.Database.Migrations.SqlServer
{
    public class SqlServerCatalogContext : CatalogContext
    {
        public SqlServerCatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {
        }
    }
}