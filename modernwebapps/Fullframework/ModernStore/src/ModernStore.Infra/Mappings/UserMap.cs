using ModernStore.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace ModernStore.Infra.Mappings
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("User");

            HasKey(x => x.Id);

            Property(x => x.Username)
                .HasColumnName("Username")
                .IsRequired()
                .HasMaxLength(20);

            Property(x => x.Password.Pass)
                .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength(32)
                .IsFixedLength();

            Property(x => x.Active)
                .HasColumnName("Active"); ;
        }
    }
}
