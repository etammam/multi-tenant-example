using MultiTenant.Core.Dtos;
using System.Collections.Concurrent;

namespace Application.Core.TenantResolver
{
    public class ConnectionCacheService
    {
        private static readonly ConcurrentDictionary<string, TenantConnectionInfo> _connections = new();
        public void AddConnection(string tenantIdentifier, TenantConnectionInfo connection)
        {
            _connections.TryAdd(tenantIdentifier, connection);
        }

        public TenantConnectionInfo? GetConnection(string tenantIdentifier)
        {
            var first = new KeyValuePair<string, TenantConnectionInfo>();
            foreach (var d in _connections)
            {
                if (d.Key != tenantIdentifier) continue;
                first = d;
                break;
            }

            var connection = first.Value; ;
            return connection;
        }
    }
}
