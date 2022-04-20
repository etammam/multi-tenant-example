using Catalog.Core.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Application.Core.Infrastructure.Migrations.SqlServer;

public class SqlServerAppContext : AppContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_configuration is not {})
        {
            optionsBuilder.UseSqlServer(_configuration?.ConnectionString!, builder =>
            {
                builder.MigrationsAssembly("Application.Core.Infrastructure.Migrations.SqlServer");
            });
        }
        else
        {
            optionsBuilder.UseSqlServer("data source=192.168.1.60;user id=sa; password=Code@1903;initial catalog=tenant-default", builder =>
            {
                builder.MigrationsAssembly("Application.Core.Infrastructure.Migrations.SqlServer");
            });
        }
    }

    private readonly TenantInfo _configuration;
    private readonly IServiceProvider _serviceProvider;

    public SqlServerAppContext(DbContextOptions<AppContext> options, IServiceProvider serviceProvider) 
        : base(options, serviceProvider)
    {
    }
}