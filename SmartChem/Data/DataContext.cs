using Microsoft.EntityFrameworkCore;

namespace SmartChem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Element> Elements => Set<Element>();
    }
}
//dotnet ef dbcontext scaffold "Data Source=.;Initial Catalog=Elements;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -o Models -c DataContextModelSnapshot --context-dir Migrations --no-onconfiguring --force
