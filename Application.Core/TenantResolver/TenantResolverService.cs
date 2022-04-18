using Application.Shared.Constants;
using Microsoft.AspNetCore.Http;

namespace Application.Core.TenantResolver
{
    public class TenantResolverService : ITenantResolverService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TenantResolverService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
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
    }
}
