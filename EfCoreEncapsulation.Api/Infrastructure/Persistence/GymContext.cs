using EfCoreEncapsulation.Api.Classes;
using EfCoreEncapsulation.Api.Enrollments;
using EfCoreEncapsulation.Api.Members;
using EfCoreEncapsulation.Api.Payments;
using Microsoft.EntityFrameworkCore;

namespace EfCoreEncapsulation.Api.Infrastructure.Persistence
{
    public class GymContext : DbContext
    {
        private readonly string _connectionString;
        private readonly bool _enableLog;
        private readonly bool _enableSensitiveLogging;
        public DbSet<Member> Members { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }

        public GymContext(string connectionString, bool enableLog, bool enableSensitiveLogging)
        {
            _connectionString = connectionString;
            _enableLog = enableLog;
            _enableSensitiveLogging = enableSensitiveLogging;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

            if(_enableLog)
                optionsBuilder.UseLoggerFactory(CreateLoggerFactory()); 

            // Conditionally enable sensitive data logging
            if (_enableSensitiveLogging)
               optionsBuilder.EnableSensitiveDataLogging();
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymContext).Assembly);

            // Seed Data
            modelBuilder.Entity<Member>().HasData(
                new Member { MemberId = 1, Name = "John Doe", MembershipStartDate = DateTime.Now },
                new Member { MemberId = 2, Name = "Jane Smith", MembershipStartDate = DateTime.Now },
                new Member { MemberId = 3, Name = "Paige Patchet", MembershipStartDate = DateTime.Now }
            );

            modelBuilder.Entity<Class>().HasData(
                new Class { Id = 1, ClassName = "Yoga", Instructor = "Alice Johnson" },
                new Class { Id = 2, ClassName = "Pilates", Instructor = "Bob Brown" },
                new Class { Id = 3, ClassName = "Cycling", Instructor = "Leslie Cabrera" }
            );

            modelBuilder.Entity<Enrollment>().HasData(
               new Enrollment { MemberId = 1, ClassId = 1 },
               new Enrollment { MemberId = 2, ClassId = 2 },
               new Enrollment { MemberId = 1, ClassId = 3 },
               new Enrollment { MemberId = 3, ClassId = 3 }
              );

            modelBuilder.Entity<Payment>().HasData(
            new Payment { PaymentId = 1, MemberId = 1, Amount = 50.00m, PaymentDate = new DateTime(2023, 1, 15) },
            new Payment { PaymentId = 2, MemberId = 1, Amount = 75.00m, PaymentDate = new DateTime(2023, 2, 15) },
            new Payment { PaymentId = 3, MemberId = 2, Amount = 60.00m, PaymentDate = new DateTime(2023, 2, 20) }
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
