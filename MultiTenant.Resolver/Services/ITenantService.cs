using MultiTenant.Core.Database;
using MultiTenant.Core.Dtos;

namespace MultiTenant.Core.Services
{
    public interface ITenantService
    {
        public Task<Tenant?> GetTenantAsync(string identifier);
        public DatabaseConnectivityConfiguration GetTenantDatabaseConnectivityConfiguration(string identifier);
        public Task<DatabaseConnectivityConfiguration> GetTenantDatabaseConnectivityConfigurationAsync(
            string identifier);
        public Task<List<Tenant>> GetTenantListAsync();
        public Task<Tenant> AddTenantAsync(CreateNewTenantDto tenant);

    }
}
