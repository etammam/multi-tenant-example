using Application.Core.Infrastructure.EntityConfigurations;
using Application.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiTenant.Core.Dtos;

namespace Application.Core.Infrastructure;

public class AppContext : DbContext
{
    private readonly IServiceProvider _serviceProvider;

    public AppContext(DbContextOptions<AppContext> options, IServiceProvider serviceProvider)
        : base(options)
    {
        _serviceProvider = serviceProvider;
        Database.EnsureCreated();
        Database.Migrate();
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductEntityConfiguration).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}