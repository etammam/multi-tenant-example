using Microsoft.AspNetCore.Mvc;
using MultiTenant.Core.Database;
using MultiTenant.Core.Dtos;
using MultiTenant.Core.Services;

namespace MultiTenant.Api.Controllers
{
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet("api/tenants")]
        public async Task<ActionResult<List<Tenant>>> Get()
        {
            return Ok(await _tenantService.GetTenantListAsync());
        }

        [HttpPost("api/tenant")]
        public async Task<ActionResult<Tenant>> Post([FromBody] CreateNewTenantDto tenant)
        {
            return Ok(await _tenantService.AddTenantAsync(tenant));
        }
    }
}
