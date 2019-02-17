using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Mappings
{
    public class OrderItemMap : EntityTypeConfiguration<OrderItem>
    {
        public OrderItemMap()
        {
            ToTable("OrderItem");

            HasKey(x => x.Id);

            Property(x => x.Price)
                .HasColumnName("Price")
                .HasColumnType("money");

            Property(x => x.Quantity)
                .HasColumnName("Quantity");

            HasRequired(x => x.Product);


        }
    }
}
