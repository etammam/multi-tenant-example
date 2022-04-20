using Application.Shared;
using Catalog.Core.Database;

namespace Catalog.Core.Configurations
{
    public class TenantConfiguration
    {
        public DatabaseProviders Provider { get; set; }
        public string ConnectionString { get; set; }
        public SharedResources SharedResources { get; set; }
        public IsolatedResources IsolatedResources { get; set; }
    }

    public class SharedResources
    {
        public DatabaseProviders Provider { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string DatabaseName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class IsolatedResources
    {
        public IsolatedResources()
        {

        }

        public IsolatedResources(DatabaseProviders provider, string host, int port, string username, string password)
        {
            Provider = provider;
            Host = host;
            Port = port;
            Username = username;
            Password = password;
        }
        public DatabaseProviders Provider { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
