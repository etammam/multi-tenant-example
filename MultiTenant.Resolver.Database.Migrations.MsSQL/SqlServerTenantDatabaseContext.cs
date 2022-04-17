using Microsoft.EntityFrameworkCore;
using MultiTenant.Core.Database;

namespace MultiTenant.Resolver.Database.Migrations.SqlServer
{
    public class SqlServerTenantDatabaseContext : TenantContextDatabase
    {
        public SqlServerTenantDatabaseContext(DbContextOptions<TenantContextDatabase> options)
            : base(options)
        {
        }
    }
}