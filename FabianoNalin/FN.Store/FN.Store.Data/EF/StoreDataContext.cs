using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FN.Store.Data.EF
{
    public class StoreDataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public StoreDataContext(IConfiguration configuration )
        {
            _configuration = configuration;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("StoreConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new Maps.ProdutoMap());
            modelBuilder.ApplyConfiguration(new Maps.CategoriaMap());
            modelBuilder.Seed();
        }
    }
}
