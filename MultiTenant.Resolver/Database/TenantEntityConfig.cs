using Application.Shared.Constants;
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

            builder.HasData(new List<Tenant>()
            {
                new Tenant()
                {
                    Id = Guid.Parse("A2F50C97-8DF2-4343-8E13-CE3C3C8550CB"),
                    Identifier = TenantConstant.DefaultConstantIdentifier,
                    ConnectionString =
                        "data source=192.168.1.60;user id=sa; password=Code@1903;initial catalog=tenant-default",
                    Provider = DatabaseProviders.MsSQL,
                    Name = "Default"
                }
            });
        }
    }
}
