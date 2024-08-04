using EfCoreEncapsulation.Api.Classes;
using EfCoreEncapsulation.Api.Enrollments;
using EfCoreEncapsulation.Api.Members;
using Microsoft.EntityFrameworkCore;

namespace EfCoreEncapsulation.Api.Infrastructure.Persistence
{
    public class GymContext : DbContext
    {
        public GymContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Enrollment>()
           .HasKey(e => new { e.MemberId, e.ClassId });
        }
    }
}
