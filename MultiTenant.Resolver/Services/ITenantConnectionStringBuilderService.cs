using MultiTenant.Core.Dtos;

namespace MultiTenant.Core.Services
{
    public interface ITenantConnectionStringBuilderService
    {
        public string CreateConnectionString(DatabaseConnectionBuilderModel model);
        public string CreateConnectionString(DatabaseConnectionBuilderModel model, string identifier);
    }
}
