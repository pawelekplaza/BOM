using Microsoft.EntityFrameworkCore;

namespace Inftastructure.Entities
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.Migrate();            
        }

        public DbSet<Bom> Boms { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
    }
}
