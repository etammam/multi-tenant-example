﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MultiTenant.Core.Database;

namespace MultiTenant.Resolver.Database.Migrations.Npgsql;

public class NpgsqlTenantDatabaseContextFactory : IDesignTimeDbContextFactory<NpgsqlTenantDatabaseContext>
{
    public NpgsqlTenantDatabaseContext CreateDbContext(string[] args)
    {
        
        var builder = new DbContextOptionsBuilder<TenantContextDatabase>();
        builder.UseNpgsql("User Id=postgres;Password=MadCode@01100072682;Host=192.168.1.60;Database=multi-tenant;", builder =>
        {
            builder.MigrationsAssembly("MultiTenant.Resolver.Database.Migrations.Npgsql");
        });
        return new NpgsqlTenantDatabaseContext(builder.Options);
    }
}