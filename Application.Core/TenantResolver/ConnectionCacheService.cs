using MultiTenant.Core.Dtos;
using System.Collections.Concurrent;

namespace Application.Core.TenantResolver
{
    public class ConnectionCacheService
    {
        private static readonly ConcurrentDictionary<string, TenantInfo> _connections = new();
        public void AddConnection(string tenantIdentifier, TenantInfo connection)
        {
            _connections.TryAdd(tenantIdentifier, connection);
        }

        public TenantInfo? GetConnection(string tenantIdentifier)
        {
            var first = new KeyValuePair<string, TenantInfo>();
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
