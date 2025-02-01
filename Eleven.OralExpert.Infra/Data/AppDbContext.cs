using Eleven.OralExpert.Core.Notifications;
using Eleven.OralExpert.Domain.Entities;
using Eleven.OralExpert.Infra.Map;
using Microsoft.EntityFrameworkCore;

namespace Eleven.OralExpert.Infra.Data;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Clinic> Clinics { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        
        modelBuilder.Ignore<DomainNotification>();
    }
}