using AppMvcBasica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("Varchar(200)");

            builder.Property(x => x.Descricao)
              .IsRequired()
              .HasColumnType("Varchar(1000)");

            builder.Property(x => x.Imagem)
              .IsRequired()
              .HasColumnType("Varchar(100)");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("decimal(5,2)");

            builder.ToTable("Produtos");
        }
    }
}
