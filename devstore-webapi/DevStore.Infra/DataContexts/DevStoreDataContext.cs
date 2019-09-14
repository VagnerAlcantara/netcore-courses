using DevStore.Domain;
using DevStore.Infra.Mappings;
using System.Data.Entity;

namespace DevStore.Infra.DataContexts
{
    public class DevStoreDataContext : DbContext
    {
        public DevStoreDataContext()
            : base("DevStoreConnectionString")
        {
            Database.SetInitializer<DevStoreDataContext>(new DevStoreDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
    public class DevStoreDataContextInitializer : DropCreateDatabaseIfModelChanges<DevStoreDataContext>
    {
        protected override void Seed(DevStoreDataContext context)
        {
            context.Categories.Add(new Category { Id = 1, Title = "Informática" });
            context.Categories.Add(new Category { Id = 2, Title = "Games" });
            context.Categories.Add(new Category { Id = 3, Title = "Papelaria" });
            context.SaveChanges();

            context.Products.Add(new Product() { Id = 1, CategoryId = 1, IsActive = true, Title = "Produto 1" });
            context.Products.Add(new Product() { Id = 2, CategoryId = 1, IsActive = true, Title = "Produto 2" });
            context.Products.Add(new Product() { Id = 3, CategoryId = 1, IsActive = true, Title = "Produto 3" });

            context.Products.Add(new Product() { Id = 4, CategoryId = 2, IsActive = true, Title = "Produto 4" });
            context.Products.Add(new Product() { Id = 5, CategoryId = 2, IsActive = true, Title = "Produto 5" });
            context.Products.Add(new Product() { Id = 6, CategoryId = 2, IsActive = true, Title = "Produto 6" });

            context.Products.Add(new Product() { Id = 7, CategoryId = 3, IsActive = true, Title = "Produto 7" });
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
