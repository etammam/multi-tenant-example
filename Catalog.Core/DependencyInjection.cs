using Application.Shared;
using Catalog.Core.Configurations;
using Catalog.Core.Database;
using Catalog.Core.Services;
using Enigma.String;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddMultiTenant
            (this IServiceCollection services, Action<TenantConfiguration> configurations)
        {
            services.AddEnigmaEncryption(options => options.SymmetricKey = "b14ca5898a4e4133bbce2ea2315a1916");

            var tenantConfiguration = new TenantConfiguration();
            configurations.Invoke(tenantConfiguration);

            if (tenantConfiguration.Provider == DatabaseProviders.POSTGRES)
            {
                services.AddDbContext<CatalogContext>(options =>
                {
                    options.UseNpgsql(tenantConfiguration.ConnectionString, builder
                        =>
                    {
                        builder.MigrationsAssembly("Catalog.Database.Migrations.Npgsql");
                        builder.MigrationsHistoryTable("TenantMigrationsHistory");
                    });
                });
            }

            if (tenantConfiguration.Provider == DatabaseProviders.MsSQL)
            {
                services.AddDbContext<CatalogContext>(options =>
                {
                    options.UseSqlServer(tenantConfiguration.ConnectionString,
                        builder =>
                        {
                            builder.MigrationsAssembly("Catalog.Database.Migrations.SqlServer");
                            builder.MigrationsHistoryTable("TenantMigrationsHistory");
                        });
                });
            }

            services.AddScoped<ITenantService, TenantService>();
            services.AddScoped<ITenantConnectionStringBuilderService, TenantConnectionStringBuilderService>();

            return services;
        }
    }
}
