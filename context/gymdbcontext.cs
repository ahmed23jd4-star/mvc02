using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication2.entites;

namespace WebApplication2.context
{
    public class gymdbcontext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =.; Database=Gym; Trusted_Connection=true; TrustServerCertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        #region dbsets
        public DbSet<member> members { get; set; }
        public DbSet<trainer> trainers { get; set; }
        public DbSet<session> sessions { get; set; }
        public DbSet<plan> plans { get; set; }
        public DbSet<membership> memberships { get; set; }
        #endregion
    }
}
