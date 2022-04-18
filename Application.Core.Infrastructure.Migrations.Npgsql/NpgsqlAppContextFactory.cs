using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiTenant.Core.Dtos;

namespace Application.Core.Infrastructure.Migrations.Npgsql;

public class NpgsqlAppContextFactory: IDesignTimeDbContextFactory<NpgsqlAppContext>
{
    private readonly IServiceProvider _serviceProvider;

    public NpgsqlAppContextFactory()
    {
        
    }
    public NpgsqlAppContextFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public NpgsqlAppContext CreateDbContext(string[] args)
    {
        var databaseConnection = new TenantConnectionInfo();
        var builder = new DbContextOptionsBuilder<AppContext>();
        builder.UseNpgsql("User Id=postgres;Password=MadCode@01100072682;Host=192.168.1.60;Database=tenant-default;", builder =>
        {
            builder.MigrationsAssembly("Application.Core.Infrastructure.Migrations.Npgsql");
        });
        return new NpgsqlAppContext(builder.Options,_serviceProvider);
    }
}