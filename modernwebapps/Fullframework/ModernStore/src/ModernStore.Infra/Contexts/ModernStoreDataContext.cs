using ModernStore.Domain.Entities;
using ModernStore.Infra.Mappings;
using ModernStore.Shared.Entities;
using System.Data.Entity;

namespace ModernStore.Infra.Contexts
{
    public class ModernStoreDataContext : DbContext
    {

        public ModernStoreDataContext()
        //: base("ModernStoreConnectionString")
        //: base(@"Server=(localdb)\v11.0;Database=MordernStore;Trusted_Connection=True;")
        : base(@"Data Source=DESKTOP-VNQBMNU; Initial Catalog = DevStore; Trusted_Connection=True;")

        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderItemMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new UserMap());

        }
    }
}
