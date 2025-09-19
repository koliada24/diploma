using Api.Models.Exams;
using Api.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace Api.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<ExamTemplate> ExamTemplates { get; set; }

        public DbSet<QuestionTemplate> QuestionTemplates { get; set; }

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
                entity.HasDiscriminator<QuestionType>("QuestionType")
                    .HasValue<ShortAnswerQuestionTemplate>(QuestionType.ShortAnswer)
                    .HasValue<LongAnswerQuestionTemplate>(QuestionType.LongAnswer)
                    .HasValue<SingleChoiceQuestionTemplate>(QuestionType.SingleChoice)
                    .HasValue<MultipleChoiceQuestionTemplate>(QuestionType.MultipleChoice);
                entity.Property(e => e.QuestionText).IsRequired();
            });

            var answerOptionsConverter = new ValueConverter<List<AnswerOption>, string>(
                v => JsonSerializer.Serialize(v, (JsonSerializerOptions?)null),
                v => string.IsNullOrEmpty(v)
                    ? new List<AnswerOption>()
                    : JsonSerializer.Deserialize<List<AnswerOption>>(v, (JsonSerializerOptions?)null)!
            );

            modelBuilder.Entity<SingleChoiceQuestionTemplate>()
                .Property(e => e.AnswerOptions)
                .HasConversion(answerOptionsConverter)
                .HasColumnType("text")
                .HasColumnName("AnswerOptions");

            modelBuilder.Entity<MultipleChoiceQuestionTemplate>()
                .Property(e => e.AnswerOptions)
                .HasConversion(answerOptionsConverter)
                .HasColumnType("text")
                .HasColumnName("AnswerOptions");
        }
    }
}
