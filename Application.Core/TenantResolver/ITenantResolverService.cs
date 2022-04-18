using MultiTenant.Core.Dtos;

namespace Application.Core.TenantResolver
{
    public interface ITenantResolverService
    {
        string GetTenantIdentifier();
        TenantConnectionInfo GetTenantConnection(string tenantIdentifier);
    }
}
