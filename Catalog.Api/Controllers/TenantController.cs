using Microsoft.AspNetCore.Mvc;
using Catalog.Core.Database;
using Catalog.Core.Dtos;
using Catalog.Core.Services;

namespace Catalog.Api.Controllers
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
