using Microsoft.EntityFrameworkCore;
using MultiTenant.Core.Database;
using MultiTenant.Core.Dtos;

namespace MultiTenant.Core.Services
{
    public class TenantService : ITenantService
    {
        private readonly TenantContext _database;
        private readonly ITenantConnectionStringBuilderService _connectionStringBuilderService;

        public TenantService(TenantContext database,
            ITenantConnectionStringBuilderService connectionStringBuilderService)
        {
            _database = database;
            _connectionStringBuilderService = connectionStringBuilderService;
        }

        public async Task<Tenant> GetTenantAsync(string identifier)
        {
            return await _database.Tenants.FirstOrDefaultAsync(d => d.Identifier == identifier);
        }

        public DatabaseConnectivityConfiguration GetTenantDatabaseConnectivityConfiguration(string identifier)
        {
            var tenant = _database.Tenants.FirstOrDefault(d => d.Identifier == identifier);
            return new DatabaseConnectivityConfiguration(tenant.ConnectionString, tenant.Provider);
        }

        public async Task<DatabaseConnectivityConfiguration> GetTenantDatabaseConnectivityConfigurationAsync(
            string identifier)
        {
            var tenant = await _database.Tenants.FirstOrDefaultAsync(d => d.Identifier == identifier);
            return new DatabaseConnectivityConfiguration(tenant.ConnectionString, tenant.Provider);
        }

        public Task<List<Tenant>> GetTenantListAsync()
        {
            return _database.Tenants.ToListAsync();
        }

        public async Task<Tenant> AddTenantAsync(CreateNewTenantDto tenant)
        {
            var identifier = GenerateIdentifier();
            var connectionString = _connectionStringBuilderService.CreateConnectionString(tenant.Resource, identifier);
            var entry = await _database.Tenants.AddAsync(new Tenant()
            {
                ConnectionString = connectionString,
                Id = Guid.NewGuid(),
                Identifier = identifier,
                Name = tenant.OrganizationName,
                Provider = tenant.Resource.Provider
            });
            await _database.SaveChangesAsync();
            return entry.Entity;
        }

        private string GenerateIdentifier()
        {
            return $"{TenantHelper.GenerateHashedCode()}";
        }
    }
}