using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.entites;

namespace WebApplication2.confiqueration
{
    public class planconfigration : IEntityTypeConfiguration<plan>
    {
        public void Configure(EntityTypeBuilder<plan> builder)
        {
            builder.Property(x => x.createdate)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.price)
                   .HasPrecision(10, 2);

            builder.ToTable(t =>
                t.HasCheckConstraint("plandurationdays", "durationdays between 1 and 365"));
        }
    }
}
