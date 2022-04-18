using Application.Core.TenantResolver;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Core;
using MultiTenant.Core.Configurations;
using MultiTenant.Core.Database;
using MultiTenant.Core.Services;
using AppContext = Application.Core.Infrastructure.AppContext;

namespace Application.Core
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTenantServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Inject Tenant Manager
            services.AddTenantManager(configuration);
            services.AddHttpContextAccessor();
            services.AddScoped<ITenantResolverService, TenantResolverService>();

            services.AddDbContext<AppContext>(builder =>
                builder.UseDatabase(services));

            return services;
        }

        private static IServiceCollection AddTenantManager(this IServiceCollection services, IConfiguration configuration)
        {
            var tenantConfiguration = new TenantConfiguration();
            configuration.Bind(nameof(tenantConfiguration), tenantConfiguration);
            services.AddSingleton(tenantConfiguration);
            services.AddSingleton(typeof(ConnectionCacheService));
            services.AddMultiTenant(options =>
            {
                options.Provider = tenantConfiguration.Provider;
                options.ConnectionString = tenantConfiguration.ConnectionString;
            });
            return services;
        }

        private static DbContextOptionsBuilder? UseDatabase(this DbContextOptionsBuilder builder, IServiceCollection services)
        {
            var serviceProvider = services.BuildServiceProvider();
            var tenantManger = serviceProvider.GetRequiredService<ITenantService>();
            var tenantResolver = serviceProvider.GetRequiredService<ITenantResolverService>();
            var tenantIdentifier = tenantResolver.GetTenantIdentifier();
            //var tenantConnection = tenantManger.GetTenantDatabaseConnectivityConfiguration(tenantIdentifier);

            var tenantConnection = tenantResolver.GetTenantConnection(tenantIdentifier);
            var provider = tenantConnection.Provider;
            var connectionString = tenantConnection.ConnectionString;

            switch (provider)
            {
                case DatabaseProviders.MsSQL:
                    return builder.UseSqlServer(connectionString, builder =>
                    {
                        builder.MigrationsAssembly("Application.Core.Infrastructure.Migrations.SqlServer");
                    });
                case DatabaseProviders.MySQL:
                    break;
                case DatabaseProviders.POSTGRES:
                    return builder.UseNpgsql(connectionString, builder =>
                    {
                        builder.MigrationsAssembly("Application.Core.Infrastructure.Migrations.Npgsql");
                    });
                case DatabaseProviders.ORACLE:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(provider), provider, null);
            }

            return null;
        }

        public static IApplicationBuilder UpdateDatabase(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
            scope?.ServiceProvider.GetRequiredService<AppContext>().Database.Migrate();
            return app;
        }
    }
}