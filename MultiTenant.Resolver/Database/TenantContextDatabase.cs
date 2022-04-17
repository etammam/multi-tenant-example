using Microsoft.EntityFrameworkCore;

namespace MultiTenant.Core.Database
{
    public class TenantContextDatabase : DbContext
    {
        public TenantContextDatabase(DbContextOptions<TenantContextDatabase> options)
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
