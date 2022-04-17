using Microsoft.EntityFrameworkCore;
using MultiTenant.Core.Database;

namespace MultiTenant.Resolver.Database.Migrations.Npgsql
{
    public class NpgsqlTenantDatabaseContext : TenantContextDatabase
    {
        public NpgsqlTenantDatabaseContext(DbContextOptions<TenantContextDatabase> options)
            : base(options)
        {
        }
    }
}