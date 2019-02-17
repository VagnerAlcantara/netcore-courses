using Microsoft.EntityFrameworkCore;

namespace WebApplication
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) 
            : base(dbContextOptions)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}