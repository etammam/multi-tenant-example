using Microsoft.EntityFrameworkCore;

namespace MultiTenant.Core.Database
{
    public class TenantContext : DbContext
    {
        public TenantContext(DbContextOptions<TenantContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            Database.Migrate();
        }

        public DbSet<Tenant> Tenants { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenantEntityConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
