using EfCoreEncapsulation.Api.Classes;
using EfCoreEncapsulation.Api.Enrollments;
using EfCoreEncapsulation.Api.Members;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EfCoreEncapsulation.Api.Infrastructure.Persistence
{
    public class GymContext : DbContext
    {
        private readonly string _connectionString;
        private readonly bool _enableLog;
        private readonly bool _enableSensitiveLogging;

        public GymContext(string connectionString, bool enableLog, bool enableSensitiveLogging)
        {
            _connectionString = connectionString;
            _enableLog = enableLog;
            _enableSensitiveLogging = enableSensitiveLogging;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            optionsBuilder.UseLoggerFactory(CreateLoggerFactory());
            // Conditionally enable sensitive data logging
            if (_enableSensitiveLogging)
            {
                optionsBuilder.EnableSensitiveDataLogging();
            }
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Enrollment>()
           .HasKey(e => new { e.MemberId, e.ClassId });


            // Seed Data
            modelBuilder.Entity<Member>().HasData(
                new Member { MemberId = 1, Name = "John Doe", MembershipStartDate = DateTime.Now },
                new Member { MemberId = 2, Name = "Jane Smith", MembershipStartDate = DateTime.Now }
            );

            modelBuilder.Entity<Class>().HasData(
                new Class { ClassId = 1, ClassName = "Yoga", Instructor = "Alice Johnson" },
                new Class { ClassId = 2, ClassName = "Pilates", Instructor = "Bob Brown" }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { MemberId = 1, ClassId = 1 },
                new Enrollment { MemberId = 2, ClassId = 2 }
            );

        }
        ILoggerFactory? CreateLoggerFactory()
        {
            return LoggerFactory.Create(builder => builder
                    .AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information)
                    .AddConsole());
        }
    }
}
