using Microsoft.EntityFrameworkCore;
using MultiTenant.Core.Database;

namespace MultiTenant.Resolver.Database.Migrations.SqlServer
{
    public class SqlServerTenantContext : TenantContext
    {
        public SqlServerTenantContext(DbContextOptions<TenantContext> options)
            : base(options)
        {
        }
    }
}