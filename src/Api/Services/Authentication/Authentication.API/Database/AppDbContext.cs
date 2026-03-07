using Authentication.API.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Authentication.API.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserPrivateProfile> UserPrivateProfiles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserPrivateProfile>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Login).IsUnique();
                entity.Property(e => e.PasswordHash).IsRequired();
            });
        }
    }
}
