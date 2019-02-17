using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Mappings
{
    public class CustomerMap : EntityTypeConfiguration<Customer>
    {
        public CustomerMap()
        {
            ToTable("Customer");

            HasKey(x => x.Id);

            Property(x => x.BirthDate);

            Property(x => x.Document.Number)
                .HasColumnName("Cpf")
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength();

            Property(x => x.Email.Address)
                .HasColumnName("Email")
                .IsRequired().HasMaxLength(160);

            Property(x => x.Name.FirstName)
                .HasColumnName("FirstName")
                .IsRequired()
                .HasMaxLength(60);

            Property(x => x.Name.LastName)
                .HasColumnName("LastName")
                .IsRequired()
                .HasMaxLength(60);

            HasRequired(x => x.User);

        }
    }
}
