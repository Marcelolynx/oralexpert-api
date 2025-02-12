using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Eleven.OralExpert.Core.Notifications;
using Eleven.OralExpert.Domain.Entities;

namespace Eleven.OralExpert.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Specialty> Specialtys { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
 
            modelBuilder.Ignore<DomainNotification>();
        }
    }
}