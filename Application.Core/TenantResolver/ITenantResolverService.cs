using MultiTenant.Core.Dtos;

namespace Application.Core.TenantResolver
{
    public interface ITenantResolverService
    {
        string GetTenantIdentifier();
        TenantInfo GetTenantConnection(string tenantIdentifier);
    }
}
