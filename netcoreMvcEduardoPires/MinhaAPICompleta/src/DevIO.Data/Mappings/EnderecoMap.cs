using AppMvcBasica.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevIO.Data.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Logradouro)
                .IsRequired()
                .HasColumnType("Varchar(200)");

            builder.Property(x => x.Numero)
              .IsRequired()
              .HasColumnType("Varchar(50)");

            builder.Property(x => x.Cep)
              .IsRequired()
              .HasColumnType("Varchar(8)");

            builder.Property(x => x.Complemento)
             .HasColumnType("Varchar(250)");

            builder.Property(x => x.Bairro)
             .IsRequired()
             .HasColumnType("Varchar(100)");

            builder.Property(x => x.Cidade)
             .IsRequired()
             .HasColumnType("Varchar(100)");

            builder.Property(x => x.Estado)
            .IsRequired()
            .HasColumnType("Varchar(50)");

            builder.ToTable("Enderecos");
        }
    }
}
