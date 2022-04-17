using MultiTenant.Core;
using MultiTenant.Core.Configurations;
using MultiTenant.Core.Database;
using MultiTenant.Resolver;
using MultiTenant.Resolver.Database;

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
    options.Provider = DatabaseProviders.POSTGRES;
    options.ConnectionString = tenantConfiguration.ConnectionString;
});
var app = builder.Build();

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
