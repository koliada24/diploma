using Microsoft.EntityFrameworkCore;
using UserProfiles.API.Database.Entities;

namespace UserProfiles.API.Database;

public class AppDbContext : DbContext
{
    public DbSet<UserPublicProfile> UserPublicProfiles { get; set; }
    public DbSet<StudentsGroup> StudentsGroups { get; set; }
    
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentsGroup>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.Description);
            entity.Property(e => e.CreatedBy).IsRequired();
        });

        modelBuilder.Entity<UserPublicProfile>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.FirstName).IsRequired();
            entity.Property(e => e.LastName).IsRequired();
        });
    }
}