using MultiTenant.Core.Database;

namespace MultiTenant.Core.Dtos
{
    public class DatabaseConnectionBuilderModel
    {
        public DatabaseDecision Decision { get; set; }
        public DatabaseProviders Provider { get; set; }

        public string Host { get; set; }
        public int Port { get; set; }

        public string DatabaseName { get; set; }
        public bool GenerateDatabaseName { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
