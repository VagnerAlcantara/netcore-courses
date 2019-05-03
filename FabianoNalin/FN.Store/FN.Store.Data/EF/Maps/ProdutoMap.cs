using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FN.Store.Data.EF.Maps
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //Table
            builder.ToTable(nameof(Produto));

            //PK
            builder.HasKey(x => x.Id);

            //Colunas
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.Property(x => x.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.Property(x => x.Preco)
                .HasColumnType("money");

            builder.Property(x => x.DataCriacao);

            builder.Property(x => x.DataAlteracao);

        }
    }
}
