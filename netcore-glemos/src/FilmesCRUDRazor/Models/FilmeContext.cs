using Microsoft.EntityFrameworkCore;

namespace FilmesCRUDRazor.Models {
    public class FilmeContext : DbContext {
        public FilmeContext (DbContextOptions<FilmeContext> options) : base (options) {
            //Configuração padrão para EFCore
        }
        public DbSet<Filme> Filme { get; set; }
        
    }
}