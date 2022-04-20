using Application.Shared;
using Catalog.Core.Database;

namespace Catalog.Core.Dtos
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
