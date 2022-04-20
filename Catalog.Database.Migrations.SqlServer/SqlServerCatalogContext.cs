using Microsoft.EntityFrameworkCore;
using Catalog.Core.Database;

namespace Catalog.Database.Migrations.SqlServer
{
    public class SqlServerCatalogContext : CatalogContext
    {
        public SqlServerCatalogContext(DbContextOptions<CatalogContext> options)
            : base(options)
        {
        }
    }
}