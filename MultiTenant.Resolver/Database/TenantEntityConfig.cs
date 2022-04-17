using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MultiTenant.Core.Database
{
    public class TenantEntityConfig : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired();

            builder.Property(t => t.Identifier)
                .IsRequired();

            builder.HasIndex(t => t.Identifier)
                .IsUnique();
        }
    }
}
