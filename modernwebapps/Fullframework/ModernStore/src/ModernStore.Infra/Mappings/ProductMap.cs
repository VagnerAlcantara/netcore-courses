using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            ToTable("Product");

            HasKey(x => x.Id);

            Property(x => x.Image)
                .HasColumnName("Image")
                .IsRequired()
                .HasMaxLength(1021);

            Property(x => x.Price)
                .HasColumnName("Price")
                .HasColumnType("money");

            Property(x => x.QuantityOnHand)
                .HasColumnName("QuantityOnHand"); ;

            Property(x => x.Title)
                .HasColumnName("Title")
                .IsRequired()
                .HasMaxLength(80);


        }
    }
}
