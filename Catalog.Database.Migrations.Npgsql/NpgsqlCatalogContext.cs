using Microsoft.EntityFrameworkCore;
using Catalog.Core.Database;

namespace MultiTenant.Resolver.Database.Migrations.Npgsql
{
    public class NpgsqlCatalogContext : CatalogContext
    {
        public NpgsqlCatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {
        }
    }
}