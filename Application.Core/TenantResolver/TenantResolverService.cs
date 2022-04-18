using Application.Shared.Constants;
using Microsoft.AspNetCore.Http;
using MultiTenant.Core.Dtos;
using MultiTenant.Core.Services;

namespace Application.Core.TenantResolver
{
    public class TenantResolverService : ITenantResolverService
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly ITenantService _tenantService;
        private readonly ConnectionCacheService _connectionCacheService;
        public TenantResolverService(IHttpContextAccessor contextAccessor, ITenantService tenantService, ConnectionCacheService connectionCacheService)
        {
            _contextAccessor = contextAccessor;
            _tenantService = tenantService;
            _connectionCacheService = connectionCacheService;
        }

        public string GetTenantIdentifier()
        {
            var httpContext = _contextAccessor.HttpContext;
            if (httpContext != null)
            {
                httpContext.Request.Headers.TryGetValue("tenant", out var tenantId);
                return tenantId;
            }

            return TenantConstant.DefaultConstantIdentifier;
        }

        public TenantInfo GetTenantConnection(string tenantIdentifier)
        {
            var cachedConnection = _connectionCacheService.GetConnection(tenantIdentifier);
            if (cachedConnection != null)
                return cachedConnection;

            var connection = _tenantService.GetTenantDatabaseConnectivityConfiguration(tenantIdentifier);
            _connectionCacheService.AddConnection(tenantIdentifier, connection);
            return connection;
        }
    }
}
