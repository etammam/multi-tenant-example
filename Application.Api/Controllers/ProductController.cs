using System.Threading.Tasks;
using Application.Core.Infrastructure;
using Application.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Application.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppContext _appContext;

    public ProductController(AppContext appContext)
    {
        _appContext = appContext;
    }

    [HttpGet(Name = "/")]
    public async Task<ActionResult<Product>> Get()
    {
        var result = await _appContext.Products.ToListAsync();
        return Ok(result);
    }
}