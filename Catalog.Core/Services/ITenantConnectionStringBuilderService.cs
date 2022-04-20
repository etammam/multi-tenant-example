using Catalog.Core.Dtos;

namespace Catalog.Core.Services
{
    public interface ITenantConnectionStringBuilderService
    {
        public string CreateConnectionString(DatabaseConnectionBuilderModel model);
        public string CreateConnectionString(DatabaseConnectionBuilderModel model, string identifier);
    }
}
