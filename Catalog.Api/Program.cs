using Catalog.Api.Extensions;
using Catalog.Core;
using Catalog.Core.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var tenantConfiguration = new TenantConfiguration();
builder.Configuration.Bind(nameof(tenantConfiguration), tenantConfiguration);

builder.Services.AddMultiTenant(options =>
{
    options.Provider = tenantConfiguration.Provider;
    options.ConnectionString = tenantConfiguration.ConnectionString;
});
builder.Services.AddProviderContext(tenantConfiguration.Provider);
var app = builder.Build();

app.UseAutomaticMigrations(builder.Services, tenantConfiguration.Provider);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
