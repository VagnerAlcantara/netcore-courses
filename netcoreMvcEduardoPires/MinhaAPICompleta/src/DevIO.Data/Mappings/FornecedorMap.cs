using AppMvcBasica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("Varchar(200)");

            builder.Property(x => x.Documento)
              .IsRequired()
              .HasColumnType("Varchar(14)");

            //Relacionamento 1 : 1 Fornecedor : Endereco
            builder.HasOne(x => x.Endereco)
                .WithOne(x => x.Fornecedor);

            //Relacionamento 1 : N Fornecedor : Produtos
            builder.HasMany(x => x.Produtos)
                .WithOne(x => x.Fornecedor)
                .HasForeignKey(x => x.FornecedorId);

            builder.ToTable("Fornecedores");
        }
    }
}
