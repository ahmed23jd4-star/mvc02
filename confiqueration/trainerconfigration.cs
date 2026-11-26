using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.entites;

namespace WebApplication2.confiqueration
{
    public class trainerconfigration : gymuserconfigration<trainer>, IEntityTypeConfiguration<trainer>
    {
        public new void Configure(EntityTypeBuilder<trainer> builder)
        {
            builder.Property(x => x.hiredate)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.createdate)
                   .HasDefaultValueSql("GETDATE()");

            base.Configure(builder);
        }
    }
}
