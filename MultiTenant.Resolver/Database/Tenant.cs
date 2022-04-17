namespace MultiTenant.Core.Database
{
    public class Tenant
    {
        public Guid Id { get; set; }
        public string Identifier { get; set; }
        public string Name { get; set; }
        public string? ConnectionString { get; set; }
        public DatabaseProviders Provider { get; set; }
    }
}