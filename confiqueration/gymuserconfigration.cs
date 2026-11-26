using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.entites;

namespace WebApplication2.confiqueration
{
    
    public class gymuserconfigration<T> : IEntityTypeConfiguration<T> where T : gymuser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.name)
                   .HasColumnType("varchar")
                   .HasMaxLength(50);

            builder.Property(x => x.email)
                   .HasColumnType("varchar")
                   .HasMaxLength(100);

            builder.Property(x => x.phone)
                   .HasColumnType("varchar")
                   .HasMaxLength(11);

            builder.HasIndex(x => x.email).IsUnique();
            builder.HasIndex(x => x.phone).IsUnique();

            builder.ComplexProperty(x => x.addrese);

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("checkemail", "email like '_%@_%._%'");
                t.HasCheckConstraint("checkphone",
                    "len(phone) = 11 and (phone like '010%' or phone like '011%' or phone like '012%' or phone like '015%')");
            });
        }
    }
}
