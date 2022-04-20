using Application.Shared;
using Catalog.Database.Migrations.SqlServer;
using Microsoft.EntityFrameworkCore;
using MultiTenant.Resolver.Database.Migrations.Npgsql;

namespace Catalog.Api.Extensions
{
    public static class AutoMigrateExtension
    {
        public static IServiceCollection AddProviderContext(this IServiceCollection services, DatabaseProviders provider)
        {
            if (provider == DatabaseProviders.POSTGRES)
            {
                services.AddDbContext<NpgsqlCatalogContext>();
                return services;
            }
            else if (provider == DatabaseProviders.MsSQL)
            {
                services.AddDbContext<SqlServerCatalogContext>();
                return services;
            }
            throw new ArgumentOutOfRangeException(nameof(provider), "provider is not supported");
        }
        public static IApplicationBuilder UseAutomaticMigrations(this IApplicationBuilder app, IServiceCollection services, DatabaseProviders provider)
        {
            if (provider == DatabaseProviders.POSTGRES)
            {
                using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();

                scope?.ServiceProvider.GetRequiredService<NpgsqlCatalogContext>().Database.Migrate();

                return app;
            }
            else if (provider == DatabaseProviders.MsSQL)
            {
                using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();

                scope?.ServiceProvider.GetRequiredService<SqlServerCatalogContext>().Database.Migrate();

                return app;
            }
            throw new ArgumentOutOfRangeException(nameof(provider), "provider is not supported");
        }
    }
}
