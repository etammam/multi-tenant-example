using Microsoft.EntityFrameworkCore;
using MultiTenant.Core.Dtos;

namespace Application.Core.Infrastructure.Migrations.Npgsql;

public class NpgsqlAppContext : AppContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (_configuration is not {})
        {
            optionsBuilder.UseSqlServer(_configuration.ConnectionString, builder =>
            {
                builder.MigrationsAssembly("Application.Core.Infrastructure.Migrations.Npgsql");
            });
        }
        else
        {
            optionsBuilder.UseNpgsql("User Id=postgres;Password=MadCode@01100072682;Host=192.168.1.60;Database=tenant-default;", builder =>
            {
                builder.MigrationsAssembly("Application.Core.Infrastructure.Migrations.Npgsql");
            });
        }
    }

    private readonly DatabaseConnectivityConfiguration _configuration;
    private readonly IServiceProvider _serviceProvider;

    public NpgsqlAppContext(DbContextOptions<AppContext> options,
        IServiceProvider serviceProvider) : base(options,
        serviceProvider)
    {
    }
}