namespace Catalog.Core.Dtos
{
    public class CreateNewTenantDto
    {
        public string OrganizationName { get; set; }
        public DatabaseConnectionBuilderModel Resource { get; set; }
    }
}
