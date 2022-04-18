using Microsoft.EntityFrameworkCore;
using MultiTenant.Core.Database;

namespace MultiTenant.Resolver.Database.Migrations.Npgsql
{
    public class NpgsqlTenantContext : TenantContext
    {
        public NpgsqlTenantContext(DbContextOptions<TenantContext> options)
            : base(options)
        {
        }
    }
}