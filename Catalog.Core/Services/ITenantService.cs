using Catalog.Core.Database;
using Catalog.Core.Dtos;

namespace Catalog.Core.Services
{
    public interface ITenantService
    {
        public Task<Tenant> GetTenantAsync(string identifier);
        public TenantInfo GetTenantDatabaseConnectivityConfiguration(string identifier);
        public Task<TenantInfo> GetTenantDatabaseConnectivityConfigurationAsync(
            string identifier);
        public Task<List<Tenant>> GetTenantListAsync();
        public Task<Tenant> AddTenantAsync(CreateNewTenantDto tenant);

    }
}
