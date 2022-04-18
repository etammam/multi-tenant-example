using MultiTenant.Core.Database;
using MultiTenant.Core.Dtos;

namespace MultiTenant.Core.Services
{
    public interface ITenantService
    {
        public Task<Tenant?> GetTenantAsync(string identifier);
        public TenantConnectionInfo GetTenantDatabaseConnectivityConfiguration(string identifier);
        public Task<TenantConnectionInfo> GetTenantDatabaseConnectivityConfigurationAsync(
            string identifier);
        public Task<List<Tenant>> GetTenantListAsync();
        public Task<Tenant> AddTenantAsync(CreateNewTenantDto tenant);

    }
}
