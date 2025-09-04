using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(u => u.UserName).IsUnique();
                entity.Property(e => e.PasswordHash).IsRequired();
            });
        }
    }
}
