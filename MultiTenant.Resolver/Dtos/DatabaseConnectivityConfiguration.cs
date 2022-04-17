using MultiTenant.Core.Database;

namespace MultiTenant.Core.Dtos
{
    public class DatabaseConnectivityConfiguration
    {
        public DatabaseConnectivityConfiguration()
        {

        }

        public DatabaseConnectivityConfiguration(string connectionString, DatabaseProviders provider)
        {
            ConnectionString = connectionString;
            Provider = provider;
        }

        public string ConnectionString { get; set; }
        public DatabaseProviders Provider { get; set; }
    }
}
