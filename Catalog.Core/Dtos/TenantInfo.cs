using Application.Shared;
using Catalog.Core.Database;

namespace Catalog.Core.Dtos
{
    public class TenantInfo
    {
        public TenantInfo()
        {

        }

        public TenantInfo(string connectionString, DatabaseProviders provider)
        {
            ConnectionString = connectionString;
            Provider = provider;
        }

        public string ConnectionString { get; set; }
        public DatabaseProviders Provider { get; set; }
    }
}
