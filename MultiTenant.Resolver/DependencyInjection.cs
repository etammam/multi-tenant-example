using Enigma.String;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Core.Configurations;
using MultiTenant.Core.Database;
using MultiTenant.Core.Services;

namespace MultiTenant.Core
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
                services.AddDbContext<TenantContext>(options =>
                {
                    options.UseNpgsql(tenantConfiguration.ConnectionString, builder
                        =>
                    {
                        builder.MigrationsAssembly("MultiTenant.Resolver.Database.Migrations.Npgsql");
                        builder.MigrationsHistoryTable("TenantMigrationsHistory");
                    });
                });
            }

            if (tenantConfiguration.Provider == DatabaseProviders.MsSQL)
            {
                services.AddDbContext<TenantContext>(options =>
                {
                    options.UseSqlServer(tenantConfiguration.ConnectionString,
                        builder =>
                        {
                            builder.MigrationsAssembly("MultiTenant.Resolver.Database.Migrations.SqlServer");
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
