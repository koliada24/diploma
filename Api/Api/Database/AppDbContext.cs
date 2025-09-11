using Api.Models.Exams;
using Api.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<ExamTemplate> ExamTemplates { get; set; }

        public DbSet<QuestionTemplate> QuestionTemplates { get; set; }

        public DbSet<AnswerTemplate> AnswerTemplates { get; set; }

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

            modelBuilder.Entity<ExamTemplate>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired();
            });

            modelBuilder.Entity<QuestionTemplate>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.QuestionText).IsRequired();
            });

            modelBuilder.Entity<AnswerTemplate>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Text).IsRequired();
                entity.Property(e => e.IsCorrect).IsRequired();
            });
        }
    }
}
