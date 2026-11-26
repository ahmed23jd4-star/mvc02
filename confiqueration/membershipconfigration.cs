using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.entites;

namespace WebApplication2.confiqueration
{
    public class membershipconfigration : IEntityTypeConfiguration<membership>
    {
        public void Configure(EntityTypeBuilder<membership> builder)
        {
          
            builder.HasKey(x => x.id);

            builder.Property(x => x.createdate)
                   .HasDefaultValueSql("GETDATE()");

                   builder.HasOne(x => x.onemember)
                   .WithMany(x => x.manymembership)
                   .HasForeignKey(x => x.memberid);

            builder.HasOne(x => x.oneplan)
                   .WithMany(x => x.manymembership)
                   .HasForeignKey(x => x.planid);
        }
    }
}
