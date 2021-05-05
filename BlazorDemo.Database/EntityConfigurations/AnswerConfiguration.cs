using BlazorDemo.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlazorDemo.Database.EntityConfigurations
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(a => new { a.QuestionId, a.SurveyId });

            builder.HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId);

            builder.HasOne(a => a.Survey)
                .WithMany(s => s.Answers)
                .HasForeignKey(a => a.SurveyId);

            builder.Property(a => a.Value)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
