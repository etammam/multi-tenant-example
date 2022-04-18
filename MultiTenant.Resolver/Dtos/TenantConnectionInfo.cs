using MultiTenant.Core.Database;

namespace MultiTenant.Core.Dtos
{
    public class TenantConnectionInfo
    {
        public TenantConnectionInfo()
        {

        }

        public TenantConnectionInfo(string connectionString, DatabaseProviders provider)
        {
            ConnectionString = connectionString;
            Provider = provider;
        }

        public string ConnectionString { get; set; }
        public DatabaseProviders Provider { get; set; }
    }
}
