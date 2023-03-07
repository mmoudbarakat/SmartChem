using Microsoft.EntityFrameworkCore;

namespace SmartChem.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Element> Elements => Set<Element>();
    }
}
