using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Core.Dtos;

namespace Application.Core.Infrastructure.Migrations.SqlServer;

public class SqlServerAppContextFactory : IDesignTimeDbContextFactory<SqlServerAppContext>
{
    public SqlServerAppContextFactory()
    {
        
    }
    private readonly IServiceProvider _serviceProvider;

    public SqlServerAppContextFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public SqlServerAppContext CreateDbContext(string[] args)
    {
        var databaseConnection = new TenantConnectionInfo();
        var builder = new DbContextOptionsBuilder<AppContext>();
        builder.UseSqlServer("data source=192.168.1.60;user id=sa; password=Code@1903;initial catalog=tenant-default", builder =>
        {
            builder.MigrationsAssembly("Application.Core.Infrastructure.Migrations.SqlServer");
        });
        return new SqlServerAppContext(builder.Options,_serviceProvider);
    }
}