using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication2.entites;

namespace WebApplication2.confiqueration
{
    public class sessionconfigration : IEntityTypeConfiguration<session>
    {
        public void Configure(EntityTypeBuilder<session> builder)
        {
            builder.Property(x => x.createdate)
                   .HasDefaultValueSql("GETDATE()");

            builder.ToTable(t =>
            {
                t.HasCheckConstraint("sessioncapacity", "capacity between 1 and 25");
                t.HasCheckConstraint("sessionenddate", "enddate > startdate");
            });

            
            builder.HasOne(x => x.onetrainer)
                   .WithMany(x => x.manysession)
                   .HasForeignKey(x => x.trainerid)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
