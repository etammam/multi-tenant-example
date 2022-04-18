using MultiTenant.Core.Database;

namespace MultiTenant.Core.Dtos
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
