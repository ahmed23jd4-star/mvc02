using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.entites;

namespace WebApplication2.confiqueration
{
    public class memberconfigration : gymuserconfigration<member>, IEntityTypeConfiguration<member>
    {
        public new void Configure(EntityTypeBuilder<member> builder)
        {
        
            builder.Property(x => x.createdate)
                   .HasColumnName("joindate")
                   .HasDefaultValueSql("GETDATE()");

            base.Configure(builder);   
        }
    }
}
