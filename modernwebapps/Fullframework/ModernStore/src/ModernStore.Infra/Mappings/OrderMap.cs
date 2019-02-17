using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Mappings
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            ToTable("Order");

            HasKey(x => x.Id);

            Property(x => x.CreateDate)
                .HasColumnName("CreateDate");

            Property(x => x.DeliveryFee)
                .HasColumnName("DeliverFee")
                .HasColumnType("money");

            Property(x => x.Discount)
                .HasColumnName("Discount")
                .HasColumnType("money");

            Property(x => x.Number)
                .HasColumnName("Number")
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(x => x.Status)
                .HasColumnName("Status"); ;

            HasMany(x => x.Items);

            HasRequired(x => x.Customer);

        }
    }
}
