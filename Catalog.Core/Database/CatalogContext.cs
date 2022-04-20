using Microsoft.EntityFrameworkCore;

namespace Catalog.Core.Database
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {
        }

        public DbSet<Tenant> Tenants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenantEntityConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
